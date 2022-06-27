//handler.cpp
#include <Windows.h>
#include <vector>
using namespace std;
#include "resource.h"
#include "fun.h"
#include "member.h"

vector<MEMBER> memlist;
HWND g_hView;

void temp_fun(HWND hDlg)
{
	MEMBER mem;
	mem.number = 11;
	_tcscpy_s(mem.name, _countof(mem.name), TEXT("홍길동"));
	mem.gender = 'm';
	_tcscpy_s(mem.phone, _countof(mem.phone), TEXT("010-1111-1111"));

	memlist.push_back(mem);

	mem.number = 22;
	_tcscpy_s(mem.name, _countof(mem.name), TEXT("이길순"));
	mem.gender = 'f';
	_tcscpy_s(mem.phone, _countof(mem.phone), TEXT("010-2222-2222"));

	memlist.push_back(mem);

	fun_ListViewPrint(hDlg);
}

BOOL OnInitDialog(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	g_hView = GetDlgItem(hDlg, IDC_LIST1);

	//헤더 초기화
	fun_ListViewHeader(hDlg, g_hView);

	temp_fun(hDlg);

	return TRUE;
}

BOOL OnCommand(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam))
	{
	case ID_40002: fun_Insert(hDlg);			break;
	case ID_40003: fun_Select(hDlg);			break;
	case IDC_BUTTON1: fun_Delete(hDlg);			break;
	case IDC_BUTTON2: fun_Update(hDlg);			break;
	case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;
	}
	return TRUE;
}

BOOL OnApplyName(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	fun_ApplyName(hDlg);

	return TRUE;
}

BOOL OnNotify(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	fun_ListViewNotify(hDlg, wParam, lParam);
	return TRUE;
}