#include <iostream>
using namespace std;
#include <Windows.h>

#define WM_MESSAGE		WM_USER+100	//  wParam : xÁÂÇ¥, lParam : yÁÂÇ¥
#define WM_RECTANGLE	WM_USER+101	//  wParam : RGB°ª,  lParam : ÁÂÇ¥
#define WM_ELLIPSE		WM_USER+102	//  wParam : RGB°ª,  lParam : ÁÂÇ¥
#define WM_LINE			WM_USER+103 //  wParam : RGB°ª, lParam : ÁÂÇ¥

int main()
{
	getchar();

	HWND hwnd = FindWindow(0, TEXT("Hello"));
	if (hwnd == 0)
	{
		cout << "Hello ¸ÕÀú ½ÇÇà" << endl;
		return 0;
	}

	int idx;
	while (true)
	{
		cout << "Å¸ÀÔ ¼±ÅÃ(1 : ¸Þ½ÃÁö , 2 : »ç°¢Çü,  3 : Å¸¿ø  4 : ¼±,   5 : Á¾·á)" << endl;
		cin >> idx;

		if (idx == 1)
		{
			int x, y;
			cout << "xÁÂÇ¥ : ";  cin >> x;
			cout << "yÁÂÇ¥ : ";  cin >> y;
			SendMessage(hwnd, WM_MESSAGE, x, y);
		}
		else if (idx == 2)
		{
			int r, g, b;
			int x, y;
			cout << "»ö»ó(r) : ";  cin >> r;
			cout << "»ö»ó(g) : ";  cin >> g;
			cout << "»ö»ó(b) : ";  cin >> b;

			cout << "xÁÂÇ¥ : ";  cin >> x;
			cout << "yÁÂÇ¥ : ";  cin >> y;

			COLORREF color = RGB(r, g, b);
			int point = MAKELONG(x, y);

			SendMessage(hwnd, WM_RECTANGLE, (WPARAM)color, (LPARAM)point);
		}
		else if (idx == 3)
		{
			int r, g, b;
			int x, y;
			cout << "»ö»ó(r) : ";  cin >> r;
			cout << "»ö»ó(g) : ";  cin >> g;
			cout << "»ö»ó(b) : ";  cin >> b;

			cout << "xÁÂÇ¥ : ";  cin >> x;
			cout << "yÁÂÇ¥ : ";  cin >> y;

			COLORREF color = RGB(r, g, b);
			int point = MAKELONG(x, y);

			SendMessage(hwnd, WM_ELLIPSE, (WPARAM)color, (LPARAM)point);
		}
		else if (idx == 4)
		{
			int r, g, b;
			int x, y;
			cout << "»ö»ó(r) : ";  cin >> r;
			cout << "»ö»ó(g) : ";  cin >> g;
			cout << "»ö»ó(b) : ";  cin >> b;

			cout << "xÁÂÇ¥ : ";  cin >> x;
			cout << "yÁÂÇ¥ : ";  cin >> y;

			COLORREF color = RGB(r, g, b);
			int point = MAKELONG(x, y);

			SendMessage(hwnd, WM_LINE, (WPARAM)color, (LPARAM)point);
		}
		else if (idx == 5)
		{
			break;
		}
		else
		{
			cout << "Àß¸ø ÀÔ·Â" << endl;
		}
	}

	return 0;
}