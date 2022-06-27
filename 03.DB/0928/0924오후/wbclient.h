//wbclient.h
#pragma once

/*
1. 초기화 과정에서 아래 함수 호출(ex : void con_Init(HWND hDlg))
   sock_LibInit();
2. 종료 과정에서 아래 함수 호출(ex : void con_Cancel(HWND hDlg))
   sock_LibExit();
3. 서버 접속 요청 함수 호출
   sock_CreateSocket();
--------------------------------------------------------------
4. 데이터 전송시 호출
   int sock_Send(char *buf, int length);
5. 연결 종료 요청
   sock_Close()
6. 데이터 수신시 처리(내가 수신할 위치에 함수를 정의)
	void con_RecvData(TCHAR *buf)
	{
	int *flag = (int*)buf;
	if (*flag == ACK_NEWMEMBER_S)
	{
	MessageBox(0, TEXT("회원가입성공"), TEXT("알림"), MB_OK);
	}
	else if (*flag == ACK_NEWMEMBER_F)
	{
	MEMBER *pmem = (MEMBER*)buf;
	//pmem->name
	MessageBox(0, TEXT("회원가입실패"), TEXT("알림"), MB_OK);
	}
*/



void sock_Close();
void sock_LibInit();
void sock_LibExit();

void sock_CreateSocket();	// RcvThread 호출 
int sock_Send(char* buf, int length);

unsigned int __stdcall RecvThread(void* value);	//sock_RecvThread
int Recv(SOCKET sock, char* buf);		//sock_Recv
int recvn(SOCKET s, char* buf, int len, int flags);