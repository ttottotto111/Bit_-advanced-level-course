//member.h
#pragma once

#include <tchar.h>

typedef struct tagMEMBER
{
	int number;
	TCHAR name[20];
	TCHAR gender;
	TCHAR phone[20];

}MEMBER;


#define WM_APPLY_NAME WM_USER + 100
