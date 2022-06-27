//handler.cpp

#include <Windows.h>
#include "resource.h"
#include "handler.h"
#include <vector>
using namespace std;
#include "account.h"
#include "fun.h"

vector<ACCOUNT> acclist;

BOOL  OnInitDialog(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	fun_GetControlHandle(hDlg);

	return TRUE;
}


BOOL  OnCommand(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam))	// ID����(�޴�, ��Ʈ��) 
	{
	case IDCANCEL:		OnCancel(hDlg);					return 0;	// �����޽���.
	case IDC_BUTTON1:	fun_Insert(hDlg);				break;
	case IDC_LIST1:		fun_ListSelect(hDlg,wParam);	break;
	case IDC_BUTTON2:	fun_Update(hDlg);				break;
	case IDC_BUTTON3:	fun_Delete(hDlg);				break;
	}
	return TRUE;
}


//����� ���� �ڵ鷯 ---------------------------------------------
void OnCancel(HWND hDlg)
{
	EndDialog(hDlg, IDCANCEL);
}