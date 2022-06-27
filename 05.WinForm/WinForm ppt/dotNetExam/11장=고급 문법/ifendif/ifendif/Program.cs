#define TRIAL
using System;

class CSTest
{
#if TRIAL
	static void TrialMessage()
	{
		Console.WriteLine("이 제품은 30일간만 사용할 수 있습니다.");
		Console.WriteLine("정품을 구입하시려면 어쩌고 저쩌고.");
		Console.WriteLine("");
	}
#endif
	static void Main()
	{
#if TRIAL
		TrialMessage();
#endif
		Console.WriteLine("게임을 시작합니다.");
	}
}
