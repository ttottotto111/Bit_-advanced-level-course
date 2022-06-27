//wbclient.cpp

#include "std.h"

#define SERVER_IP		"61.81.98.100" //(자신의 IP)127.0.0.1   (IT센터) 61.81.98.100
#define SERVER_PORT		9000

SOCKET c_socket;

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
		MessageBox(0, TEXT("서버 연결실패\n프로그램을 종료합니다"),
			TEXT("알림"), MB_OK);
		exit(0);
	}

	printf("서버 연결 성공\n");
	unsigned int hthread = _beginthreadex(0, 0, RecvThread, 0, 0, 0);
	CloseHandle((HANDLE)hthread);
}

int sock_Send(char* buf, int length)
{
	// 서버에 데이터 보내기
	//1. 헤더(본 데이터 크기)
	int size = length;
	int retval = send(c_socket, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR)
	{
		printf("전송 오류 : 서버가 죽었을때\n");
		return 0;
	}

	//2. 본데이터
	retval = send(c_socket, buf, size, 0);
	if (retval == SOCKET_ERROR)
	{
		printf("전송 오류 : 서버가 죽었을때\n");
		return 0;
	}
	printf("%d바이트를 전송, %s\n", retval, buf);
	return retval;
}

int Recv(SOCKET sock, char* buf)
{
	int retval;

	//1. 헤더
	int size;
	retval = recvn(sock, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("소켓  종료\n");
		return 0;
	}

	//2. 본데이터
	retval = recvn(sock, buf, size, 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("소켓  종료\n");
		return 0;
	}
	else
	{
		//buf[retval] = '\0';
		//printf("[수신데이터] %s\n", buf);
		//==================================================================
		return 1;
	}
}

int recvn(SOCKET s, char* buf, int len, int flags)
{
	int received;
	char* ptr = buf;
	int left = len;
	while (left > 0) {
		received = recv(s, ptr, left, flags);
		if (received == SOCKET_ERROR)
			return SOCKET_ERROR;
		else if (received == 0)
			break;
		left -= received;
		ptr += received;
	}
	return (len - left);
}

unsigned int __stdcall RecvThread(void* value)
{
	char buf[1024];

	while (true)
	{
		if (Recv(c_socket, buf) == 0)
			break;

		//수신성공 시작위치
		con_RecvData(buf);
	}

	closesocket(c_socket);

	return 0;
}