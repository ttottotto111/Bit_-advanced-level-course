using System;

class Time : IFormattable
{
	public int hour, min, sec;
	public Time(int h, int m, int s) { hour = h; min = m; sec = s; }
	public void OutTime()
	{
		Console.WriteLine("현재 시간은 {0}시 {1}분 {2}초이다.", hour, min, sec);
	}
	public String ToString(string format, IFormatProvider fp)
	{
		switch (format)
		{
			case null:
			case "A":
				return string.Format("{0}시 {1}분 {2}초", hour, min, sec);
			case "B":
				return string.Format("{0}:{1}:{2}", hour, min, sec);
			case "C":
				return string.Format("{0}.{1}.{2}", hour, min, sec);
			default:
				return "틀린 서식입니다.";
		}
	}

}

class CSTest
{
	static void Main()
	{
		Time Now = new Time(12, 34, 56);
		Console.WriteLine("Now = {0:A}입니다.", Now);
		Console.WriteLine("Now = {0:B}입니다.", Now);
		Console.WriteLine("Now = {0:C}입니다.", Now);
		Console.WriteLine("Now = {0,20}입니다.", Now);
		Console.WriteLine("Now = {0,-20}입니다.", Now);
	}
}
