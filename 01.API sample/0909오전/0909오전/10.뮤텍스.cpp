//���ؽ�
#pragma comment (linker, "/subsystem:console")

#include <windows.h>
#include <iostream>
using namespace std;

int main()
{
	// ���ؽ� ���� 
	// ����, ������ ��ü�� �ٽ� Create�ϰ� �Ǹ�, Open���� �������ش�.

	HANDLE hMutex = CreateMutex(NULL, // ���ȼӼ�
		FALSE, // ������ ���ؽ� ���� ����
		TEXT("mutex")); // �̸�

// ������ ture�϶� -> Signal �� nonsignal�� �ٲ۴�.
	cout << "���ý��� ��ٸ��� �ִ�." << endl;

	//WaitFor �� �����ϸ� �ش� ��ü�� ���°��� non-S  ����
	DWORD d = WaitForSingleObject(hMutex, INFINITE); // ���
	if (d == WAIT_TIMEOUT)
		MessageBox(NULL, TEXT("WAIT_TIMEOUT"), TEXT(""), MB_OK);
	else if (d == WAIT_OBJECT_0)
		MessageBox(NULL, TEXT("WAIT_OBJECT_0"), TEXT(""), MB_OK);
	else if (d == WAIT_ABANDONED_0)
		MessageBox(NULL, TEXT("WAIT_ABANDONED_0"), TEXT(""), MB_OK);

	cout << "���ý� ȹ��" << endl;

	MessageBox(NULL, TEXT("���ý��� ���´�."), TEXT(""), MB_OK);
	ReleaseMutex(hMutex);

	return 0;
}