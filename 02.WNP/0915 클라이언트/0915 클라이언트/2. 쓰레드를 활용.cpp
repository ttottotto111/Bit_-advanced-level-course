//쓰레드를 활용한 Client 구조
// send는 메인에서 무한루프로 처리  recv는 2nd thread에서 무한루프로 처리
#include <stdio.h>
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>
#include <process.h>

#define SERVER_IP		"127.0.0.1" //(자신의 IP)   (IT센터) 61.81.98.100
#define SERVER_PORT		9000

void sock_LibInit();
void sock_LibExit();
void sock_CreateSocket();
void sock_Run();
int sock_Send(SOCKET sock, char* buf);
int sock_Recv(SOCKET sock, char* buf);

unsigned int __stdcall sock_RecvThread(void* value);

int fun_Input(char* buf);

SOCKET c_socket;

int main()
{
	sock_LibInit();

	//1. 소켓 생성 및 연결 
	sock_CreateSocket();

	//2. Thread생성 #include <process.h>
	unsigned int hthread = _beginthreadex(0, 0, sock_RecvThread, 0, 0, 0);
	CloseHandle((HANDLE)hthread);

	//2. 통신 
	sock_Run();

	sock_LibExit();
	return 0;
}

void sock_LibInit()
{
	WSADATA wsa;
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("윈도우 소켓 초기화 실패!\n");
		exit(0);	//프로그램 종료
	}
}

void sock_LibExit()
{
	WSACleanup();
}

void sock_CreateSocket()
{
	//1. 소켓 생성 
	c_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (c_socket == INVALID_SOCKET)
	{
		printf("소켓 생성 에러\n");
		exit(0);
	}

	//2. 서버 연결
	//연결 주소(서버의 주소)를 설정
	SOCKADDR_IN serveraddr;
	ZeroMemory(&serveraddr, sizeof(serveraddr));
	serveraddr.sin_family = AF_INET;
	serveraddr.sin_port = htons(SERVER_PORT);
	//	serveraddr.sin_addr.s_addr = inet_addr(SERVER_IP);
	char buf[50] = SERVER_IP;
	inet_pton(AF_INET, buf, (SOCKADDR*)&serveraddr.sin_addr);

	//서버에 접속 요청
	int retval = connect(c_socket, (SOCKADDR*)&serveraddr, sizeof(serveraddr));
	// 통신 소켓(성공하면 자동으로 지역포트, 지역주소를 할당)
	if (retval == SOCKET_ERROR)
	{
		printf("서버 연결실패\n");
		exit(0);
	}

	printf("서버 연결 성공\n");
}

void sock_Run()
{
	char buf[1024];
	while (true)
	{
		if (fun_Input(buf) == 0)
			break;

		if (sock_Send(c_socket, buf) == 0)
			break;
	}

	closesocket(c_socket);
}

int fun_Input(char* buf)
{
	ZeroMemory(buf, 1024);
	//	printf("[문자열 입력] ");
	gets_s(buf, 1024);
	if (strlen(buf) == 0)		//소켓 종료
		return 0;
	else
		return 1;
}

int sock_Send(SOCKET sock, char* buf)
{
	// 서버에 데이터 보내기
	int retval = send(c_socket, buf, strlen(buf), 0);
	if (retval == SOCKET_ERROR)
	{
		printf("전송 오류 : 서버가 죽었을때\n");
		return 0;
	}
	printf("%d바이트를 전송, %s\n", retval, buf);
	return retval;
}

int sock_Recv(SOCKET sock, char* buf)
{
	int retval;
	int buf_size = 1024;

	retval = recv(sock, buf, buf_size, 0);
	if (retval == SOCKET_ERROR) // -1
	{
		printf("소켓 비정상 종료-상대방이 프로그램을 강제로 종료했을 경우\n");
		return 0;
	}
	else if (retval == 0)
	{
		printf("소켓 정상 종료-상대방이 closesocket함수를 호출했을 경우");
		return 0;
	}
	else
	{
		buf[retval] = '\0';
		printf("[수신데이터] %s\n", buf);
		//==================================================================
		return 1;
	}
}


unsigned int __stdcall sock_RecvThread(void* value)
{
	char buf[1024];

	while (true)
	{
		if (sock_Recv(c_socket, buf) == 0)
			break;
		printf("\n\n");
	}

	closesocket(c_socket);

	return 0;
}