//fun.cpp

#include <Windows.h>
#include "fun.h"
#include "resource.h"
#include <vector>
using namespace std;
#include "myprocess.h"
#include <CommCtrl.h>

vector<MYPROCESS> plist;

//���α׷� ���� -> ���μ��� ���� 
//WinExec �Լ��� ���������� CreateProcess �Լ��� ȣ��...
void fun_WinExec(HWND hDlg)
{
	WinExec("notepad.exe", SW_SHOW);	//calc.exe
}

void fun_CreateProcess(HWND hDlg)
{
//	TCHAR name[] = TEXT("calc.exe");
	TCHAR name[20];
	GetDlgItemText(hDlg, IDC_EDIT1, name, sizeof(name));

	PROCESS_INFORMATION pi;
	STARTUPINFO si = { sizeof(si) };

	BOOL b = CreateProcess(0, name,	//���� 2��° ���ڷ� ������ ���μ������� �ִ´�.
		0, 0,						//���ȼӼ�(Ŀ�ο�����Ʈ�� ��� ���ڷ� ����)
		0,							//�ڽ��� Ŀ�ο�����Ʈ�ڵ����̺� �����
									//�ڵ鰪�� �ڽ����μ����� ������ ���ΰ�?
		NORMAL_PRIORITY_CLASS,		//�켱����:���� NORMAL��(6�ܰ谡 �ִ�.)
		0, 0,						//�ɼ�
		&si, &pi);					//pi :  Pid, Tid, PHandle, Thandle

	//���Ϳ� �����ϰ�, ListBox ����Լ��� ȣ��
	MYPROCESS myp;
	_tcscpy_s(myp.name, _countof(myp.name), name);
	myp.phandle = pi.hProcess;
	myp.pid = pi.dwProcessId;

	plist.push_back(myp);

	fun_ListBoxPrint(hDlg);
}

void fun_ListBoxPrint(HWND hDlg)
{
	HWND hList = GetDlgItem(hDlg, IDC_LIST1);

	//��ü ����
	for (int i = 0; i < (int)plist.size() + 1; i++)
	{
		SendMessage(hList, LB_DELETESTRING, (WPARAM)0, 0);
	}

	for (int i = 0; i < (int)plist.size(); i++)
	{
		MYPROCESS myp = plist[i];
		TCHAR buf[10];
		wsprintf(buf, TEXT("%d"), myp.pid);
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)buf);
	}
}

void fun_List(HWND hDlg, WPARAM wParam)
{
	HWND hList = GetDlgItem(hDlg, IDC_LIST1);

	switch (HIWORD(wParam))
	{
		case LBN_SELCHANGE:
		{
			TCHAR buf[20];	//pid�� ���ڿ� ���·� ���� 
			int i = SendMessage(hList, LB_GETCURSEL, 0, 0);			
			SendMessage(hList, LB_GETTEXT, i, (LPARAM)buf);

			SetDlgItemText(hDlg, IDC_EDIT2, buf);

			fun_ProcessInfoPrint(hDlg, _ttoi(buf));	//<=======���ڿ�->����
			break;
		}
	}
}

void fun_ProcessInfoPrint(HWND hDlg, int pid)
{
	//���� �̸����� �˻� -> �ش� ���μ������� ȹ�� -> ��Ʈ�� ��� 
	for (int i = 0; i < (int)plist.size(); i++)
	{
		MYPROCESS myp = plist[i];

		if ( myp.pid == pid)
		{
			SetDlgItemInt(hDlg, IDC_EDIT3, myp.pid, 0);
			SetDlgItemText(hDlg, IDC_EDIT4, myp.name);
			SetDlgItemInt(hDlg, IDC_EDIT5, (int)myp.phandle, 0);
			fun_ExitCodeProcess(hDlg, myp.phandle);
			break;
		}
	}
}

void fun_TerminateProcess(HWND hDlg)
{
	HANDLE handle;
	handle = (HANDLE)GetDlgItemInt(hDlg, IDC_EDIT5, 0, 0);

	TerminateProcess(handle, -1);

	//vector���� ���� & ����Ʈ�ڽ��� ����
	for (int i = 0; i < (int)plist.size(); i++)
	{
		MYPROCESS myp = plist[i];
		if (myp.phandle == handle)
		{
			vector<MYPROCESS>::iterator itr = plist.begin();
			plist.erase(itr + i);

			fun_ListBoxPrint(hDlg);
			break;
		}
	}
}


void fun_ExitCodeProcess(HWND hDlg, HANDLE phandle)
{
	DWORD code;
	GetExitCodeProcess(phandle, &code);

	if (code == STILL_ACTIVE)	//����ִ�.
	{
		SetDlgItemText(hDlg, IDC_EDIT6, TEXT("����ִ�"));
	}
	else
	{
		SetDlgItemText(hDlg, IDC_EDIT6, TEXT("�׾���"));
	}
}