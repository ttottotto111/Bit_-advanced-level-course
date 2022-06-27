// fun.cpp

#include <Windows.h>
#include"Member.h"
#include "fun.h"
#include "resource.h"
#include <vector>
using namespace std;

vector <MEMBER> memlist;
extern HWND hCombo;
TCHAR g_name[20];

void fun_ControlInit(HWND hDlg)
{
	hCombo = GetDlgItem(hDlg, IDC_COMBO1);

	SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)"M");
	SendMessage(hCombo, CB_ADDSTRING, 0, (LPARAM)"F");
	SendMessage(hCombo, CB_SETCURSEL, 0, 0);//WPARAM
}

void fun_GetWindowHandle(TCHAR * msg, HWND *phwnd)
{
	HWND hwnd = FindWindow(0, msg);
	if (hwnd == 0)
		throw TEXT("윈도우핸들을 찾지 못했습니다.");

	*phwnd = hwnd;
}

void fun_GetMemberData(HWND hDlg, MEMBER *pmem)
{
	pmem->id = GetDlgItemInt(hDlg, IDC_EDIT1, FALSE, FALSE);//id

	GetDlgItemText(hDlg, IDC_EDIT2, pmem->name, sizeof(pmem->name));//이름

	int i = SendMessage(hCombo, CB_GETCURSEL, 0, 0);//성별
	if (i == 0)
		pmem->gender = 'm';
	else if (i == 1)
		pmem->gender = 'f';

	GetDlgItemText(hDlg, IDC_EDIT3, pmem->phone, sizeof(pmem->phone));//이름
}

void fun_SendData(HWND hDlg, HWND hwnd, MEMBER mem)
{
	COPYDATASTRUCT cds;
	cds.dwData = 0;
	cds.cbData = sizeof(MEMBER); // 전달한 data 크기	
	cds.lpData = &mem; // 전달할 Pointer

	SendMessage(hwnd, WM_COPYDATA, 0, (LPARAM)&cds);
}

void fun_ControlDataInit(HWND hDlg)
{
	SetDlgItemText(hDlg, IDC_EDIT1, TEXT(""));	//id
	SetDlgItemText(hDlg, IDC_EDIT2, TEXT(""));	//이름	
	SendMessage(hCombo, CB_SETCURSEL, 0, 0);	//성별
	SetDlgItemText(hDlg, IDC_EDIT3, TEXT(""));	//전화번호	
}

void fun_Update(HWND hDlg, MEMBER* pmem)
{
	GetDlgItemText(hDlg, IDC_EDIT4, pmem->name, sizeof(pmem->name));
	GetDlgItemText(hDlg, IDC_EDIT5, pmem->phone, sizeof(pmem->phone));
}