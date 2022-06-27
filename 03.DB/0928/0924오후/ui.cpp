//ui.cpp
#include "std.h"

extern HWND g_hDlg;

void ui_GetAccount(HWND hDlg, ACCOUNT* pacc)
{
	GetDlgItemText(hDlg, IDC_EDIT2, pacc->name, _countof(pacc->name));
	pacc->balance = GetDlgItemInt(hDlg, IDC_EDIT3, 0, 0);
}

void ui_GetSelectName(HWND hDlg, TCHAR* name)
{
	GetDlgItemText(hDlg, IDC_EDIT8, name, sizeof(name));
}

void ui_SetComboBox(int count, int* ids)
{
	HWND hCombo = GetDlgItem(g_hDlg, IDC_COMBO1);

	//콤보박스 데이터 삭제
	SendMessage(hCombo, CB_RESETCONTENT, 0, 0);

	//데이터 추가
	TCHAR buf[10];
	for (int i = 0; i < count; i++)
	{
		wsprintf(buf, TEXT("%d"), ids[i]);
		SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)buf);
	}

}

int ui_GetId(HWND hDlg)
{
	HWND hCombo = GetDlgItem(hDlg, IDC_COMBO1);

	int i = SendMessage(hCombo, CB_GETCURSEL, 0, 0);

	TCHAR str[10];
	SendMessage(hCombo, CB_GETLBTEXT, i, (LPARAM)str);

	//문자열 -> 숫자
	return _ttoi(str);
}

void ui_SelectAccountPrint(PACK_ACCOUNTINFO* pacc)
{
	SetDlgItemText(g_hDlg, IDC_EDIT4, pacc->name);
	SetDlgItemInt(g_hDlg, IDC_EDIT5, pacc->balance, 0);
	TCHAR buf[50];
	wsprintf(buf, TEXT("%d/%d/%d"), pacc->stime.wYear, pacc->stime.wMonth, pacc->stime.wDay);
	SetDlgItemText(g_hDlg, IDC_EDIT7, buf);
}