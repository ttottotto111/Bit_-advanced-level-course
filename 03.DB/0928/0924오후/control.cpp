//control.cpp

#include "std.h"

HWND g_hDlg;

//서버로부터 수신된 데이터
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
	//Select(Name -> Account) 회신
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

	//서버로 전송
	PACK_ACCOUNTINFO acinfo = pack_SetInsertAccount(&acc);
	sock_Send((char*)&acinfo, sizeof(acinfo));

}
void AckInsertAccount_S(PACK_ACCOUNTINFO* pacc)
{
	TCHAR buf[50];
	wsprintf(buf, TEXT("계좌번호:%d\n이름:%s\n잔액:%d원\n일자:%02d/%02d/%02d\n"),
		pacc->id, pacc->name, pacc->balance,
		pacc->stime.wYear, pacc->stime.wMonth, pacc->stime.wDay);
	MessageBox(0, buf, TEXT("알림"), MB_OK);
}
void AckInsertAccount_F(PACK_ACCOUNTINFO* pacc)
{
	MessageBox(0, TEXT("계좌생성오류"), TEXT("알림"), MB_OK);
}

void con_SelectAccount(HWND hDlg)
{
	TCHAR name[20] = { 0 };
	ui_GetSelectName(hDlg, name);

	//서버로 전송	
	PACK_GETNAME acinfo = pack_SetSelectNameToId(name);
	sock_Send((char*)&acinfo, sizeof(acinfo));
}
void AckSelectNameToId_S(PACK_GETNAME* pacc)
{
	//콤보박스에 id값 저장
	ui_SetComboBox(pacc->count, pacc->id);
}
void AckSelectNameToId_F(PACK_GETNAME* pacc)
{
	MessageBox(0, TEXT("검색 오류"), TEXT("알림"), MB_OK);
}

void con_NotifyComboBox(HWND hDlg, WPARAM wParam)
{
	switch (HIWORD(wParam))
	{
		case CBN_SELCHANGE:
		{
			int id = ui_GetId(hDlg);
			//서버로 전송
			PACK_ACCOUNTINFO acinfo = pack_SetSelectAccount(id);
			sock_Send((char*)&acinfo, sizeof(PACK_ACCOUNTINFO));
			break;
		}

	}
}
void AckSelectNameToAccount_S(PACK_ACCOUNTINFO* pacc)
{
	//하단 경과출력창에 출력
	ui_SelectAccountPrint(pacc);
}
void AckSelectNameToAccount_F(PACK_ACCOUNTINFO* pacc)
{
	MessageBox(0, TEXT("검색 오류"), TEXT("알림"), MB_OK);
}