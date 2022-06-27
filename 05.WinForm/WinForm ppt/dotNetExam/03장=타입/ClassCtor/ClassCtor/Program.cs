using System;

class CSTest
{
	static void Main()
	{
		Time Now = new Time(12, 30, 45);
		Now.OutTime();
	}
}

class Time
{
	public int hour, min, sec;
	public Time(int ahour, int amin, int asec)
	{
		hour = ahour;
		min = amin;
		sec = asec;
	}
	public void OutTime()
	{
		Console.WriteLine("현재 시간은 {0}시 {1}분 {2}초이다.", hour, min, sec);
	}
}
