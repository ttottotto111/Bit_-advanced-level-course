using System;

class CSTest
{
	static void Main()
	{
		Time Now;
		Now = new Time();
		Now.hour = 12;
		Now.min = 30;
		Now.sec = 45;
		Now.OutTime();
	}
}

class Time
{
	public int hour, min, sec;
	public void OutTime()
	{
		Console.WriteLine("현재 시간은 {0}시 {1}분 {2}초이다.", hour, min, sec);
	}
}
