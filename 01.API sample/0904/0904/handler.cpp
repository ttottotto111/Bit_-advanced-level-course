//handler.cpp

#include <Windows.h>
#include "handler.h"
#include <vector>
using namespace std;
#include "account.h"
#include "resource.h"
#include "fun.h"

vector<ACCOUNT> acclist;

BOOL  OnInitDialog(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	fun_GetControlHandle(hDlg);
	return TRUE;
}

BOOL  OnCommand(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam))		//ID����(�޴�, ��Ʈ��)
	{
	case IDCANCEL:		OnCancel(hDlg);					return 0; // �����޼���.
	case IDC_BUTTON1:	fun_Insert(hDlg);				break;
	case IDC_LIST1:		fun_ListSelect(hDlg, wParam);	break;
	}
	return TRUE;
}

//����� ���� �ڵ鷯 ---------------------------------------------
void OnCancel(HWND hDlg)
{
	EndDialog(hDlg, IDCANCEL);
}
