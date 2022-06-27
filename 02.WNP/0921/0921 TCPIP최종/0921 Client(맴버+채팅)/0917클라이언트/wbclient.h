//wbclient.h
#pragma once

void sock_Close();
void sock_LibInit();
void sock_LibExit();

void sock_CreateSocket();	// RcvThread »£√‚ 
int sock_Send(char *buf, int length);

unsigned int __stdcall RecvThread(void * value);	//sock_RecvThread
int Recv(SOCKET sock, char* buf);		//sock_Recv
int recvn(SOCKET s, char *buf, int len, int flags);