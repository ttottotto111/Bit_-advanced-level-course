#include <iostream>
using namespace std;
#include <Windows.h>

#define WM_MESSAGE		WM_USER+100	//  wParam : x��ǥ, lParam : y��ǥ
#define WM_RECTANGLE	WM_USER+101	//  wParam : RGB��,  lParam : ��ǥ
#define WM_ELLIPSE		WM_USER+102	//  wParam : RGB��,  lParam : ��ǥ
#define WM_LINE			WM_USER+103 //  wParam : RGB��, lParam : ��ǥ

int main()
{
	getchar();

	HWND hwnd = FindWindow(0, TEXT("Hello"));
	if (hwnd == 0)
	{
		cout << "Hello ���� ����" << endl;
		return 0;
	}

	int idx;
	while (true)
	{
		cout << "Ÿ�� ����(1 : �޽��� , 2 : �簢��,  3 : Ÿ��  4 : ��,   5 : ����)" << endl;
		cin >> idx;

		if (idx == 1)
		{
			int x, y;
			cout << "x��ǥ : ";  cin >> x;
			cout << "y��ǥ : ";  cin >> y;
			SendMessage(hwnd, WM_MESSAGE, x, y);
		}
		else if (idx == 2)
		{
			int r, g, b;
			int x, y;
			cout << "����(r) : ";  cin >> r;
			cout << "����(g) : ";  cin >> g;
			cout << "����(b) : ";  cin >> b;

			cout << "x��ǥ : ";  cin >> x;
			cout << "y��ǥ : ";  cin >> y;

			COLORREF color = RGB(r, g, b);
			int point = MAKELONG(x, y);

			SendMessage(hwnd, WM_RECTANGLE, (WPARAM)color, (LPARAM)point);
		}
		else if (idx == 3)
		{
			int r, g, b;
			int x, y;
			cout << "����(r) : ";  cin >> r;
			cout << "����(g) : ";  cin >> g;
			cout << "����(b) : ";  cin >> b;

			cout << "x��ǥ : ";  cin >> x;
			cout << "y��ǥ : ";  cin >> y;

			COLORREF color = RGB(r, g, b);
			int point = MAKELONG(x, y);

			SendMessage(hwnd, WM_ELLIPSE, (WPARAM)color, (LPARAM)point);
		}
		else if (idx == 4)
		{
			int r, g, b;
			int x, y;
			cout << "����(r) : ";  cin >> r;
			cout << "����(g) : ";  cin >> g;
			cout << "����(b) : ";  cin >> b;

			cout << "x��ǥ : ";  cin >> x;
			cout << "y��ǥ : ";  cin >> y;

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
			cout << "�߸� �Է�" << endl;
		}
	}

	return 0;
}