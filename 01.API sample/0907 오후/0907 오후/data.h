//data.h
#pragma once

#include <Windows.h>

typedef struct tagDATA
{
	int type;		//1 : �簢�� 2: Ÿ��
	int x;
	int y;

	COLORREF color;
}DATA;

//����� ���� �޽���
#define WM_APPLY_POSITION	WM_USER+100
#define WM_APPLY_COLOR		WM_USER+200
