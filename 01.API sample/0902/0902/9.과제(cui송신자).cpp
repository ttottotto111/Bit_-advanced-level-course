#include <iostream>
using namespace std;
#include <windows.h>

#define WM_MSGPRINT WM_USER + 900

int main()
{
	getchar();

	HWND targethwnd = FindWindow(TEXT("First"), 0);
	if (targethwnd == 0)
	{
		MessageBox(0, TEXT("없다"), TEXT("알림"), MB_OK);
		return 0;
	}

	int idx;
	while (true)
	{
		cout << "1. 그림 그리기   2. 종료" << endl;
		cin >> idx;
		if (idx == 1) {
			SendMessage(targethwnd, WM_MSGPRINT, 0, 0);
		}
		else if (idx == 2) {
			break;
		}
	}
	return 0;
}

