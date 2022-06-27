//packet.h

#pragma once


//클라이언트 -> 서버
#define	 PACK_NEWMEMBER		1
#define  PACK_LOGIN			2
#define  PACK_LOGOUT		3

//서버 -> 클라이언트
#define  ACK_NEWMEMBER_S	11		
#define  ACK_NEWMEMBER_F	12
#define  ACK_LOGIN_S		13
#define  ACK_LOGIN_F		14

/*
모든 패킷 구조체의 첫번째 맴버는 4byte의 flag이다.
*/
//회원가입 패킷 구조체
typedef struct tagMEMBER
{
	int  flag;
	char id[20];
	char pw[20];
	char name[20];
	int  age;
}MEMBER;

//로그인 패킷 구조체 
typedef struct tagLOGIN
{
	int  flag;
	char id[20];
	char pw_name[20];	//pw 전달
	int  age;
}LOGIN;
