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
	case IDC_BUTTON6:	con_SendData(hDlg);			break;
	case IDC_BUTTON5:	con_LogOut(hDlg);			break;
	case IDC_BUTTON4:	con_NewMember(hDlg);		break;
	case IDC_BUTTON3:	con_Login(hDlg);			break;
	case IDC_BUTTON2:	con_DisConnectServer(hDlg);	break;
	case IDC_BUTTON1:	con_ConnectServer(hDlg);	break;
	case IDCANCEL:		con_Cancel(hDlg);			break;
	}
	return TRUE;
}
