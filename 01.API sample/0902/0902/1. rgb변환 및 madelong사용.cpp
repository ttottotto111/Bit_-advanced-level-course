#include <iostream>
using namespace std;
#include <Windows.h>

//RGB
void exam1()
{
	//������ ���� ���������� ǥ��..(4byte)
	//RGB ��ũ�δ� ����Ÿ���� ������ ��ġ�� RGB���� ��ġ�� �ִ� ��ũ����
	//COLORREF -> DWORD -> unsinged long
	COLORREF color = RGB(255, 0, 255);

	int temp = (int)color;
	cout << temp << endl;  //16711935

	COLORREF color1 = (COLORREF)temp;
}

//MAKELONG
void exam2()
{
	int xy = MAKELONG(200, 300);  // x��ǥ 200,  y��ǥ 300
	cout << xy << endl;

	//�ٽ� �������1
	POINTS pt = MAKEPOINTS(xy);
	cout << pt.x << ", " << pt.y << endl;

	//�ٽ� �������2
	int x = LOWORD(xy);		//xy �� �� ���� 2byte �޶�
	int y = HIWORD(xy);		//xy �� �� ���� 2byte �޶�
	cout << x << ", " << y << endl;
}

int main()
{
	exam2();

	return 0;
}