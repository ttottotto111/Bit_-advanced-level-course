//shape.h
#pragma once

#include <Windows.h>

typedef struct tagSHAPE
{
	POINT pt;	//��ǥ
	int size;	//ũ��(25, 50, 75, 100)
	COLORREF b_color;	//�귯�� ����
	COLORREF p_color;	//�� ����
	int type;			//Ÿ�� (�簢��, Ÿ��, �ﰢ��)

}SHAPE;
