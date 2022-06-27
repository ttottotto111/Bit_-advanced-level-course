#include <iostream>
using namespace std;
#include <Windows.h>

//RGB
void exam1()
{
	//색상은 양의 정수값으로 표현..(4byte)
	//RGB 매크로는 정수타입의 적절한 위치에 RGB값을 배치해 주는 매크로임
	//COLORREF -> DWORD -> unsinged long
	COLORREF color = RGB(255, 0, 255);

	int temp = (int)color;
	cout << temp << endl;  //16711935

	COLORREF color1 = (COLORREF)temp;
}

//MAKELONG
void exam2()
{
	int xy = MAKELONG(200, 300);  // x좌표 200,  y좌표 300
	cout << xy << endl;

	//다시 복원방법1
	POINTS pt = MAKEPOINTS(xy);
	cout << pt.x << ", " << pt.y << endl;

	//다시 복원방법2
	int x = LOWORD(xy);		//xy 값 중 하위 2byte 달라
	int y = HIWORD(xy);		//xy 값 중 상위 2byte 달라
	cout << x << ", " << y << endl;
}

int main()
{
	exam2();

	return 0;
}