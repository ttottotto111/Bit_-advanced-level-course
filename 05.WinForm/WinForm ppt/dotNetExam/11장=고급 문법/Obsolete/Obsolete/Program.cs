using System;
using System.Diagnostics;

class CSTest
{
	[Obsolete("NewMethod를 사용하시오")]
	static public void OldMethod() { }

	static public void NewMethod()
	{
		Console.WriteLine("새로 만든 최신형 메서드입니다.");
	}

	[Obsolete("앞으로는 이 메서드를 쓰지 마시오.", true)]
	static public void OutDateMethod() { }

	static void Main()
	{
		OldMethod();
		NewMethod();
		// OutDateMethod();
	}
}
