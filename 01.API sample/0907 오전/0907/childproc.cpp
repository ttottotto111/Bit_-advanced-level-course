//childproc.cpp

#include <Windows.h>
#include "childproc.h"
#include <tchar.h>		//범용타입 사용을 위한 h 
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

		//콤보박스 초기화
		HWND hcombo = GetDlgItem(hDlg, IDC_COMBO1);
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("0"));
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("50"));
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("100"));
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("150"));
		SendMessage(hcombo, CB_ADDSTRING, 0, (LPARAM)TEXT("200"));

		//-----부모의 전달정보로 자신의 컨트롤 초기화
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
			//자신의 컨트롤 정보로 부모의 정보를 갱신
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

			//자신을 죽이기
			EndDialog(hDlg, IDOK);

			return TRUE;
		}
		case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;
		}
		return TRUE;
	}

	return FALSE;	// 제공되는 기본 프로서저를 호출하게 됨..... 
}
