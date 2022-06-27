//쓰레드를 이용한 1대 다 통신(서버) - recvn 함수를 활용 

#include <stdio.h>
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>
#include <process.h>	//thread 선언부 
#include <vector>
using namespace std;

#define SERVER_PORT		9000

/*
저장시점 : 클라이언트가 접속했을 때
삭제시점 : 연결이 종료되었을 때
사용시점 : 데이터를 전송할 때
*/
vector<SOCKET> g_socklist;

void sock_DisplayMessage();
void sock_LibInit();
void sock_LibExit();
void sock_CreateSocket();

unsigned int __stdcall sock_ListenThread(void* value);
unsigned int __stdcall sock_WorkThread(void* value);

SOCKET sock_Accept(SOCKADDR_IN* addr);
int sock_Recv(SOCKET sock, SOCKADDR_IN clientaddr, char* buf);
int sock_Send(SOCKET sock, const char* buf);

int recvn(SOCKET s, char* buf, int len, int flags);

SOCKET listen_socket = 0;

int main()
{
	sock_LibInit();

	//1. 소켓 생성, 주소셋팅, 연결
	sock_CreateSocket();

	//2. ListenThread 생성 : 접속처리 역할 
	unsigned int hthread = _beginthreadex(0, 0, sock_ListenThread, 0, 0, 0);

	//3. ListenThread가 죽기를 기다려야 된다. 
	WaitForSingleObject((HANDLE)hthread, INFINITE);
	CloseHandle((HANDLE)hthread);

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
		sock_DisplayMessage();
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
		sock_DisplayMessage();
		exit(0);
	}


	//3. 연결
	//접속대기 큐의 크기 : TCP 상태를 LISTENING 변경
	retval = listen(listen_socket, SOMAXCONN);
	// 
	if (retval == SOCKET_ERROR)
	{
		sock_DisplayMessage();
		exit(0);
	}
}

SOCKET sock_Accept(SOCKADDR_IN* addr)
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
	*addr = clientaddr;		//주소값 복사.<==================================
							//2. 접속 결과 출력
							//inset_ntoa : 숫자 -> 문자열로 변환(네트웤바이트오더->호스트바이트오더)
	char buf[50];
	inet_ntop(AF_INET, &clientaddr.sin_addr, buf, sizeof(buf));

	printf("===================================================================\n");
	//	printf("클라이언트 접속: %s:%d\n",
	//		inet_ntoa(clientaddr.sin_addr), ntohs(clientaddr.sin_port));
	printf("클라이언트 접속: %s:%d\n", buf, ntohs(clientaddr.sin_port));
	printf("===================================================================\n");

	return sock;
}

int sock_Recv(SOCKET sock, SOCKADDR_IN clientaddr, char* buf)
{
	int retval;

	//1. 헤더 4byte를 읽는다.
	int size;
	retval = recvn(sock, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("소켓 연결 종료\n");
		return 0;
	}

	//2. 본데이터
	retval = recvn(sock, (char*)buf, size, 0);
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
		//retval :  모든 IO는 반환값이 IO결과 byte 크기이다. 
		// 받은 데이터 출력=============================================
		char buf1[50];
		inet_ntop(AF_INET, &clientaddr.sin_addr, buf1, sizeof(buf1));

		buf[retval] = '\0';
		printf("[%s:%d] %s\n", buf1, ntohs(clientaddr.sin_port), buf);
		//==================================================================
		return 1;
	}
}

int sock_Send(SOCKET sock, const char* buf)
{
	//1. 헤더(본 데이터 크기)
	int size = strlen(buf);
	int retval = send(sock, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR)
	{
		printf("전송 오류 : 서버가 죽었을때\n");
		return 0;
	}

	//2. 본데이터
	retval = send(sock, buf, size, 0);
	if (retval == SOCKET_ERROR)
	{
		printf("전송 오류 : 서버가 죽었을때\n");
		return 0;
	}
	printf("%d바이트를 전송, %s\n", retval, buf);
	return retval;
}

void sock_DisplayMessage()
{
	LPVOID pMsg;
	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER | // 오류 메시지 저장 메모리를 내부에서 할당하라
		FORMAT_MESSAGE_FROM_SYSTEM, //운영체제로 부터 오류 메시지를 가져온다
		NULL,
		WSAGetLastError(), //오류 코드
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), //언어(제어판 설정 언어)
		(LPTSTR)&pMsg, // 오류 메시지 outparam : 유니코드 
		0, NULL);
	//================== 유니코드 -> 멀티바이트 ================================
	char wtoa[250];
	WideCharToMultiByte(CP_ACP, 0, (LPCWCH)pMsg, -1, wtoa, 250, NULL, NULL);
	//==========================================================================
	printf("%s\n", wtoa);// 오류 메시지 출력 : 멀티바이트 
	LocalFree(pMsg); // 오류 메시지 저장 메모리 반환
}

unsigned int __stdcall sock_ListenThread(void* value)
{
	while (true)
	{
		SOCKET sock;
		SOCKADDR_IN clientaddr;
		sock = sock_Accept(&clientaddr);

		//생성된 통신 소켓 저장
		g_socklist.push_back(sock);

		//통신 Thread 생성
		unsigned int hthread = _beginthreadex(0, 0, sock_WorkThread, (void*)sock, 0, 0);
		CloseHandle((HANDLE)hthread);
	}

	return 0;
}

unsigned int __stdcall sock_WorkThread(void* value)
{
	//연결소켓이 있으면 socket을 통해서 상대방과 나의 주소를 얻을 수 있다.
	//getpeername(상대방), getsockname(나의)
	SOCKET sock = (SOCKET)value;
	SOCKADDR_IN clientaddr;
	int length = sizeof(clientaddr);
	getpeername(sock, (SOCKADDR*)&clientaddr, &length);

	char buf[1024];	//수신버퍼 & 송신버퍼
					//2. 대화(recv)	
	while (true)
	{
		// 데이터 받기====================================================
		if (sock_Recv(sock, clientaddr, buf) == 0)
			break;

		//받은 데이터를 전송==============================================
		for (int i = 0; i < (int)g_socklist.size(); i++)
		{
			SOCKET s = g_socklist[i];
			sock_Send(s, buf);
		}
	}

	//소켓 삭제 처리 
	for (int i = 0; i < (int)g_socklist.size(); i++)
	{
		SOCKET s = g_socklist[i];
		if (s == sock)
		{
			vector<SOCKET>::iterator itr = g_socklist.begin();
			g_socklist.erase(itr + i);
			break;
		}
	}

	//3. 종료처리
	closesocket(sock);				//통신소켓

	return 0;
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
