#include <iostream>
#include <windows.h>
#include <tchar.h>
#include <stdlib.h>
#include <WinUser.h>
#include <Windowsx.h>
#include <vector>
#include "resource.h"

using namespace std;

BOOL CALLBACK DlgProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
HWND hFileField;
TCHAR filename[30];
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	return DialogBox(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, DlgProc);
}
void ChangeFile(TCHAR fName[], int size){
	int res;
	HANDLE hFile = CreateFile(
		fName,
		GENERIC_READ | GENERIC_WRITE | DELETE,
		0 /* exclusive access */,
		NULL,
		OPEN_EXISTING,
		0,
		NULL);
	FILE_END_OF_FILE_INFO feofi;
	feofi.EndOfFile.QuadPart = size;

	if (hFile != INVALID_HANDLE_VALUE)
	{
		BOOL fResult = SetFileInformationByHandle(hFile,
			FileEndOfFileInfo,
			&feofi,
			sizeof(FILE_END_OF_FILE_INFO));
		if (fResult)
		{
			res = MessageBox(0, TEXT("Файл раздут"), TEXT("Готово"), MB_OK | MB_ICONINFORMATION);
		}
		else
		{
			res = MessageBox(0, TEXT("Файл НЕ изменен"), TEXT("Готово"), MB_OK | MB_ICONINFORMATION);
		}
	}
	else {
		res = MessageBox(0, TEXT("Файл не найден"), TEXT("Фейл"), MB_OK | MB_ICONINFORMATION);
	}
	CloseHandle(hFile);//file was deleted when hadnle close
}
BOOL CALLBACK DlgProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam){
	switch (msg){
	case WM_INITDIALOG: {
		hFileField = GetDlgItem(hWnd, IDC_FILEFIELD);
		HMENU MainMenu = LoadMenu(GetModuleHandle(0), MAKEINTRESOURCE(IDR_MENU1));
		SetMenu(hWnd, MainMenu);
	} return TRUE;
	case WM_CLOSE: EndDialog(hWnd, 0);
		return TRUE;
	case WM_COMMAND:{
		switch (wParam){
		case IDC_OK: GetWindowText(hFileField, filename, 30);
			break;
		case ID_30: ChangeFile(filename, 30000);
			break;
		case ID_50: ChangeFile(filename, 50000);
			break;
		case ID_100: ChangeFile(filename, 100000);
			break;
		}
	} return TRUE;
	}return FALSE;
}
