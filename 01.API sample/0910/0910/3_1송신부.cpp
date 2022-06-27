//WM_COPYDATA �۽ź�

#pragma comment (linker, "/subsystem:console")

#include <windows.h>
#include <stdio.h>

#define WM_MYMESSAGE WM_USER + 100 

int main()
{
	HWND hwnd = FindWindow(0, TEXT("B"));
	if (hwnd == 0)
	{
		printf("B �����츦 ���� ������ �ּ���\n");
		return 0;
	}

	char buf[256] = { 0 };
	while (true)
	{
		printf("B���� ������ �޼����� �Է��ϼ��� >> ");
		gets_s(buf, sizeof(buf)); // 1���Է� ?

		// �������� Pointer�� �����ϱ� ���� �޼��� - WM_COPYDATA
		COPYDATASTRUCT cds;
		cds.cbData = strlen(buf) + 1; // ������ data ũ��
		cds.dwData = 1; // �ĺ���
		cds.lpData = buf; // ������ Pointer
		SendMessage(hwnd, WM_MYMESSAGE, 0, (LPARAM)&cds);
	}

	return 0;
}
