//control.cpp

#include "std.h"

#define ID		TEXT("ksw")
#define PW		TEXT("1111")

void con_Init(HWND hDlg)
{
	//DB ���� ��û 
	if (wb_DBConnect(ID, PW) == FALSE)
	{
		MessageBox(0, TEXT("���� ����"), TEXT("DB����"), MB_OK);
		SendMessage(hDlg, WM_CLOSE, 0, 0);
	}
}

void con_Exit(HWND hDlg)
{
	//DB���� ����
	wb_DBDisConnect();

	EndDialog(hDlg, IDCANCEL);
}


void con_InsertAccount(HWND hDlg)
{
	TCHAR name[20];
	int money;

	GetDlgItemText(hDlg, IDC_EDIT2, name, sizeof(name));
	money = GetDlgItemInt(hDlg, IDC_EDIT3, 0, 0);

	//DB insert��û
	int id = wb_InsertAccout(name, money);
	if (id == 0)
	{
		MessageBox(0, TEXT("insert����"), TEXT("�˸�"), MB_OK);
	}
	else
	{
		SetDlgItemInt(hDlg, IDC_EDIT1, id, 0);
	}
}