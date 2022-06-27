//packet.h

#pragma once

//Ŭ���̾�Ʈ -> ����
//�ɹ����
#define	 PACK_NEWMEMBER		1		//MEMBER	: ��ü ���� ����
#define  PACK_LOGIN			2		//LOGIN		: ID, PW ����
#define	 PACK_LOGOUT		3		//LOGIN		: ID�� ����
#define  PACK_DELETEMEMBER  4		//LOGIN		: ID�� ����
//ä�ñ��
#define	 PACK_TEXTMESSAGE	31
#define  PACK_SHORTMESSAGE  32

//���� -> Ŭ���̾�Ʈ
//�ɹ� ���
#define  ACK_NEWMEMBER_S	11		//MEMBER	: Ŭ���̾�Ʈ ���� �״�� ����
#define  ACK_NEWMEMBER_F	12		//MEMBER	: Ŭ���̾�Ʈ ���� �״�� ����
#define  ACK_LOGIN_S		13		//LOGIN		: ID, �̸� ����
#define  ACK_LOGIN_F		14		//LOGIN		: Ŭ���̾�Ʈ ���� �״�� ����
#define	 ACK_LOGOUT_S		15		//LOGIN	    : ID, �̸� ����
#define	 ACK_LOGOUT_F		16		//LOGIN	    : Ŭ���̾�Ʈ ���� �״�� ����
#define  ACK_DELETEMEMBER_S	17		//LOGIN	    : ID, �̸� ����
#define  ACK_DELETEMEMBER_F	18		//LOGIN	    : Ŭ���̾�Ʈ ���� �״�� ����
//ä�ñ��
#define  ACK_TEXTMESSAGE	41		
#define  ACK_SHORTMESSAGE	42
/*
��� ��Ŷ ����ü�� ù��° �ɹ��� 4byte�� flag�̴�.
*/
//ȸ������ ��Ŷ ����ü
typedef struct tagMEMBER
{
	int  flag;
	TCHAR id[20];
	TCHAR pw[20];
	TCHAR name[20];
	int  age;
}MEMBER;

//�α��� ��Ŷ ����ü 
typedef struct tagLOGIN
{
	int  flag;
	TCHAR id[20];
	TCHAR pw_name[20];	//pw ����
	int  age;
}LOGIN;

void pack_SetNewMember(MEMBER *pmem);
void pack_SetLogin(LOGIN *plogin);
void pack_SetLogOut(LOGIN *plogout);


//copy & past ��Ŷ ����ü
typedef struct tagCOPYPASTMSG
{
	int  flag;
	char id[20];
	char name[20];
	char msg[800];
	SYSTEMTIME dt;
}COPYPASTMSG;

//short ��Ŷ ����ü 
typedef struct tagSHORTMSG
{
	int  flag;
	char id[20];
	char name[20];
	char msg[100];
	SYSTEMTIME dt;
}SHORTMSG;

void pack_SetSendData(SHORTMSG *pmsg);
void pack_SetSendLongData(COPYPASTMSG *pmsg);

