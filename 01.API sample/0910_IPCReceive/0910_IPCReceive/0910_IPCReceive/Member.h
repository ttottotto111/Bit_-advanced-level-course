#pragma once
#include<Windows.h>
#include<tchar.h>
#include<vector>
#include <commctrl.h>		//listview
#include"resource.h"
#include "handler.h"
#include"fun.h"


using namespace std;

typedef struct tagMEMBER
{
	int id;
	TCHAR name[20];
	CHAR gender;
	TCHAR phone[20];
}MEMBER;