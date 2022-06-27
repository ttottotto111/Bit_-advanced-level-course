#include <stdio.h>
#include <string.h>	//string�Լ�
#include <tchar.h>

int main()
{
	char	ch1 = 'A';		//��Ƽ����Ʈ
	wchar_t ch2 = '��';		//�����ڵ�
	TCHAR   ch3 = 'A';		//����

	printf("%dbyte\n", sizeof(ch1));		//1
	printf("%dbyte\n", sizeof(ch2));		//2

	char str1[] = "abcd";		//a b c d \0
	wchar_t str2[] = L"abcd";	//a\0 b\0 c\0 d\0 \0\0
	TCHAR str3[] = _TEXT("abcd");		//����

	//========================================
	//���ڿ� �Լ�
	//strlen : ���ڵ��� �о���ٰ� null������ ��.
	printf("���ڿ� ���� : %d����\n", strlen(str1));	//����
	printf("���ڿ� ���� : %d����\n", wcslen(str2));	//4����
	printf("���ڿ� ���� : %d����\n", _tcslen(str3));	//4����

	return 0;
}