using System;

class CSTest
{
	enum Origin { East, West, South, North }
	static void Main()
	{
		Origin Turn;
		Turn = Origin.South;
		string name = Turn.ToString();
		Console.WriteLine(name);
		Turn = (Origin)Enum.Parse(typeof(Origin), "East");
		Console.WriteLine(Turn);
	}
}
