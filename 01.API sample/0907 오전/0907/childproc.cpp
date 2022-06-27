//childproc.cpp

#include <Windows.h>
#include "childproc.h"
#include <tchar.h>		//����Ÿ�� ����� ���� h 
#include "resource.h"
#include "data.h"

//DATA* g_temp;

BOOL CALLBACK ChildDlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static DATA* ptemp;

	switch (msg)
	{
	case WM_INITDIALOG:
	{
		ptemp = (DATA*)lParam;

		//�޺��ڽ� �ʱ�ȭ
		HWND hcombo = GetDlgItem(hDlg, IDC_COMBO1);
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("0"));
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("50"));
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("100"));
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("150"));
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("200"));

		//-----�θ��� ���������� �ڽ��� ��Ʈ�� �ʱ�ȭ
		SetDlgItemInt(hDlg, IDC_EDIT1, ptemp->xcount, 0);
		SetDlgItemInt(hDlg, IDC_EDIT2, ptemp->ycount, 0);

		switch (ptemp->color)
		{
		case RGB(0, 0, 0):			SendMessage(hcombo, CB_SETCURSEL, 0, 0); break;
		case RGB(50, 50, 50):			SendMessage(hcombo, CB_SETCURSEL, 1, 0); break;
		case RGB(100, 100, 100):	SendMessage(hcombo, CB_SETCURSEL, 2, 0); break;
		case RGB(150, 150, 150):	SendMessage(hcombo, CB_SETCURSEL, 3, 0); break;
		case RGB(200, 200, 200):	SendMessage(hcombo, CB_SETCURSEL, 4, 0); break;
		}

		return TRUE;
	}

	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
		{
			//�ڽ��� ��Ʈ�� ������ �θ��� ������ ����
			ptemp->xcount = GetDlgItemInt(hDlg, IDC_EDIT1, 0, 0);
			ptemp->ycount = GetDlgItemInt(hDlg, IDC_EDIT2, 0, 0);

			HWND hcombo = GetDlgItem(hDlg, IDC_COMBO1);
			int cursor = SendMessage(hcombo, CB_GETCURSEL, 0, 0);
			switch (cursor)
			{
			case 0:	 ptemp->color = RGB(0, 0, 0);		 break;
			case 1:	 ptemp->color = RGB(50, 50, 50);	 break;
			case 2:	 ptemp->color = RGB(100, 100, 100);  break;
			case 3:	 ptemp->color = RGB(150, 150, 150);  break;
			case 4:	 ptemp->color = RGB(200, 200, 200);  break;
			}

			//�ڽ��� ���̱�
			EndDialog(hDlg, IDOK);

			return TRUE;
		}
		case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;
		}
		return TRUE;
	}

	return FALSE;	// �����Ǵ� �⺻ ���μ����� ȣ���ϰ� ��..... 
}
