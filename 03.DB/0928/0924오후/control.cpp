//control.cpp

#include "std.h"

HWND g_hDlg;

//�����κ��� ���ŵ� ������
void con_RecvData(TCHAR* buf)
{
	int* flag = (int*)buf;
	if (*flag == ACK_INSERTACCOUNT_S)
	{
		AckInsertAccount_S((PACK_ACCOUNTINFO*)buf);
	}
	else if (*flag == ACK_INSERTACCOUNT_F)
	{
		AckInsertAccount_F((PACK_ACCOUNTINFO*)buf);
	}

	else if (*flag == ACK_SELECTNAMETOID_S)
	{
		AckSelectNameToId_S((PACK_GETNAME*)buf);
	}
	else if (*flag == ACK_SELECTNAMETOID_F)
	{
		AckSelectNameToId_F((PACK_GETNAME*)buf);
	}
	//Select(Name -> Account) ȸ��
	else if (*flag == ACK_SELECTACCOUNT_S)
	{
		AckSelectNameToAccount_S((PACK_ACCOUNTINFO*)buf);
	}
	else if (*flag == ACK_SELECTACCOUNT_F)
	{
		AckSelectNameToAccount_F((PACK_ACCOUNTINFO*)buf);
	}
}

void con_Init(HWND hDlg)
{
	g_hDlg = hDlg;
	sock_LibInit();
}

void con_Exit(HWND hDlg)
{
	sock_LibExit();
	EndDialog(hDlg, IDCANCEL);
}

void con_Connect(HWND hDlg)
{
	sock_CreateSocket();
}


void con_InsertAccount(HWND hDlg)
{
	ACCOUNT acc = { 0 };

	ui_GetAccount(hDlg, &acc);

	//������ ����
	PACK_ACCOUNTINFO acinfo = pack_SetInsertAccount(&acc);
	sock_Send((char*)&acinfo, sizeof(acinfo));

}
void AckInsertAccount_S(PACK_ACCOUNTINFO* pacc)
{
	TCHAR buf[50];
	wsprintf(buf, TEXT("���¹�ȣ:%d\n�̸�:%s\n�ܾ�:%d��\n����:%02d/%02d/%02d\n"),
		pacc->id, pacc->name, pacc->balance,
		pacc->stime.wYear, pacc->stime.wMonth, pacc->stime.wDay);
	MessageBox(0, buf, TEXT("�˸�"), MB_OK);
}
void AckInsertAccount_F(PACK_ACCOUNTINFO* pacc)
{
	MessageBox(0, TEXT("���»�������"), TEXT("�˸�"), MB_OK);
}

void con_SelectAccount(HWND hDlg)
{
	TCHAR name[20] = { 0 };
	ui_GetSelectName(hDlg, name);

	//������ ����	
	PACK_GETNAME acinfo = pack_SetSelectNameToId(name);
	sock_Send((char*)&acinfo, sizeof(acinfo));
}
void AckSelectNameToId_S(PACK_GETNAME* pacc)
{
	//�޺��ڽ��� id�� ����
	ui_SetComboBox(pacc->count, pacc->id);
}
void AckSelectNameToId_F(PACK_GETNAME* pacc)
{
	MessageBox(0, TEXT("�˻� ����"), TEXT("�˸�"), MB_OK);
}

void con_NotifyComboBox(HWND hDlg, WPARAM wParam)
{
	switch (HIWORD(wParam))
	{
		case CBN_SELCHANGE:
		{
			int id = ui_GetId(hDlg);
			//������ ����
			PACK_ACCOUNTINFO acinfo = pack_SetSelectAccount(id);
			sock_Send((char*)&acinfo, sizeof(PACK_ACCOUNTINFO));
			break;
		}

	}
}
void AckSelectNameToAccount_S(PACK_ACCOUNTINFO* pacc)
{
	//�ϴ� ������â�� ���
	ui_SelectAccountPrint(pacc);
}
void AckSelectNameToAccount_F(PACK_ACCOUNTINFO* pacc)
{
	MessageBox(0, TEXT("�˻� ����"), TEXT("�˸�"), MB_OK);
}