//wbchatchilent.cpp

#include "std.h"

#define SERVER_IP		"127.0.0.1" //(자신의 IP)   (IT센터) 61.81.98.100
#define SERVER_PORT		8000

SOCKET cc_socket;

void sockc_Close()
{
	closesocket(cc_socket);
}

void sockc_CreateSocket()
{
	//1. 소켓 생성 
	cc_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (cc_socket == INVALID_SOCKET)
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
	int retval = connect(cc_socket, (SOCKADDR *)&serveraddr, sizeof(serveraddr));
	// 통신 소켓(성공하면 자동으로 지역포트, 지역주소를 할당)
	if (retval == SOCKET_ERROR)
	{
		MessageBox(0, TEXT("서버 연결실패\n프로그램을 종료합니다"),
			TEXT("알림"), MB_OK);
		exit(0);
	}

	printf("서버 연결 성공\n");
	unsigned int hthread = _beginthreadex(0, 0, CRecvThread, 0, 0, 0);
	CloseHandle((HANDLE)hthread);
}

int sockc_Send(char *buf, int length)
{
	// 서버에 데이터 보내기
	//1. 헤더(본 데이터 크기)
	int size = length;
	int retval = send(cc_socket, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR)
	{
		printf("전송 오류 : 서버가 죽었을때\n");
		return 0;
	}

	//2. 본데이터
	retval = send(cc_socket, buf, size, 0);
	if (retval == SOCKET_ERROR)
	{
		printf("전송 오류 : 서버가 죽었을때\n");
		return 0;
	}
	printf("%d바이트를 전송, %s\n", retval, buf);
	return retval;
}

unsigned int __stdcall CRecvThread(void * value)
{
	char buf[1024];

	while (true)
	{
		if (CRecv(cc_socket, buf) == 0)
			break;
		//=== 수신 성공 시작 위치 =============================
		//데이터 처리를 control에게 전달...
		con_RecvData(buf);	//<=======================================
	}

	closesocket(cc_socket);

	return 0;
}

int CRecv(SOCKET sock, char* buf)
{
	int retval;

	//1. 헤더
	int size;
	retval = crecvn(sock, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("소켓  종료\n");
		return 0;
	}

	//2. 본데이터
	retval = crecvn(sock, buf, size, 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("소켓  종료\n");
		return 0;
	}
	else
	{
		//		buf[retval] = '\0';
		//		printf("[수신데이터] %s\n", buf);
		//==================================================================
		return 1;
	}
}

int crecvn(SOCKET s, char *buf, int len, int flags)
{
	int received;
	char *ptr = buf;
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

