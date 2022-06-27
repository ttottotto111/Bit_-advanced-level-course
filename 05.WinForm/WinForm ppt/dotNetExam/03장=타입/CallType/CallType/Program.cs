using System;

class CSTest
{
	public static void method1(CTime t)
	{
		t.hour = 12;
	}
	public static void method2(STime t)
	{
		t.hour = 12;
	}
	static void Main()
	{
		CTime C = new CTime();
		C.hour = 9;
		STime S;
		S.hour = 9;
		method1(C);
		method2(S);
		Console.WriteLine("클래스 : " + C.hour);
		Console.WriteLine("구조체 : " + S.hour);
	}
}


class CTime
{
	public int hour;
}

struct STime
{
	public int hour;
}
