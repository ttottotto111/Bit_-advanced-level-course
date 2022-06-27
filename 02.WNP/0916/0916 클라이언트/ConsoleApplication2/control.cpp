//control.cpp

#include "std.h"


void con_init()
{
	sock_LibInit();
	sock_CreateSocket();
}

void con_exit()
{
	sock_LibExit();
}


//클라이언트 --> 서버
void con_netmember()
{
	MEMBER  mem;

	printf(">> 아이디 : ");
	gets_s(mem.id, sizeof(mem.id));

	printf(">> 패스워드 : ");
	gets_s(mem.pw, sizeof(mem.pw));

	printf(">> 이름 : ");
	gets_s(mem.name, sizeof(mem.name));

	printf(">> 나이 : ");
	scanf_s("%d", &mem.age);

	getchar();

	//서버로 전송
	pack_SetNewMember(&mem);
	sock_Send((char*)&mem, sizeof(mem));

	printf("서버로 회원가입 정보를 보냈습니다.\n");
}

void con_login()
{
	LOGIN  login;

	printf(">> 아이디 : ");
	gets_s(login.id, sizeof(login.id));

	printf(">> 패스워드 : ");
	gets_s(login.pw_name, sizeof(login.pw_name));

	getchar();

	//검색 --> 서버로 전송
	pack_SetLogin(&login);
	sock_Send((char*)&login, sizeof(login));

	printf("서버로 로그인 정보를 보냈습니다.\n");
}

void con_logout()
{
	LOGIN  logout;

	printf(">> 아이디 : ");
	gets_s(logout.id, sizeof(logout.id));

	getchar();

	pack_SetLogout(&logout);
	sock_Send((char*)&logout, sizeof(logout));

	printf("서버로 로그아웃 정보를 보냈습니다.\n");
}


//서버 --> 클라이언트
void con_RecvData(char* buf)
{
	LOGIN login;
	int* flag = (int*)buf;
	if (*flag == ACK_NEWMEMBER_S)
	{
		MessageBox(0, TEXT("회원가입성공"),TEXT("알림"), MB_OK);
	}
	if (*flag == ACK_NEWMEMBER_F)
	{
		MessageBox(0, TEXT("중복된 ID"), TEXT("알림"), MB_OK);
	}
	if (*flag == ACK_LOGIN_S)
	{
		MessageBox(0, TEXT("로그인 되었습니다."), TEXT("알림"), MB_OK);
	}
	if (*flag == ACK_LOGIN_F)
	{
		MessageBox(0, TEXT("로그아웃 되었습니다."), TEXT("알림"), MB_OK);
	}
}