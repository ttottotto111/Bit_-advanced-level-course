//data.h
#pragma once

#include <Windows.h>

typedef struct tagDATA
{
	int type;		//1 : 사각형 2: 타원
	int x;
	int y;

	COLORREF color;
}DATA;

//사용자 정의 메시지
#define WM_APPLY_POSITION	WM_USER+100
#define WM_APPLY_COLOR		WM_USER+200
