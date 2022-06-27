using System;

class CSTest
{
	enum Origin { East, West, South, North }
	static void Main()
	{
		Origin Turn;
		Turn = Origin.South;
		Console.WriteLine(Turn);
		int Value = (int)Turn;
		Console.WriteLine(Value);
	}
}
