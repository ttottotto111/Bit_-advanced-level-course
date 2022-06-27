//수신부 
#pragma comment (linker, "/subsystem:windows")

#include"Member.h"
extern vector<MEMBER> memlist;

BOOL CALLBACK DlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_INITDIALOG: return OnInitDialog(hDlg, wParam, lParam);
	case WM_COMMAND:	return OnCommand(hDlg, wParam, lParam);
	case WM_COPYDATA:	return OnCopyData(hDlg, wParam, lParam);		
	}
	return FALSE;//기본제공되는 프로시져를 실행
}


int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, PSTR lpCmdLine, int nShowCmd)
{
	UINT ret = DialogBox(hInst,// instance 
		MAKEINTRESOURCE(IDD_DIALOG1), // 다이얼로그 선택 
		0, // 부모 윈도우 
		DlgProc); // Proc.. 
	return 0;
}
