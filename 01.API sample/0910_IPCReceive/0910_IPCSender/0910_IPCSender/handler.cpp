//handler.cpp

#include <Windows.h>
#include "resource.h"
#include "handler.h"
#include"Member.h"
#include "fun.h"

HWND hCombo;



BOOL OnInitDialog(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	fun_ControlInit(hDlg);

	return TRUE;
}

BOOL OnCommand(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	MEMBER mem;

	switch (LOWORD(wParam))
	{
	case IDC_BUTTON1:	
		HWND hwnd;
		fun_GetWindowHandle(TEXT("receive"), &hwnd);
		fun_Update(hDlg, &mem);
		fun_SendData(hDlg, hwnd, mem);
		fun_ControlDataInit(hDlg); break;
	case IDOK:			OnSendData(hDlg);					 break;
	case IDCANCEL:		EndDialog(hDlg,  IDCANCEL); return 0;//종료
	}
	return TRUE;
}

void OnSendData(HWND hDlg)
{
	try
	{
		//1. 핸들값 획득
		HWND hwnd;
		fun_GetWindowHandle(TEXT("receive"), &hwnd);

		//2. 전달정보 획득
		MEMBER mem;
		fun_GetMemberData(hDlg, &mem);

		//3. 전송
		fun_SendData(hDlg, hwnd, mem);

		//4. 전송컨트롤을 초기화
		fun_ControlDataInit(hDlg);
	}
	catch (const TCHAR *msg)
	{
		MessageBox(0, msg, TEXT("오류"), MB_OK);
	}	
}