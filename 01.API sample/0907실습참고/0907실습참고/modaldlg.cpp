//modaldlg.cpp

#include <Windows.h>
#include "modaldlg.h"
#include "member.h"
#include "resource.h"

BOOL CALLBACK ModalDlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static MEMBER* ptemp;
	static HWND hCombo;

	switch (msg)
	{
	case WM_INITDIALOG: 
	{
		ptemp = (MEMBER*)lParam;

		hCombo = GetDlgItem(hDlg, IDC_COMBO1);
		SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)TEXT("남"));
		SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)TEXT("여"));
		SendMessage(hCombo, CB_SETCURSEL, 0, 0);//WPARAM

		return TRUE;
	}						
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
		{
			ptemp->number = GetDlgItemInt(hDlg, IDC_EDIT1, 0, 0);
			GetDlgItemText(hDlg, IDC_EDIT2, ptemp->name, sizeof(ptemp->name));
			int idx = SendMessage(hCombo, CB_GETCURSEL, 0, 0);
			if (idx == 0)	ptemp->gender = 'm';
			else            ptemp->gender = 'f';
			GetDlgItemText(hDlg, IDC_EDIT3, ptemp->phone, sizeof(ptemp->phone));

			EndDialog(hDlg, IDOK);
			return 0;
		}
		case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;
		}
		return TRUE;
	}

	return FALSE;	// 제공되는 기본 프로서저를 호출하게 됨..... 
}