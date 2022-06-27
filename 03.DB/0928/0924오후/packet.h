//packet.h
#pragma once

//클라이언트 -> 서버
#define PACK_INSERTACCOUNT		1	//계좌 생성
#define PACK_SELECTNAMETOID		2	//이름으로 계좌번호 검색
#define PACK_SELECTACCOUNT		3	//아이디로 계좌검색


//서버 -> 클라이언트
#define ACK_INSERTACCOUNT_S		51	
#define ACK_INSERTACCOUNT_F		52
#define ACK_SELECTNAMETOID_S	53	
#define ACK_SELECTNAMETOID_F	54
#define ACK_SELECTACCOUNT_S		55
#define ACK_SELECTACCOUNT_F		56

//패킷 구조체
//계좌생성 : flag, name, balance ==> id, stime을 추가해서 수신
typedef struct tagPack_ACCOUNTINFO
{
	int flag;
	int id;
	TCHAR name[20];
	int balance;
	SYSTEMTIME stime;
}PACK_ACCOUNTINFO;

PACK_ACCOUNTINFO pack_SetInsertAccount(const ACCOUNT *pacc);

PACK_ACCOUNTINFO pack_SetSelectAccount(int id);

typedef struct tagPACK_GETNAME
{
	int flag;
	TCHAR name[20];
	int count;
	int id[50];
}PACK_GETNAME;

PACK_GETNAME pack_SetSelectNameToId(TCHAR* name);