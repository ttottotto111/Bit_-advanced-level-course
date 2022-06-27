using System;

class CSTest
{
	// 참조형을 값으로 받는 경우
	public static void method1(CTime t)
	{
		t.hour = 12;
		t = new CTime(15);
	}

	// 참조형을 참조로 받는 경우
	public static void method2(ref CTime t)
	{
		t.hour = 12;
		t = new CTime(15);
	}

	static void Main()
	{
		CTime C1 = new CTime(9);
		method1(C1);
		CTime C2 = new CTime(9);
		method2(ref C2);
		Console.WriteLine("값으로 넘겼을 때 : " + C1.hour);
		Console.WriteLine("참조로 넘겼을 때 : " + C2.hour);
	}
}

class CTime
{
	public CTime(int ahour) { hour = ahour; }
	public int hour;
}
