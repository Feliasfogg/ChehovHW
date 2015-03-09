#include <iostream>
#include <windows.h>
#include <tchar.h>
#include <stdlib.h>
#include <WinUser.h>
#include <Windowsx.h>
#include <vector>

using namespace std;

LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam); //������� ��������� ����������� ����� ������
//���������: ���������� ����, ���� ���������, ���.���������, ���.���������

void menuAction(WPARAM wParam);//menu switcher
double charsCount();

TCHAR szClassWindowName[] = TEXT("��� ������ ���-����������");//��� ������ ����
struct Info{
	TCHAR title[20];
	TCHAR text[20];
	Info(TCHAR* _title, TCHAR* _text){
		wcscpy(title, _title);
		wcscpy(text, _text);
	}
};
vector<Info*> infos = { new Info(TEXT("��� � �������"), TEXT("����� �����")), new Info(TEXT("�������"), TEXT("24")), new Info(TEXT("����� ������"), TEXT("�� ����")),
new Info(TEXT("������� ����� �������� � ������ ����"), TEXT("")) };


INT WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hInstPrev, LPTSTR lpszCmdLine, int nCmdShow){
	/*���: ����� ���������, ����� ��������� ������� ��������� ������� ����������, ��������� �� ������ ��� ����������� ���������� ��� ������� �� cmd.exe,
	������ ������������ ���� ��� ������� ���������*/
	HWND hWnd;//instance handle of the window class
	MSG Msg;//message struct
	WNDCLASSEX wcl;//window struct

	//1 declared window class
	wcl.cbSize = sizeof(wcl);//������� ������ ����� �������� ����
	wcl.style = CS_HREDRAW | CS_VREDRAW;//����� ���� ������� � ��� ��� ���� ����� ������������ �� ��������� � �����������
	wcl.lpfnWndProc = WindowProc;//����� ������� ���������, ������� ������� ����� ��� ��������� ��������� �� ����
	wcl.cbClsExtra = 0;//count bytes, after struct of class window
	wcl.cbWndExtra = 0;//count bytes, after declared window
	wcl.hInstance = hInst;//handle current app
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION);//load default icon application
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW);//liad default cursor
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);//fill window by white color
	wcl.lpszMenuName = NULL;//app not content menu
	wcl.lpszClassName = szClassWindowName;//set name for window class
	wcl.hIconSm = NULL;

	//2 register window class
	if (!RegisterClassEx(&wcl)) return 0;

	//3 create window
	hWnd = CreateWindowEx(
		0,//extension window style
		szClassWindowName,//name of window class
		TEXT("������"),//title of window
		WS_OVERLAPPEDWINDOW,//window style
		/* ���������, �����, ����������� ������ �������, ��������� ����, ������ ������������ � ���������� ����  */
		CW_USEDEFAULT,	// �
		CW_USEDEFAULT,	// y
		CW_USEDEFAULT,	// width window
		CW_USEDEFAULT,	// heght window
		NULL,//handle parent window
		NULL,//handle main menu
		hInst,//handle app
		NULL//pointer to the applications data
		);

	//4 show window
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);//redrawind window

	//5 creaete menu
	HMENU MainMenu;
	HMENU  SubMenu;
	MainMenu = CreateMenu();
	SubMenu = CreateMenu();
	AppendMenu(MainMenu, MF_POPUP, (UINT_PTR)SubMenu, TEXT("������"));
	AppendMenu(SubMenu, MF_STRING, 0, TEXT("���"));
	AppendMenu(SubMenu, MF_STRING, 1, TEXT("�������"));
	AppendMenu(SubMenu, MF_STRING, 2, TEXT("������"));
	AppendMenu(SubMenu, MF_STRING, 3, TEXT("������� ���-�� ��������"));
	AppendMenu(MainMenu, MF_STRING, 4, TEXT("�����"));

	SetMenu(hWnd, MainMenu);

	//6 processing for message queue
	while (GetMessage(&Msg, NULL, 0, 0)){
		//args for GetMessage - addres message struct, handle window, min number of recieved mesage, max number of recieved message
		TranslateMessage(&Msg);//translate message and put them in queue of window messages
		DispatchMessage(&Msg);//give the message to windows for processing
	}
	return Msg.wParam;
}
LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam){
	switch (uMessage){
	case WM_COMMAND:
		menuAction(wParam);
		break;
	case WM_CLOSE:
		DestroyWindow(hWnd);//this finction call WM_DESTROY and WM_NCDESTROY, clear message queue for current app, destroying window menu
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMessage, wParam, lParam);
		break;
	}
	return 0;
}
void menuAction(WPARAM wParam){
	int res;
	vector<Info*>::iterator i = infos.begin();
	switch (wParam){
	case 0:
		res = MessageBox(0, (*(*(i + wParam))).text, (*(*(i + wParam))).title, MB_OK | MB_ICONINFORMATION);
		break;
	case 1:
		res = MessageBox(0, (*(*(i + wParam))).text, (*(*(i + wParam))).title, MB_OK | MB_ICONINFORMATION);
		break;
	case 2:
		res = MessageBox(0, (*(*(i + wParam))).text, (*(*(i + wParam))).title, MB_OK | MB_ICONINFORMATION);
		break;
	case 3:{
		double all_chars = charsCount();
		TCHAR buff[50];
		swprintf(buff, TEXT("������� ����� %f ��������"), all_chars);//wsprintf doesnt work with qualifier %f
		res = MessageBox(0, buff, (*infos[2]).title, MB_OK | MB_ICONINFORMATION);
	}
		   break;
	case 4:
		res = MessageBox(0, TEXT("�� ������� ��� ������ �����?"), TEXT("�����"), MB_YESNO | MB_ICONINFORMATION);
		if (res == IDYES) PostQuitMessage(0);
		break;
	}
}

double charsCount(){
	return ((double)(wcslen((*infos[0]).text) + (double)wcslen((*infos[1]).text)) / 3);
}