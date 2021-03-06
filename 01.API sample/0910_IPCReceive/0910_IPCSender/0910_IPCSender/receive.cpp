//대화 상자 기반
#pragma comment (linker, "/subsystem:windows")

#include"Member.h"
extern vector<MEMBER> memlist;

BOOL CALLBACK DlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_COPYDATA: return OnCopyDataStruct(hDlg, msg, wParam, lParam);
	case WM_INITDIALOG: return OnReceiveInitDialog(hDlg, msg, wParam, lParam);
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;//종료
		}
		return TRUE;
	}
	//return  true를 하면 기본제공 사용안함
	return FALSE;//기본제공되는 프로시져를 실행
}


int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, PSTR lpCmdLine, int nShowCmd)
{
	UINT ret = DialogBox(hInst,// instance 
		MAKEINTRESOURCE(IDD_DIALOG2), // 다이얼로그 선택 
		0, // 부모 윈도우 
		DlgProc); // Proc.. 
	return 0;
}
