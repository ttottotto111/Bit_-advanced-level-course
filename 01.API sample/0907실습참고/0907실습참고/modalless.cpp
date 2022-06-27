//modalless.cpp

#include <Windows.h>
#include "resource.h"
#include "modalless.h"
#include "member.h"

TCHAR *ptemp;

BOOL CALLBACK ModallessDlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_INITDIALOG: 
	{
		ptemp = (TCHAR*)lParam;
		return TRUE;
	}
						
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
		{
			//�����Ű�� ��.
			GetDlgItemText(hDlg, IDC_EDIT1, ptemp, sizeof(TCHAR)*20);

			//����� ����� �˸�
			SendMessage(GetParent(hDlg), WM_APPLY_NAME, 0, 0);

			return TRUE;
		}
		case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;
		}
		return TRUE;
	}

	return FALSE;	// �����Ǵ� �⺻ ���μ����� ȣ���ϰ� ��..... 
}