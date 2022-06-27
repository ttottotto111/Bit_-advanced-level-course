using System;
using Server;

class CSTest
{
	static void Main()
	{

		Console.WriteLine("3 + 2 = {0}", IntCalc.Add(3, 2));
		Console.WriteLine("3 - 2 = {0}", IntCalc.Sub(3, 2));
		Console.WriteLine("3 * 2 = {0}", IntCalc.Multiply(3, 2));
		Console.ReadLine();
	}
}
