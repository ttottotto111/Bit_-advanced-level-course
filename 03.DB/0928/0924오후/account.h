//account.h
#pragma once

typedef struct tagACCOUNT
{
	int id;
	TCHAR name[20];
	int balance;
	SYSTEMTIME stime;
}ACCOUNT;