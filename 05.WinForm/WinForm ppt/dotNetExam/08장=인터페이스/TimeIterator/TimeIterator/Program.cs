using System;
using System.Collections;

class Time
{
	public int hour, min, sec;
	public Time(int h, int m, int s) { hour = h; min = m; sec = s; }
	public IEnumerator GetEnumerator()
	{
		yield return hour;
		yield return min;
		yield return sec;
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
