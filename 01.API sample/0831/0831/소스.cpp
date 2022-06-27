//API 첫번째 프로그램
#pragma comment (linker, "/subsystem:windows")
//#pragma comment (linker, "/subsystem:console")



/*
1) 메뉴 : 프로젝트 >> 속성
   구성속성 >> 일반 >> 문자 집합 -> 멀티바이트 문자 집합
   2019버전은 고급에....
   유니코드 문자 집합체계가 기본 셋팅.................

2) 환경에 따라 다른 시작함수를 찾는다.
   콘솔 : main
   폼   : WinMain
   메뉴 : 프로젝트 >> 속성
   링커 >> 시스템 >> 하위시스템 -> 적절히 수정(subsystem:windows)
*/

#include <Windows.h>

//시작함수가 main(CUI) -> WinMain(GUI)
//멀티바이트 코드 
/*
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrev, LPSTR lpCmd, int nShow)
{

	return 0;
}
*/

//유니코드(기본 키워드는 w : wide-늘렸다)
/*
int WINAPI wWinMain(HINSTANCE hInst, HINSTANCE hPrev, LPWSTR lpCmd, int nShow)
{

	return 0;
}
*/

#include <tchar.h>
//범용타입 : 상황에 따라 유니코드와 멀티바이트 코드를 선택적 사용
//범용타입 (기본 키워드는 t)
int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrev, LPTSTR lpCmd, int nShow)
{
	/*
	문자열 표현법 c : const
	멀티바이트 : LPSTR   -> LPCSTR      "test"
	유니  코드 : LPWSTR  -> LPCWSTR     L"test"
	범용  타입 : LPTSTR  -> LPCTSTR     TEXT("test")
	*/
	MessageBox(0, TEXT("문자열출력"), TEXT("타이틀바"), MB_YESNO | MB_ICONQUESTION);

	return 0;
}
