//handler.cpp

#include "std.h"

BOOL OnInitDialog(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	con_Init(hDlg);

	return TRUE;
}

BOOL OnCommand(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam))
	{
		//임시 접속버튼
	case IDC_BUTTON1:	con_Connect(hDlg);			break;
		//계좌이름으로 계좌 id검색
	case IDC_BUTTON6:	con_SelectAccount(hDlg);	break;
		//계좌 생성
	case IDC_BUTTON2:	con_InsertAccount(hDlg);	break;
		//콥보박스 셀변경
	case IDC_COMBO1:	con_NotifyComboBox(hDlg, wParam);	break;
	case IDCANCEL:		con_Exit(hDlg);				return 0;
	}
	return TRUE;
}