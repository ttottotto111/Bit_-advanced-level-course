//서버 관련 함수
#include <stdio.h>
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>

#define SERVER_PORT		9000

void sock_LibInit();
void sock_LibExit();
void sock_CreateSocket();
void sock_Run();

SOCKET listen_socket = 0;

int main()
{
	sock_LibInit();

	//1. 소켓 생성, 주소셋팅, 연결
	sock_CreateSocket();

	//2. 접속처리 및 통신 
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
	listen_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (listen_socket == INVALID_SOCKET)
	{
		printf("소켓 생성 에러\n");
		exit(0);
	}

	//2. 주소 연결
	int retval;

	SOCKADDR_IN serveraddr;
	ZeroMemory(&serveraddr, sizeof(serveraddr)); //1번째인자의 주소부터 2번째 인자크기
												// 모든 바이트를 0으로 초기화

	serveraddr.sin_family = AF_INET;				//주소체계
	serveraddr.sin_port = htons(SERVER_PORT);	//지역포트번호
	serveraddr.sin_addr.s_addr = htonl(INADDR_ANY);	//지역IP 주소

	retval = bind(listen_socket, (SOCKADDR*)&serveraddr, sizeof(serveraddr));
	if (retval == SOCKET_ERROR)
	{
		printf("주소값 에러\n");
		exit(0);
	}


	//3. 연결
	//접속대기 큐의 크기 : TCP 상태를 LISTENING 변경
	retval = listen(listen_socket, SOMAXCONN);
	// 
	if (retval == SOCKET_ERROR)
	{
		printf("연결 에러\n");
		exit(0);
	}
}

void sock_Run()
{
	SOCKADDR_IN clientaddr;
	int addrlen = sizeof(clientaddr);		//반드시 초기화... 

	//1. 접속 처리 
	printf("서버 실행 중이다(61.81.98.100:9000).....\n");
	SOCKET sock = accept(listen_socket, (SOCKADDR*)&clientaddr, &addrlen);
	if (sock == SOCKET_ERROR)
	{
		printf("클라이언트 접속 처리 에러\n");
		exit(0);
	}

	//2. 접속 결과 출력
	//inset_ntoa : 숫자 -> 문자열로 변환(네트웤바이트오더->호스트바이트오더)
	char buf[10];
	inet_ntop(AF_INET, &clientaddr.sin_addr, buf, sizeof(buf));

	printf("===================================================================\n");
	//	printf("클라이언트 접속: %s:%d\n",
	//		inet_ntoa(clientaddr.sin_addr), ntohs(clientaddr.sin_port));
	printf("클라이언트 접속: %s:%d\n", buf, ntohs(clientaddr.sin_port));
	printf("===================================================================\n");

	//3. 대화(recv)
	int retval;
	char recv_buf[1024];
	int  buf_size = sizeof(recv_buf);
	while (true)
	{
		// 데이터 받기
		retval = recv(sock, recv_buf, buf_size, 0);
		if (retval == SOCKET_ERROR)
		{
			printf("소켓 비정상 종료-상대방이 프로그램을 강제로 종료했을 경우\n");
			break;
		}
		else if (retval == 0)
		{
			printf("소켓 정상 종료-상대방이 closesocket함수를 호출했을 경우");
			break;
		}
		else
		{
			// 받은 데이터 출력
			char buf1[10];
			inet_ntop(AF_INET, &clientaddr.sin_addr, buf1, sizeof(buf1));

			recv_buf[retval] = '\0';
			printf("[TCP 서버] IP 주소=%s, 포트 번호=%d의 받은 메시지:%s\n",
				buf1, ntohs(clientaddr.sin_port), recv_buf);
		}

		closesocket(sock);				//통신소켓
		closesocket(listen_socket);		//리슨소켓
	}
}