using System;

class Time
{
	public int hour, min, sec;
	public Time(int h, int m, int s) { hour = h; min = m; sec = s; }
	public override bool Equals(object obj)
	{
		Time Other = (Time)obj;
		return (Other.hour == hour && Other.min == min && Other.sec == sec);
	}
}

class CSTest
{
	static void Main()
	{
		Time A = new Time(1, 2, 3);
		Time B = new Time(1, 2, 3);
		Time C = A;
		Console.WriteLine("Equals(A, B) = " + Equals(A, B));
		Console.WriteLine("Equals(A, C) = " + Equals(A, C));
		Console.WriteLine("ReferenceEquals(A, B) = " + ReferenceEquals(A, B));
		Console.WriteLine("ReferenceEquals(A, C) = " + ReferenceEquals(A, C));
	}
}
