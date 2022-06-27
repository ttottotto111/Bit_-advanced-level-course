//fun.cpp

#include <Windows.h>
#include <commctrl.h>
#include "fun.h"
#include "resource.h"
#include "account.h"
#include <vector>
using namespace std;

extern vector<ACCOUNT> acclist; // ��������
HWND hinputname, hinputid, hinputbalance;
HWND hidlistbox;

void fun_Insert(HWND hDlg) {
	//-------------------------------------------------����
	ACCOUNT acc;
	acc.id = GetDlgItemInt(hDlg, IDC_EDIT1, 0, 0);
	GetDlgItemText(hDlg, IDC_EDIT2, acc.name, sizeof(acc.name));
	acc.balance = GetDlgItemInt(hDlg, IDC_EDIT3, 0, 0);

	acclist.push_back(acc);

	//----------------------------------------------------���尳�����
	int count = acclist.size();
	TCHAR buf[100];
	wsprintf(buf, TEXT("���尳��:%d��"), acclist.size());
	SetDlgItemText(hDlg, IDC_STATIC1, buf);
	
	//------------------------------------------------------
	//����Ʈ�ڽ��� ID�� ���---------------------------------
	for (int i = 0; i < (int)acclist.size()-1; i++)
	{
		SendMessage(hidlistbox, LB_DELETESTRING, (WPARAM)0, 0);
	}

	for (int i = 0; i < (int)acclist.size(); i++) 
	{
		ACCOUNT acc = acclist[i];
		TCHAR buf[10];
		wsprintf(buf, TEXT("%d"), acc.id);
		SendMessage(hidlistbox, LB_ADDSTRING, 0, (LPARAM)buf);
	}
}

void fun_GetControlHandle(HWND hDlg) {
	hinputid = GetDlgItem(hDlg, IDC_EDIT1);
	hinputname = GetDlgItem(hDlg, IDC_EDIT2);
	hinputbalance = GetDlgItem(hDlg, IDC_EDIT3);
	hidlistbox = GetDlgItem(hDlg, IDC_LIST1);
}

void fun_ListSelect(HWND hDlg, WPARAM wParam)
{
	switch (HIWORD(wParam))
	{
	case LBN_SELCHANGE:
	{
		TCHAR str[50];
		int i = SendMessage(hidlistbox, LB_GETCURSEL, 0, 0);
		SendMessage(hidlistbox, LB_GETTEXT, i, (LPARAM)str);

		//str�� ����� ���ڿ�(id)�� ���ڷ� ��ȯ�ؼ� �˻�
		int id = _ttoi(str);

		for (int i = 0; i < (int)acclist.size(); i++)
		{
			ACCOUNT acc = acclist[i];
			if (acc.id == id)
			{
				SetDlgItemInt(hDlg, IDC_EDIT4,acc.id, 0);
				SetDlgItemText(hDlg, IDC_EDIT5,acc.name);
				SetDlgItemInt(hDlg, IDC_EDIT6,acc.balance, 0);
				break;
			}
		}

		break;
	}
	}

}