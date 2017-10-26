#include <glut.h>
#include <time.h>
#include <windows.h>
#include <stdio.h>

int lenght = 3;
int speed = 100;

//route: 0 = to up
//1 = to right
//2 = to down 
//3 = to left 
enum Route {UP, RIGHT, DOWN, LEFT};
Route route=UP;

struct
{
	int x;
	int y;
} Snake[100];

struct
{
	int x;
	int y;
} Apple;

void init(void);


void display()
{


	glPointSize(10);//диаметр растровой точки
	glClear(GL_COLOR_BUFFER_BIT);//очистка экрана в черный цвет
	glBegin(GL_POINTS);//начинаем рисовать точки

	glColor3f(0.5, 0.1, 0);//цвет точек
	for (int i = 20; i < 380; i++) glVertex2f(i, 20);//ставим левую стенку 380 точек
	for (int i = 20; i < 280; i++) glVertex2f(20, i);//нижнюю 280 точек
	for (int i = 20; i < 380; i++) glVertex2f(i, 280);//правую
	for (int i = 20; i < 280; i++) glVertex2f(380, i);//верхнюю

	glClear(GL_COLOR_BUFFER_BIT);

	glColor3f(0, 1, 0);
	for (int i = 0; i < lenght; ++i)
	{//рисуем змею
		glVertex2f(Snake[i].x - 10, Snake[i].y - 10);
	}

	glColor3f(1, 0.3, 0);
	glVertex2f(Apple.x - 10, Apple.y - 10);//рисуем яблоко

	glClear(GL_COLOR_BUFFER_BIT);

	glEnd();
	glFlush();
	glutSwapBuffers();//смена экранных буферов

}



void timer(int = 0)
{
	display();

	if (route == UP && speed % 10 == 0)//вверх
	{
		for (int i = lenght - 1; i>0; --i)
		{
			Snake[i].x = Snake[i - 1].x;
			Snake[i].y = Snake[i - 1].y;
		}
		Snake[0].y -= 10;
		speed = 1;
	}

	if (route == RIGHT && speed % 10 == 0)//
	{
		for (int i = lenght - 1; i>0; --i)
		{
			Snake[i].x = Snake[i - 1].x;
			Snake[i].y = Snake[i - 1].y;
		}
		Snake[0].x += 10;
		speed = 1;
	}

	if (route == DOWN && speed % 10 == 0)
	{
		for (int i = lenght - 1; i>0; --i)
		{
			Snake[i].x = Snake[i - 1].x;
			Snake[i].y = Snake[i - 1].y;
		}
		Snake[0].y += 10;
		speed = 1;
	}

	if (route == LEFT && speed % 10 == 0)
	{
		for (int i = lenght - 1; i>0; --i)
		{
			Snake[i].x = Snake[i - 1].x;
			Snake[i].y = Snake[i - 1].y;
		}
		Snake[0].x -= 10;
		speed = 1;
	}

	if (Snake[0].x <= 30 || Snake[0].y <= 30 || Snake[0].x >= 390 || Snake[0].y >= 290)
	{
		MessageBox(NULL, TEXT("Врезались в стенку"), TEXT("Snake"), MB_OK);
		exit(0);
	}

	if (GetAsyncKeyState(VK_LEFT))
	{
		if (route != RIGHT)route = LEFT;
	}

	if (GetAsyncKeyState(VK_RIGHT))
	{
		if (route != LEFT)route = RIGHT;
	}

	if (GetAsyncKeyState(VK_UP))
	{
		if (route != UP)route = DOWN;
	}

	if (GetAsyncKeyState(VK_DOWN))
	{
		if (route != DOWN)route = UP;
	}

	if (GetAsyncKeyState(27)) exit(0);

	if (Snake[0].x == Apple.x && Snake[0].y == Apple.y)
	{
		while (true)
		{
			Apple.x = rand() % 400;
			Apple.y = rand() % 300;
			if (Apple.x % 10 == 0 && Apple.y % 10 == 0 && Apple.x > 40 && Apple.x < 350 && Apple.y > 40 && Apple.y < 250) break;
		}
		++lenght;
		Snake[lenght].x = Snake[lenght].x;
		Snake[lenght].y = Snake[lenght].y - 10;
	}

	for (int i = 1; i < lenght; ++i)
		if (Snake[0].x == Snake[i].x && Snake[0].y == Snake[i].y)
		{
			MessageBox(NULL, TEXT("Вы съели сами себя"), TEXT("Snake"), MB_OK);
			exit(0);
		}

	if (lenght == 100)
	{
		MessageBox(NULL, TEXT("Победа"), TEXT("Snake"), MB_OK);
		exit(0);
	}

	if (speed < 200) speed++;

	glutTimerFunc(10, timer, 0);
}

void init()
{
	int lenght = 3;
	int speed = 100;
	Route route = UP;

	srand(time(NULL));

	while (true)
	{
		Apple.x = rand() % 400;
		Apple.y = rand() % 300;
		if (Apple.x % 10 == 0 && Apple.y % 10 == 0 && Apple.x > 40 && Apple.x < 350 && Apple.y > 40 && Apple.y < 250) break;
	}

	Snake[0].x = 200;
	Snake[0].y = 150;

	for (int i = 0; i < lenght; ++i)
	{
		Snake[i + 1].x = Snake[i].x;
		Snake[i + 1].y = Snake[i].y + 10;
	}
	timer();
}

int main(int argc, char **argv)
{
	printf("OpenGl Debug Console");
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(400, 300);

	glutInitWindowPosition(50, 100);
	glutCreateWindow("Snake");
	glLoadIdentity();
	glMatrixMode(GL_PROJECTION);

	glViewport(0, 0, 400, 300);
	gluOrtho2D(0.0, 400.0, 0.0, 300.0);

	glutDisplayFunc(display);

	init();

	glutMainLoop();
	return 0;
}