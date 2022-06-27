//API ù��° ���α׷�
#pragma comment (linker, "/subsystem:windows")
//#pragma comment (linker, "/subsystem:console")



/*
1) �޴� : ������Ʈ >> �Ӽ�
   �����Ӽ� >> �Ϲ� >> ���� ���� -> ��Ƽ����Ʈ ���� ����
   2019������ ��޿�....
   �����ڵ� ���� ����ü�谡 �⺻ ����.................

2) ȯ�濡 ���� �ٸ� �����Լ��� ã�´�.
   �ܼ� : main
   ��   : WinMain
   �޴� : ������Ʈ >> �Ӽ�
   ��Ŀ >> �ý��� >> �����ý��� -> ������ ����(subsystem:windows)
*/

#include <Windows.h>

//�����Լ��� main(CUI) -> WinMain(GUI)
//��Ƽ����Ʈ �ڵ� 
/*
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrev, LPSTR lpCmd, int nShow)
{

	return 0;
}
*/

//�����ڵ�(�⺻ Ű����� w : wide-�÷ȴ�)
/*
int WINAPI wWinMain(HINSTANCE hInst, HINSTANCE hPrev, LPWSTR lpCmd, int nShow)
{

	return 0;
}
*/

#include <tchar.h>
//����Ÿ�� : ��Ȳ�� ���� �����ڵ�� ��Ƽ����Ʈ �ڵ带 ������ ���
//����Ÿ�� (�⺻ Ű����� t)
int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrev, LPTSTR lpCmd, int nShow)
{
	/*
	���ڿ� ǥ���� c : const
	��Ƽ����Ʈ : LPSTR   -> LPCSTR      "test"
	����  �ڵ� : LPWSTR  -> LPCWSTR     L"test"
	����  Ÿ�� : LPTSTR  -> LPCTSTR     TEXT("test")
	*/
	MessageBox(0, TEXT("���ڿ����"), TEXT("Ÿ��Ʋ��"), MB_YESNO | MB_ICONQUESTION);

	return 0;
}
