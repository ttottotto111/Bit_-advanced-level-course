//shape.h
#pragma once

#include <Windows.h>

typedef struct tagSHAPE
{
	POINT pt;	//좌표
	int size;	//크기(25, 50, 75, 100)
	COLORREF b_color;	//브러쉬 색상
	COLORREF p_color;	//펜 색상
	int type;			//타입 (사각형, 타원, 삼각형)

}SHAPE;
