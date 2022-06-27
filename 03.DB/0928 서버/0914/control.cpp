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
		printf("DB연결 오류");
		exit(0);
	}
	printf("DB연결 성공\n\n");
}

void con_run()
{
	printf("서버 실행 중이다(61.81.98.100:9000).....\n");
	unsigned int hthread = _beginthreadex(0, 0, sock_ListenThread, 0, 0, 0);

	WaitForSingleObject((HANDLE)hthread, INFINITE);
	CloseHandle((HANDLE)hthread);
}

void con_exit()
{
	wb_DBDisConnect();
	sock_LibExit();
}

//클라이언트에서 보낸 데이터 -=============================
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

//클라이언트에서 보낸 데이터 처리 코드(시작점)
void RecvInsertAccount(PACK_ACCOUNTINFO* accinfo)
{
	//데이터를 획득
	ACCOUNT acc;
	_tcscpy_s(acc.name, _countof(acc.name), accinfo->name);
	acc.balance = accinfo->balance;

	//DB에 저장
	//성공 실패발생에 따라 응답 패킷 생성
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

	//클라이언트로 전송
	//함수 리턴과정에서 자동으로 발생
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
	//성공 실패발생에 따라 응답 패킷 생성
	if (wb_dbSelectAccount(accinfo) == TRUE)
	{
		accinfo->flag = ACK_SELECTACCOUNT_S;
	}
	else
	{
		accinfo->flag = ACK_SELECTACCOUNT_F;
	}

	//클라이언트로 전송
	//함수 리턴과정에서 자동으로 발생
}