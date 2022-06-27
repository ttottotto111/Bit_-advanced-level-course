//modalless.cpp

#include <Windows.h>
#include "resource.h"
#include "modalless.h"
#include "member.h"

TCHAR *ptemp;

BOOL CALLBACK ModallessDlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_INITDIALOG: 
	{
		ptemp = (TCHAR*)lParam;
		return TRUE;
	}
						
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
		{
			//변경시키면 됨.
			GetDlgItemText(hDlg, IDC_EDIT1, ptemp, sizeof(TCHAR)*20);

			//변경된 사실을 알림
			SendMessage(GetParent(hDlg), WM_APPLY_NAME, 0, 0);

			return TRUE;
		}
		case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;
		}
		return TRUE;
	}

	return FALSE;	// 제공되는 기본 프로서저를 호출하게 됨..... 
}