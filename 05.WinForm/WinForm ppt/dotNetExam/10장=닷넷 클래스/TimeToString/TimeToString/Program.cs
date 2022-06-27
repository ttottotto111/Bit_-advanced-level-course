using System;

class Time
{
	public int hour, min, sec;
	public Time(int h, int m, int s) { hour = h; min = m; sec = s; }
	public void OutTime()
	{
		Console.WriteLine("현재 시간은 {0}시 {1}분 {2}초이다.", hour, min, sec);
	}
	public override string ToString()
	{
		return hour + "시 " + min + "분 " + sec + "초";
	}
}

class CSTest
{
	static void Main()
	{
		Time Now = new Time(18, 25, 55);
		Now.OutTime();
		Console.WriteLine(Now);
	}
}
