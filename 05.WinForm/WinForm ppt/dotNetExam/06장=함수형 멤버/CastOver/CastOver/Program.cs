﻿using System;

class Time
{
	public int hour, min, sec;
	public Time() { }
	public Time(int h, int m, int s) { hour = h; min = m; sec = s; }
	public static implicit operator int(Time T)
	{
		return T.hour * 3600 + T.min * 60 + T.sec;
	}
	public static implicit operator double(Time T)
	{
		return T.hour + T.min / 100.0;
	}
}

class CSTest
{
	static void Main()
	{
		Time Now = new Time(12, 34, 56);
		Console.WriteLine((int)Now);
		Console.WriteLine((double)Now);
		Console.WriteLine(Now);
	}
}
