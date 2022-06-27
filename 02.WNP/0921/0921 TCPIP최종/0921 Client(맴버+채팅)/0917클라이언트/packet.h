//packet.h

#pragma once

//클라이언트 -> 서버
//맴버기능
#define	 PACK_NEWMEMBER		1		//MEMBER	: 전체 정보 전송
#define  PACK_LOGIN			2		//LOGIN		: ID, PW 전송
#define	 PACK_LOGOUT		3		//LOGIN		: ID만 전송
#define  PACK_DELETEMEMBER  4		//LOGIN		: ID만 전송
//채팅기능
#define	 PACK_TEXTMESSAGE	31
#define  PACK_SHORTMESSAGE  32

//서버 -> 클라이언트
//맴버 기능
#define  ACK_NEWMEMBER_S	11		//MEMBER	: 클라이언트 정보 그대로 전송
#define  ACK_NEWMEMBER_F	12		//MEMBER	: 클라이언트 정보 그대로 전송
#define  ACK_LOGIN_S		13		//LOGIN		: ID, 이름 전송
#define  ACK_LOGIN_F		14		//LOGIN		: 클라이언트 정보 그대로 전송
#define	 ACK_LOGOUT_S		15		//LOGIN	    : ID, 이름 전송
#define	 ACK_LOGOUT_F		16		//LOGIN	    : 클라이언트 정보 그대로 전송
#define  ACK_DELETEMEMBER_S	17		//LOGIN	    : ID, 이름 전송
#define  ACK_DELETEMEMBER_F	18		//LOGIN	    : 클라이언트 정보 그대로 전송
//채팅기능
#define  ACK_TEXTMESSAGE	41		
#define  ACK_SHORTMESSAGE	42
/*
모든 패킷 구조체의 첫번째 맴버는 4byte의 flag이다.
*/
//회원가입 패킷 구조체
typedef struct tagMEMBER
{
	int  flag;
	TCHAR id[20];
	TCHAR pw[20];
	TCHAR name[20];
	int  age;
}MEMBER;

//로그인 패킷 구조체 
typedef struct tagLOGIN
{
	int  flag;
	TCHAR id[20];
	TCHAR pw_name[20];	//pw 전달
	int  age;
}LOGIN;

void pack_SetNewMember(MEMBER *pmem);
void pack_SetLogin(LOGIN *plogin);
void pack_SetLogOut(LOGIN *plogout);


//copy & past 패킷 구조체
typedef struct tagCOPYPASTMSG
{
	int  flag;
	char id[20];
	char name[20];
	char msg[800];
	SYSTEMTIME dt;
}COPYPASTMSG;

//short 패킷 구조체 
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

