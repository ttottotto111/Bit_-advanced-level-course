#pragma comment (linker, "/subsystem:console")

#include <iostream>
#include <windows.h>
using namespace std;
#include <conio.h>

void main()
{
	HANDLE hEvent = CreateEvent(NULL, // ���ȼӼ�
		TRUE, // ��������(TRUE), �ڵ�����(FALSE)
		FALSE, // �ʱ� ����( NON SIGNAL )
		TEXT("e")); // ������ �̺�Ʈ �̸�

/*
AUTO RESET : WaitForSingleObjecct�� ����ϴ� ����
Signal => NonSignal�� ������� ��.
MANUAL RESET : WaitForSingleObject�� ��ȭ�ϴ���
Signal ���¸� ��� ������..
=> ��ٸ��� ��������� �� �����ִ� ����..
*/

	cout << "Event�� ��ٸ���." << endl;
	WaitForSingleObject(hEvent, INFINITE);
	cout << "Event ȹ�� " << endl;
	cout << "Event�� ��ٸ���." << endl;
	WaitForSingleObject(hEvent, INFINITE);
	cout << "Event ȹ��" << endl;
	CloseHandle(hEvent);

	system("pause");
}