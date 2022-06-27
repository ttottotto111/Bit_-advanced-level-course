//packet.h

#pragma once


//클라이언트 -> 서버
#define	 PACK_TEXTMESSAGE	31
#define  PACK_SHORTMESSAGE  32

//서버 -> 클라이언트
#define  ACK_TEXTMESSAGE	41		
#define  ACK_SHORTMESSAGE	42

/*
모든 패킷 구조체의 첫번째 맴버는 4byte의 flag이다.
*/
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
