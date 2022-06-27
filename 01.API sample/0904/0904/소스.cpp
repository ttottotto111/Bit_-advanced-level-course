//skeleton 코드 

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//범용타입 사용을 위한 h 
#include "resource.h"
#include "handler.h"
//------------------------------------
HWND g_hDlg; // Dialog 의 핸들
#define WM_APPLY WM_USER + 100
//------------------------------------
BOOL CALLBACK DlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam) {
	switch (msg)
	{
		case WM_INITDIALOG:  return OnInitDialog(hDlg, wParam, lParam);
		case WM_COMMAND:	 return OnCommand(hDlg, wParam, lParam);
	}
	return FALSE;
}
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, PSTR lpCmdLine, int nShowCmd) {
	UINT ret = DialogBox(hInst,// instance
		MAKEINTRESOURCE(IDD_DIALOG1), // 다이얼로그 선택
		0, // 부모 윈도우
		DlgProc); // Proc..
	return 0;
}
