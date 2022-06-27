//app.cpp

#include "std.h"


void app_init()
{
	con_init();
	logo();
}


void app_run()
{
	while (1)
	{
		system("cls");
		
		menuprint();
		char ch = _getch();		//#include <conio.h>
		switch (ch)
		{
		case '1':	con_netmember();		break;
		case '2':	con_login();			break;
		case '3':	con_logout();			break;
		case '4':   return;		// 함수를 종료 키워드 
		}
		system("pause");
	}
}

void app_exit()
{
	ending();
	con_exit();
}

void logo()
{
	system("cls");	//화면 지우기 #include <stdlib.h>
	printf("***************************************************\n");
	printf(" 과정명 : 비트 고급 32\n");
	printf(" 과  목 : Window Network Programming\n");
	printf(" 일  자 : 2020년 9월 16일\n");
	printf(" 내  용 : TCP/IP 기반 서버클라이언트 패킷 송수신\n");
	printf(" 구현자 : 홍길동\n");
	printf("***************************************************\n");
	system("pause");	//멈춤
}

void ending()
{
	system("cls");
	printf("***************************************************\n");
	printf("프로그램을 종료합니다.\n");
	printf("***************************************************\n");
	system("pause");
}

void menuprint()
{
	printf("***************************************************\n");
	printf(" [1] 회원가입(insert)\n");
	printf(" [2] 로그인(update)\n");
	printf(" [3] 로그아웃(update)\n");
	printf(" [4] 프로그램 종료\n");
	printf("***************************************************\n");
}
