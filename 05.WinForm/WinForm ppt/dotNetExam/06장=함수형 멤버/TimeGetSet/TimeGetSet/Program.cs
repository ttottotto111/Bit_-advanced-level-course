using System;

class Time
{
	private int hour, min, sec;
	public Time(int h, int m, int s) { SetHour(h); SetMin(h); SetSec(s); }
	public int GetHour() { return hour; }
	public void SetHour(int aHour) { if (aHour < 24) hour = aHour; }
	public int GetMin() { return min; }
	public void SetMin(int aMin) { if (aMin < 60) min = aMin; }
	public int GetSec() { return sec; }
	public void SetSec(int aSec) { if (aSec < 60) sec = aSec; }
	public void OutTime()
	{
		Console.WriteLine("현재 시간은 {0}시 {1}분 {2}초이다.", hour, min, sec);
	}
}

class CSTest
{
	static void Main()
	{
		Time Now;
		Now = new Time(12, 30, 45);
		Now.OutTime();
		Now.SetHour(55);
		Now.OutTime();
	}
}
