//�����带 Ȱ���� ���� ���� ���� ����

#include <stdio.h>
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>
#include <process.h>	//thread ����� 

#define SERVER_PORT		9000

void sock_DisplayMessage();
void sock_LibInit();
void sock_LibExit();
void sock_CreateSocket();

unsigned int __stdcall sock_ListenThread(void* value);
unsigned int __stdcall sock_WorkThread(void* value);

SOCKET sock_Accept(SOCKADDR_IN* addr);
int sock_Recv(SOCKET sock, SOCKADDR_IN clientaddr, char* buf);
int sock_Send(SOCKET sock, const char* buf);

SOCKET listen_socket = 0;

int main()
{
	sock_LibInit();

	//1. ���� ����, �ּҼ���, ����
	sock_CreateSocket();

	//2. ListenThread ���� : ����ó�� ���� 
	unsigned int hthread = _beginthreadex(0, 0, sock_ListenThread, 0, 0, 0);

	//3. ListenThread�� �ױ⸦ ��ٷ��� �ȴ�. 
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
		printf("������ ���� �ʱ�ȭ ����!\n");
		exit(0);	//���α׷� ����
	}
}

void sock_LibExit()
{
	WSACleanup();
}

void sock_CreateSocket()
{
	//1. ���� ���� 
	listen_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (listen_socket == INVALID_SOCKET)
	{
		sock_DisplayMessage();
		exit(0);
	}

	//2. �ּ� ����
	int retval;

	SOCKADDR_IN serveraddr;
	ZeroMemory(&serveraddr, sizeof(serveraddr)); //1��°������ �ּҺ��� 2��° ����ũ��
												 // ��� ����Ʈ�� 0���� �ʱ�ȭ

	serveraddr.sin_family = AF_INET;				//�ּ�ü��
	serveraddr.sin_port = htons(SERVER_PORT);	//������Ʈ��ȣ
	serveraddr.sin_addr.s_addr = htonl(INADDR_ANY);	//����IP �ּ�

	retval = bind(listen_socket, (SOCKADDR*)&serveraddr, sizeof(serveraddr));
	if (retval == SOCKET_ERROR)
	{
		sock_DisplayMessage();
		exit(0);
	}


	//3. ����
	//���Ӵ�� ť�� ũ�� : TCP ���¸� LISTENING ����
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
	int addrlen = sizeof(clientaddr);		//�ݵ�� �ʱ�ȭ... 

											//1. ���� ó�� 
	printf("���� ���� ���̴�(61.81.98.100:9000).....\n");
	SOCKET sock = accept(listen_socket, (SOCKADDR*)&clientaddr, &addrlen);
	if (sock == SOCKET_ERROR)
	{
		printf("Ŭ���̾�Ʈ ���� ó�� ����\n");
		exit(0);
	}
	*addr = clientaddr;		//�ּҰ� ����.<==================================
							//2. ���� ��� ���
							//inset_ntoa : ���� -> ���ڿ��� ��ȯ(��Ʈ�p����Ʈ����->ȣ��Ʈ����Ʈ����)
	char buf[50];
	inet_ntop(AF_INET, &clientaddr.sin_addr, buf, sizeof(buf));

	printf("===================================================================\n");
	//	printf("Ŭ���̾�Ʈ ����: %s:%d\n",
	//		inet_ntoa(clientaddr.sin_addr), ntohs(clientaddr.sin_port));
	printf("Ŭ���̾�Ʈ ����: %s:%d\n", buf, ntohs(clientaddr.sin_port));
	printf("===================================================================\n");

	return sock;
}

int sock_Recv(SOCKET sock, SOCKADDR_IN clientaddr, char* buf)
{
	int retval;
	int buf_size = 1024;

	retval = recv(sock, buf, buf_size, 0);
	if (retval == SOCKET_ERROR) // -1
	{
		printf("���� ������ ����-������ ���α׷��� ������ �������� ���\n");
		return 0;
	}
	else if (retval == 0)
	{
		printf("���� ���� ����-������ closesocket�Լ��� ȣ������ ���");
		return 0;
	}
	else
	{
		//retval :  ��� IO�� ��ȯ���� IO��� byte ũ���̴�. 
		// ���� ������ ���=============================================
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
	// ������ ������ ������
	int retval = send(sock, buf, strlen(buf), 0);
	if (retval == SOCKET_ERROR)
	{
		printf("���� ���� : Ŭ���Ʈ�� �׾�����\n");
		return 0;
	}
	printf("%d����Ʈ�� ����, %s\n", retval, buf);
	return retval;
}


void sock_DisplayMessage()
{
	LPVOID pMsg;
	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER | // ���� �޽��� ���� �޸𸮸� ���ο��� �Ҵ��϶�
		FORMAT_MESSAGE_FROM_SYSTEM, //�ü���� ���� ���� �޽����� �����´�
		NULL,
		WSAGetLastError(), //���� �ڵ�
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), //���(������ ���� ���)
		(LPTSTR)&pMsg, // ���� �޽��� outparam : �����ڵ� 
		0, NULL);
	//================== �����ڵ� -> ��Ƽ����Ʈ ================================
	char wtoa[250];
	WideCharToMultiByte(CP_ACP, 0, (LPCWCH)pMsg, -1, wtoa, 250, NULL, NULL);
	//==========================================================================
	printf("%s\n", wtoa);// ���� �޽��� ��� : ��Ƽ����Ʈ 
	LocalFree(pMsg); // ���� �޽��� ���� �޸� ��ȯ
}


unsigned int __stdcall sock_ListenThread(void* value)
{
	while (true)
	{
		SOCKET sock;
		SOCKADDR_IN clientaddr;
		sock = sock_Accept(&clientaddr);

		//��� Thread ����
		unsigned int hthread = _beginthreadex(0, 0, sock_WorkThread, (void*)sock, 0, 0);
		CloseHandle((HANDLE)hthread);
	}

	return 0;
}

unsigned int __stdcall sock_WorkThread(void* value)
{
	//��������� ������ socket�� ���ؼ� ����� ���� �ּҸ� ���� �� �ִ�.
	//getpeername(����), getsockname(����)
	SOCKET sock = (SOCKET)value;
	SOCKADDR_IN clientaddr;
	int length = sizeof(clientaddr);
	getpeername(sock, (SOCKADDR*)&clientaddr, &length);

	char buf[1024];	//���Ź��� & �۽Ź���
					//2. ��ȭ(recv)	
	while (true)
	{
		// ������ �ޱ�====================================================
		if (sock_Recv(sock, clientaddr, buf) == 0)
			break;

		//���� �����͸� ����==============================================
		sock_Send(sock, buf);
	}

	//3. ����ó��
	closesocket(sock);				//��ż���

	return 0;
}