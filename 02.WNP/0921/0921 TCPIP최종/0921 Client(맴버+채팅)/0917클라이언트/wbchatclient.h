//wbchatchilent.h
/*
1. 클라이언트는 로그인이 성공하면 Chat 서버에 접속
-> 언제? control 함수
-> 누구를 호출할까? wbchatclient함수 :sockc_CreateSocket

2. 클라이언트는 로그아웃하면 Chat 서버 연결 해제

3. short메시지 전송  -----------------> 멀티라인메시지 전송
-> 언제   : 전송버튼 클릭
-> 누구를 : sockc_Send()

4. short메시지 수신		--------------> 멀티라인수신
-> 어디서 : 
*/

#pragma once

void sockc_Close();
void sockc_CreateSocket();	// RcvThread 호출 
int sockc_Send(char *buf, int length);

unsigned int __stdcall CRecvThread(void * value);	//sock_RecvThread
int CRecv(SOCKET sock, char* buf);		//sock_Recv
int crecvn(SOCKET s, char *buf, int len, int flags);
