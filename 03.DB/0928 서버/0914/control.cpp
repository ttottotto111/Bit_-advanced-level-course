//control.cpp

#include "std.h"

#define DB_ID TEXT("ksw")
#define DB_PW TEXT("1111")

void con_init()
{

	sock_LibInit();
	sock_CreateSocket();
	if (wb_DBConnect(DB_ID, DB_PW) == FALSE)
	{
		printf("DB���� ����");
		exit(0);
	}
	printf("DB���� ����\n\n");
}

void con_run()
{
	printf("���� ���� ���̴�(61.81.98.100:9000).....\n");
	unsigned int hthread = _beginthreadex(0, 0, sock_ListenThread, 0, 0, 0);

	WaitForSingleObject((HANDLE)hthread, INFINITE);
	CloseHandle((HANDLE)hthread);
}

void con_exit()
{
	wb_DBDisConnect();
	sock_LibExit();
}

//Ŭ���̾�Ʈ���� ���� ������ -=============================
void con_RecvData(char* buf, int *size)
{
	int *flag = (int*)buf;	//????
	if (*flag == PACK_INSERTACCOUNT)
	{
		RecvInsertAccount((PACK_ACCOUNTINFO*)buf);
		*size = sizeof(PACK_ACCOUNTINFO);
	}
	else if (*flag == PACK_SELECTNAMETOID)
	{
		RecvSelectNameToId((PACK_GETNAME*)buf);
		*size = sizeof(PACK_GETNAME);
	}
	else if (*flag == PACK_SELECTACCOUNT)
	{
		RecvSelectAccount((PACK_ACCOUNTINFO*)buf);
		*size = sizeof(PACK_ACCOUNTINFO);
	}
}

//Ŭ���̾�Ʈ���� ���� ������ ó�� �ڵ�(������)
void RecvInsertAccount(PACK_ACCOUNTINFO* accinfo)
{
	//�����͸� ȹ��
	ACCOUNT acc;
	_tcscpy_s(acc.name, _countof(acc.name), accinfo->name);
	acc.balance = accinfo->balance;

	//DB�� ����
	//���� ���й߻��� ���� ���� ��Ŷ ����
	if (wb_dbInsertAccount(&acc) == TRUE)
	{
		accinfo->flag = ACK_INSERTACCOUNT_S;
		accinfo->id = acc.id;
		GetLocalTime(&accinfo->stime);
		
	}
	else
	{
		accinfo->flag = ACK_INSERTACCOUNT_F;
		accinfo->id = acc.id;
		GetLocalTime(&accinfo->stime);
	}

	//Ŭ���̾�Ʈ�� ����
	//�Լ� ���ϰ������� �ڵ����� �߻�
}

void RecvSelectNameToId(PACK_GETNAME* accdata)
{
	if (wb_dbSelectNameToId(accdata) == TRUE)
	{
		accdata->flag = ACK_SELECTNAMETOID_S;

	}
	else
	{
		accdata->flag = ACK_SELECTNAMETOID_F;
	}
}

void RecvSelectAccount(PACK_ACCOUNTINFO* accinfo)
{
	//���� ���й߻��� ���� ���� ��Ŷ ����
	if (wb_dbSelectAccount(accinfo) == TRUE)
	{
		accinfo->flag = ACK_SELECTACCOUNT_S;
	}
	else
	{
		accinfo->flag = ACK_SELECTACCOUNT_F;
	}

	//Ŭ���̾�Ʈ�� ����
	//�Լ� ���ϰ������� �ڵ����� �߻�
}