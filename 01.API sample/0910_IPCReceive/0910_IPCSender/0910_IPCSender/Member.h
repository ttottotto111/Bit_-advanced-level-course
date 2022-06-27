#pragma once

#include<Windows.h>
#include<tchar.h>


typedef struct tagMEMBER
{
	int id;
	TCHAR name[20];
	CHAR gender;
	TCHAR phone[20];
}MEMBER;