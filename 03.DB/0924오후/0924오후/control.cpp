//control.cpp

#include "std.h"

#define ID		TEXT("ksw")
#define PW		TEXT("1111")

void con_Init(HWND hDlg)
{
	//DB 접속 요청 
	if (wb_DBConnect(ID, PW) == FALSE)
	{
		MessageBox(0, TEXT("접속 오류"), TEXT("DB연결"), MB_OK);
		SendMessage(hDlg, WM_CLOSE, 0, 0);
	}
}

void con_Exit(HWND hDlg)
{
	//DB연결 해제
	wb_DBDisConnect();

	EndDialog(hDlg, IDCANCEL);
}


void con_InsertAccount(HWND hDlg)
{
	TCHAR name[20];
	int money;

	GetDlgItemText(hDlg, IDC_EDIT2, name, sizeof(name));
	money = GetDlgItemInt(hDlg, IDC_EDIT3, 0, 0);

	//DB insert요청
	int id = wb_InsertAccout(name, money);
	if (id == 0)
	{
		MessageBox(0, TEXT("insert오류"), TEXT("알림"), MB_OK);
	}
	else
	{
		SetDlgItemInt(hDlg, IDC_EDIT1, id, 0);
	}
}