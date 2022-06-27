//newmemberdlg.cpp

#include "std.h"

MEMBER* pmemberdata;

BOOL CALLBACK NewMemberDlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_INITDIALOG: return new_InitDialog(hDlg, lParam);
	case WM_COMMAND:
	{
		switch (LOWORD(wParam))
		{
		case IDOK:	   new_NewMember(hDlg);			break;
		case IDCANCEL: EndDialog(hDlg, IDCANCEL);	break;
		}
		return TRUE;
	}
	}
	return FALSE;
}

BOOL new_InitDialog(HWND hDlg, LPARAM lParam)
{
	pmemberdata = (MEMBER*)lParam;

	HWND hCombo = GetDlgItem(hDlg, IDC_COMBO1);

	TCHAR temp[10];
	for (int i = 1; i <= 100; i++)
	{
		wsprintf(temp, TEXT("%d"), i);
		SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)temp);
	}

	SendMessage(hCombo, CB_SETCURSEL, 0, 0);

	return TRUE;
}

void new_NewMember(HWND hDlg)
{
	TCHAR id[20],pw[20], name[20];
	int age;
	GetDlgItemText(hDlg, IDC_EDIT8, pmemberdata->id, sizeof(pmemberdata->id));
	GetDlgItemText(hDlg, IDC_EDIT9, pmemberdata->pw, sizeof(pmemberdata->pw));
	GetDlgItemText(hDlg, IDC_EDIT10, pmemberdata->name, sizeof(pmemberdata->name));

	HWND hCombo = GetDlgItem(hDlg, IDC_COMBO1);
	int idx = SendMessage(hCombo, CB_GETCURSEL, 0, 0);
	pmemberdata->age = idx + 1;

	EndDialog(hDlg, IDOK);
}