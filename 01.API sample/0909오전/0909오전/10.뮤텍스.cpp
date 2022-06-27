//뮤텍스
#pragma comment (linker, "/subsystem:console")

#include <windows.h>
#include <iostream>
using namespace std;

int main()
{
	// 뮤텍스 생성 
	// 만약, 생성된 객체를 다시 Create하게 되면, Open으로 변경해준다.

	HANDLE hMutex = CreateMutex(NULL, // 보안속성
		FALSE, // 생성시 뮤텍스 소유 여부
		TEXT("mutex")); // 이름

// 소유가 ture일때 -> Signal 을 nonsignal로 바꾼다.
	cout << "뮤택스를 기다리고 있다." << endl;

	//WaitFor 가 리턴하면 해당 객체의 상태값을 non-S  변경
	DWORD d = WaitForSingleObject(hMutex, INFINITE); // 대기
	if (d == WAIT_TIMEOUT)
		MessageBox(NULL, TEXT("WAIT_TIMEOUT"), TEXT(""), MB_OK);
	else if (d == WAIT_OBJECT_0)
		MessageBox(NULL, TEXT("WAIT_OBJECT_0"), TEXT(""), MB_OK);
	else if (d == WAIT_ABANDONED_0)
		MessageBox(NULL, TEXT("WAIT_ABANDONED_0"), TEXT(""), MB_OK);

	cout << "뮤택스 획득" << endl;

	MessageBox(NULL, TEXT("뮤택스를 놓는다."), TEXT(""), MB_OK);
	ReleaseMutex(hMutex);

	return 0;
}