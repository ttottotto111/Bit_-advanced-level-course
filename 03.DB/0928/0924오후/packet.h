//packet.h
#pragma once

//Ŭ���̾�Ʈ -> ����
#define PACK_INSERTACCOUNT		1	//���� ����
#define PACK_SELECTNAMETOID		2	//�̸����� ���¹�ȣ �˻�
#define PACK_SELECTACCOUNT		3	//���̵�� ���°˻�


//���� -> Ŭ���̾�Ʈ
#define ACK_INSERTACCOUNT_S		51	
#define ACK_INSERTACCOUNT_F		52
#define ACK_SELECTNAMETOID_S	53	
#define ACK_SELECTNAMETOID_F	54
#define ACK_SELECTACCOUNT_S		55
#define ACK_SELECTACCOUNT_F		56

//��Ŷ ����ü
//���»��� : flag, name, balance ==> id, stime�� �߰��ؼ� ����
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