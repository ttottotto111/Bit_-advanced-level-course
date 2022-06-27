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
		//°èÁÂ»ý¼º
	case IDC_BUTTON2:	con_InsertAccount(hDlg);	break;
	case IDCANCEL:		con_Exit(hDlg);				return 0;
	}
	return TRUE;
}