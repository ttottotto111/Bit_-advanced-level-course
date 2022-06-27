//������ �����ϱ�
#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>	//����Ÿ�� ��������� h

int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrev, LPTSTR lpCmd, int nShow)
{
	// 1. ������ Ŭ���� ����� 
	WNDCLASS wc;
	wc.cbWndExtra = 0;		//������ �Ⱦ����� ���� Ȯ���� ����
	wc.cbClsExtra = 0;		//������ �Ⱦ����� ���� Ȯ���� ����

	//GetStockObject : �����ڴ�. �̸� ������� ��ü��...
	//				   ��, �귯��, ��Ʈ
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);

	//ù��° ���ڰ� ���� �ִ� �ι�° ���ڷ� ���޵� ID���ҽ��� �������ڴ�.
	//1���� : HINSTANCE 0? 0S
	wc.hCursor = LoadCursor(0, IDC_ARROW);
	wc.hIcon = LoadIcon(0, IDI_APPLICATION);

	//�� �ν��Ͻ� ���
	wc.hInstance = hInst;

	//�� �����쿡 �̺�Ʈ�� �߻��ϸ� �� �̺�Ʈ�� ó���� �Լ� ���
	//�����Ǵ� �̺�Ʈ ó���Լ� : ��� �����찡 ���������� ó���ϴ� ��� �����ִ�.
	wc.lpfnWndProc = DefWindowProc;			// DefWindowProc;

	//���� ��������� Ŭ���� �̸� -> KEY�� ���ȴ�. (��ҹ��� ���� ����)
	wc.lpszClassName = TEXT("First");

	//��Ÿ
	wc.lpszMenuName = 0;
	wc.style = 0;

	//2.��� (������Ʈ����)
	RegisterClass(&wc);

	// 3. ������ â ����� 
	HWND hwnd = CreateWindowEx(0,					// WS_EX_TOPMOST
		_TEXT("first"),					// Ŭ���� ��
		_TEXT("Hello"),					// ĸ�ǹ� ����
		WS_OVERLAPPEDWINDOW & ~WS_MAXIMIZEBOX,			//��Ÿ��
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,	// �ʱ� ��ġ -> ����x, ����y , ��, ����
		0, 0,			// �θ� ������ �ڵ�, �޴� �ڵ�
		hInst,		// WinMain�� 1��° �Ķ���� (exe �ּ�)
		0);			// ���� ����

	// 4. ������ �����ֱ�
	ShowWindow(hwnd, SW_SHOW);	//��ü�� �����ϴ� ù��° �Լ��� ���� ��.
	UpdateWindow(hwnd);

	MessageBox(0, TEXT("������ ����"), TEXT("Ÿ��Ʋ��"), MB_YESNO | MB_ICONQUESTION);

	MoveWindow(hwnd, 0, 0, 200, 200, FALSE);

	MessageBox(0, TEXT("����"), TEXT("Ÿ��Ʋ��"), MB_YESNO | MB_ICONQUESTION);

	return 0;
}