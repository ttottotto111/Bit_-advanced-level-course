﻿using System;
using System.Collections;

class Time : IEnumerable
{
	public int hour, min, sec;
	public Time(int h, int m, int s) { hour = h; min = m; sec = s; }
	public IEnumerator GetEnumerator()
	{
		return new TimeEnum(this);
	}
}

class TimeEnum : IEnumerator
{
	private Time T;
	private int element;
	public TimeEnum(Time aT)
	{
		T = aT;
		Reset();
	}
	public bool MoveNext()
	{
		if (element < 2)
		{
			element++;
			return true;
		}
		else
		{
			return false;
		}
	}
	public object Current
	{
		get
		{
			switch (element)
			{
				case 0: return T.hour;
				case 1: return T.min;
				case 2: return T.sec;
				default: return null;
			}
		}
	}
	public void Reset()
	{
		element = -1;
	}
}

class CSTest
{
	static void Main()
	{
		Time Now = new Time(18, 25, 55);
		foreach (int hms in Now)
		{
			Console.WriteLine("{0}:", hms);
		}
	}
}
