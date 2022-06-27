#include <stdio.h>
#include <string.h>	//string함수
#include <tchar.h>

int main()
{
	char	ch1 = 'A';		//멀티바이트
	wchar_t ch2 = '한';		//유니코드
	TCHAR   ch3 = 'A';		//범용

	printf("%dbyte\n", sizeof(ch1));		//1
	printf("%dbyte\n", sizeof(ch2));		//2

	char str1[] = "abcd";		//a b c d \0
	wchar_t str2[] = L"abcd";	//a\0 b\0 c\0 d\0 \0\0
	TCHAR str3[] = _TEXT("abcd");		//범용

	//========================================
	//문자열 함수
	//strlen : 문자들을 읽어나가다가 null만나면 끝.
	printf("문자열 길이 : %d갯수\n", strlen(str1));	//갯수
	printf("문자열 길이 : %d갯수\n", wcslen(str2));	//4갯수
	printf("문자열 길이 : %d갯수\n", _tcslen(str3));	//4갯수

	return 0;
}