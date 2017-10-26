#include <windows.h>
#include <tchar.h>
#include <glut.h>
#include <GL/GL.h>
#include <GL/GLU.h>

using namespace std;

HGLRC  hRC = NULL;              // Постоянный контекст рендеринга
HDC  hDC = NULL;              // Приватный контекст устройства GDI
HWND  hWnd = NULL;              // Здесь будет хранится дескриптор окна
HINSTANCE  hInstance;              // Здесь будет хранится дескриптор приложения

bool  keys[256];                // Массив, используемый для операций с клавиатурой
bool  active = true;                // Флаг активности окна, установленный в true по умолчанию
bool  fullscreen = true;              // Флаг режима окна, установленный в полноэкранный по умолчанию

LRESULT  CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

GLvoid ReSizeGLScene(GLsizei width, GLsizei height)        // Изменить размер и инициализировать окно GL
{
	if (height == 0)              // Предотвращение деления на ноль
	{
		height = 1;
	}

	glViewport(0, 0, width, height);          // Сброс текущей области вывода
	glMatrixMode(GL_PROJECTION);            // Выбор матрицы проекций
	glLoadIdentity();              // Сброс матрицы проекции

	// Вычисление соотношения геометрических размеров для окна
	gluPerspective(45.0f, (GLfloat)width / (GLfloat)height, 0.1f, 100.0f);

	glMatrixMode(GL_MODELVIEW);            // Выбор матрицы вида модели
	glLoadIdentity();              // Сброс матрицы вида модели
}
int InitGL(GLvoid)                // Все установки касаемо OpenGL происходят здесь
{
	glShadeModel(GL_SMOOTH);            // Разрешить плавное цветовое сглаживание
	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);          // Очистка экрана в черный цвет
	glClearDepth(1.0f);              // Разрешить очистку буфера глубины
	glEnable(GL_DEPTH_TEST);            // Разрешить тест глубины
	glDepthFunc(GL_LEQUAL);            // Тип теста глубины
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);      // Улучшение в вычислении перспективы
	return true;                // Инициализация прошла успешно
}
int DrawGLScene(GLvoid)                // Здесь будет происходить вся прорисовка
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);      // Очистить экран и буфер глубины
	glLoadIdentity();              // Сбросить текущую матрицу
	return true;                // Прорисовка прошла успешно
}

GLvoid KillGLWindow(GLvoid)              // Корректное разрушение окна
{
	if (fullscreen)              // Мы в полноэкранном режиме?
	{
		ChangeDisplaySettings(NULL, 0);        // Если да, то переключаемся обратно в оконный режим
		ShowCursor(true);            // Показать курсор мышки
	}
	if (hRC)                // Существует ли Контекст Рендеринга?
	{
		if (!wglMakeCurrent(NULL, NULL))        // Возможно ли освободить RC и DC?
		{
			MessageBox(NULL, TEXT("Release Of DC And RC Failed."), TEXT("SHUTDOWN ERROR"), MB_OK | MB_ICONINFORMATION);
		}
		if (!wglDeleteContext(hRC))        // Возможно ли удалить RC?
		{
			MessageBox(NULL, TEXT("Release Rendering Context Failed."), TEXT("SHUTDOWN ERROR"), MB_OK | MB_ICONINFORMATION);
		}
		hRC = NULL;              // Установить RC в NULL
	}
	if (hDC && !ReleaseDC(hWnd, hDC))          // Возможно ли уничтожить DC?
	{
		MessageBox(NULL, TEXT("Release Device Context Failed."), TEXT("SHUTDOWN ERROR"), MB_OK | MB_ICONINFORMATION);
		hDC = NULL;                // Установить DC в NULL
	}
	if (hWnd && !DestroyWindow(hWnd))            // Возможно ли уничтожить окно?
	{
		MessageBox(NULL, TEXT("Could Not Release hWnd."), TEXT("SHUTDOWN ERROR"), MB_OK | MB_ICONINFORMATION);
		hWnd = NULL;                // Установить hWnd в NULL
	}
	if (!UnregisterClass(TEXT("OpenGL"), hInstance))        // Возможно ли разрегистрировать класс
	{
		MessageBox(NULL, TEXT("Could Not Unregister Class."), TEXT("SHUTDOWN ERROR"), MB_OK | MB_ICONINFORMATION);
		hInstance = NULL;                // Установить hInstance в NULL
	}
}
BOOL CreateGLWindow(LPCWSTR title, int width, int height, int bits, bool fullscreenflag)
{
	GLuint    PixelFormat;              // Хранит результат после поиска
	WNDCLASS  wc;                // Структура класса окна
	DWORD    dwExStyle;              // Расширенный стиль окна
	DWORD    dwStyle;              // Обычный стиль окна
	RECT WindowRect;                // Grabs Rectangle Upper Left / Lower Right Values
	WindowRect.left = (long)0;              // Установить левую составляющую в 0
	WindowRect.right = (long)width;              // Установить правую составляющую в Width
	WindowRect.top = (long)0;                // Установить верхнюю составляющую в 0
	WindowRect.bottom = (long)height;              // Установить нижнюю составляющую в Height
	fullscreen = fullscreenflag;              // Устанавливаем значение глобальной переменной fullscreen

	hInstance = GetModuleHandle(NULL);        // Считаем дескриптор нашего приложения
	wc.style = CS_HREDRAW | CS_VREDRAW | CS_OWNDC;      // Перерисуем при перемещении и создаём скрытый DC
	wc.lpfnWndProc = (WNDPROC)WndProc;          // Процедура обработки сообщений
	wc.cbClsExtra = 0;              // Нет дополнительной информации для окна
	wc.cbWndExtra = 0;              // Нет дополнительной информации для окна
	wc.hInstance = hInstance;            // Устанавливаем дескриптор
	wc.hIcon = LoadIcon(NULL, IDI_WINLOGO);        // Загружаем иконку по умолчанию
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);        // Загружаем указатель мышки
	wc.hbrBackground = NULL;              // Фон не требуется для GL
	wc.lpszMenuName = NULL;              // Меню в окне не будет
	wc.lpszClassName = TEXT("OpenGL");            // Устанавливаем имя классу

	if (!RegisterClass(&wc))              // Пытаемся зарегистрировать класс окна
	{
		MessageBox(NULL, TEXT("Failed To Register The Window Class."), TEXT("ERROR"), MB_OK | MB_ICONEXCLAMATION);
		return false;                // Выход и возвращение функцией значения false
	}

	if (fullscreen)                // Полноэкранный режим?
	{
		DEVMODE dmScreenSettings;            // Режим устройства
		memset(&dmScreenSettings, 0, sizeof(dmScreenSettings));    // Очистка для хранения установок
		dmScreenSettings.dmSize = sizeof(dmScreenSettings);      // Размер структуры Devmode
		dmScreenSettings.dmPelsWidth = width;        // Ширина экрана
		dmScreenSettings.dmPelsHeight = height;        // Высота экрана
		dmScreenSettings.dmBitsPerPel = bits;        // Глубина цвета
		dmScreenSettings.dmFields = DM_BITSPERPEL | DM_PELSWIDTH | DM_PELSHEIGHT;// Режим Пикселя

		// Пытаемся установить выбранный режим и получить результат.  Примечание: CDS_FULLSCREEN убирает панель управления.
		if (ChangeDisplaySettings(&dmScreenSettings, CDS_FULLSCREEN) != DISP_CHANGE_SUCCESSFUL)
		{
			// Если переключение в полноэкранный режим невозможно, будет предложено два варианта: оконный режим или выход.
			if (MessageBox(NULL, TEXT("The Requested Fullscreen Mode Is Not Supported By\nYour Video Card. Use Windowed Mode Instead?"),
				TEXT("NeHe GL"), MB_YESNO | MB_ICONEXCLAMATION) == IDYES)
			{
				fullscreen = false;          // Выбор оконного режима (fullscreen = false)
			}
			else
			{// Выскакивающее окно, сообщающее пользователю о закрытие окна.
				MessageBox(NULL, TEXT("Program Will Now Close."), TEXT("ERROR"), MB_OK | MB_ICONSTOP);
				return false;            // Выход и возвращение функцией false
			}
		}
	}
	if (fullscreen)                  // Мы остались в полноэкранном режиме?
	{
		dwExStyle = WS_EX_APPWINDOW;          // Расширенный стиль окна
		dwStyle = WS_POPUP;            // Обычный стиль окна
		ShowCursor(false);              // Скрыть указатель мышки
	}
	else
	{
		dwExStyle = WS_EX_APPWINDOW | WS_EX_WINDOWEDGE;      // Расширенный стиль окна
		dwStyle = WS_OVERLAPPEDWINDOW;        // Обычный стиль окна
	}
	AdjustWindowRectEx(&WindowRect, dwStyle, false, dwExStyle);      // Подбирает окну подходящие размеры

	if (!(hWnd = CreateWindowEx(dwExStyle,          // Расширенный стиль для окна
		_T("OpenGL"),          // Имя класса
		title,            // Заголовок окна
		WS_CLIPSIBLINGS |        // Требуемый стиль для окна
		WS_CLIPCHILDREN |        // Требуемый стиль для окна
		dwStyle,          // Выбираемые стили для окна
		0, 0,            // Позиция окна
		WindowRect.right - WindowRect.left,    // Вычисление подходящей ширины
		WindowRect.bottom - WindowRect.top,    // Вычисление подходящей высоты
		NULL,            // Нет родительского
		NULL,            // Нет меню
		hInstance,          // Дескриптор приложения
		NULL)))          // Не передаём ничего до WM_CREATE (???)
	{
		KillGLWindow();                // Восстановить экран
		MessageBox(NULL, TEXT("Window Creation Error."), TEXT("ERROR"), MB_OK | MB_ICONEXCLAMATION);
		return false;                // Вернуть false
	}
	static  PIXELFORMATDESCRIPTOR pfd =            // pfd сообщает Windows каким будет вывод на экран каждого пикселя
	{
		sizeof(PIXELFORMATDESCRIPTOR),            // Размер дескриптора данного формата пикселей
		1,                  // Номер версии
		PFD_DRAW_TO_WINDOW |              // Формат для Окна
		PFD_SUPPORT_OPENGL |              // Формат для OpenGL
		PFD_DOUBLEBUFFER,              // Формат для двойного буфера
		PFD_TYPE_RGBA,                // Требуется RGBA формат
		bits,                  // Выбирается бит глубины цвета
		0, 0, 0, 0, 0, 0,              // Игнорирование цветовых битов
		0,                  // Нет буфера прозрачности
		0,                  // Сдвиговый бит игнорируется
		0,                  // Нет буфера накопления
		0, 0, 0, 0,                // Биты накопления игнорируются
		32,                  // 32 битный Z-буфер (буфер глубины)
		0,                  // Нет буфера трафарета
		0,                  // Нет вспомогательных буферов
		PFD_MAIN_PLANE,                // Главный слой рисования
		0,                  // Зарезервировано
		0, 0, 0                  // Маски слоя игнорируются
	};
	if (!(hDC = GetDC(hWnd)))              // Можем ли мы получить Контекст Устройства?
	{
		KillGLWindow();                // Восстановить экран
		MessageBox(NULL, TEXT("Can't Create A GL Device Context."), TEXT("ERROR"), MB_OK | MB_ICONEXCLAMATION);
		return false;                // Вернуть false
	}
	if (!(PixelFormat = ChoosePixelFormat(hDC, &pfd)))        // Найден ли подходящий формат пикселя?
	{
		KillGLWindow();                // Восстановить экран
		MessageBox(NULL, TEXT("Can't Find A Suitable PixelFormat."), TEXT("ERROR"), MB_OK | MB_ICONEXCLAMATION);
		return false;                // Вернуть false
	}
	if (!SetPixelFormat(hDC, PixelFormat, &pfd))          // Возможно ли установить Формат Пикселя?
	{
		KillGLWindow();                // Восстановить экран
		MessageBox(NULL, TEXT("Can't Set The PixelFormat."), TEXT("ERROR"), MB_OK | MB_ICONEXCLAMATION);
		return false;                // Вернуть false
	}

	if (!(hRC = wglCreateContext(hDC)))          // Возможно ли установить Контекст Рендеринга?
	{
		KillGLWindow();                // Восстановить экран
		MessageBox(NULL, TEXT("Can't Create A GL Rendering Context."), TEXT("ERROR"), MB_OK | MB_ICONEXCLAMATION);
		return false;                // Вернуть false
	}
	if (!wglMakeCurrent(hDC, hRC))            // Попробовать активировать Контекст Рендеринга
	{
		KillGLWindow();                // Восстановить экран
		MessageBox(NULL, TEXT("Can't Activate The GL Rendering Context."), TEXT("ERROR"), MB_OK | MB_ICONEXCLAMATION);
		return false;                // Вернуть false
	}
	ShowWindow(hWnd, SW_SHOW);              // Показать окно
	SetForegroundWindow(hWnd);              // Слегка повысим приоритет
	SetFocus(hWnd);                // Установить фокус клавиатуры на наше окно
	ReSizeGLScene(width, height);              // Настроим перспективу для нашего OpenGL экрана.
	if (!InitGL())                  // Инициализация только что созданного окна
	{
		KillGLWindow();                // Восстановить экран
		MessageBox(NULL, _T("Initialization Failed."), _T("ERROR"), MB_OK | MB_ICONEXCLAMATION);
		return false;                // Вернуть false
	}
	return true;                  // Всё в порядке!
}