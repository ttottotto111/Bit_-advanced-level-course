#include"Member.h"

HWND g_hView;
vector<MEMBER> memlist;


//receive
BOOL OnInitDialog(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	fun_GetHandle(hDlg);

	fun_ListViewHeader(hDlg, g_hView);

	return TRUE;
}

BOOL OnCommand(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam))
	{
	case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;//Á¾·á
	}
	return TRUE;
}

BOOL OnCopyData(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	fun_DataSave(hDlg, lParam);
	fun_ListViewPrint(hDlg);

	return TRUE;
}