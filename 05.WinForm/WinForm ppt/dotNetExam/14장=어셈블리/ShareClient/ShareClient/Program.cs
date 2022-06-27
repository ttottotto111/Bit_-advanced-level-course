using System;
using ShareDll;

class CSTest
{
	static void Main()
	{
		Console.WriteLine("3.0 + 2.0 = {0}", DoubleCalc.Add(3.0, 2.0));
		Console.WriteLine("3.0 - 2.0 = {0}", DoubleCalc.Sub(3.0, 2.0));
		Console.ReadLine();
	}
}
