//¼Û½ÅÀÚ - CUI
#pragma comment (linker, "/subsystem:console")

#include <iostream>
using namespace std;
#include <Windows.h>

#define WM_MESSAGEADD  WM_USER+100
/*
int main()
{
	getchar();

	HWND  hwnd = FindWindow(0, TEXT("Hello"));
	if (hwnd == 0)
	{
		cout << "ÇÚµé È¹µæ ½ÇÆÐ" << endl;
		return 0;
	}

	int value = SendMessage(hwnd, WM_MESSAGEADD, 10, 20);

	cout << "È¹µæÇÑ °ª : " << value << endl;

	return 0;
}
*/


#define WM_MESSAGEDRAW WM_USER + 200
int main()
{

	HWND  hwnd = FindWindow(0, TEXT("Hello"));
	if (hwnd == 0)
	{
		cout << "ÇÚµé È¹µæ ½ÇÆÐ" << endl;
		return 0;
	}

	while (true)
	{
		int x, y;
		cout << "x ÁÂÇ¥ : ";  cin >> x;
		cout << "y ÁÂÇ¥ : ";  cin >> y;
		if (x == 0 || y == 0)
			break;

		SendMessage(hwnd, WM_MESSAGEDRAW, x, y);
	}

	return 0;

}