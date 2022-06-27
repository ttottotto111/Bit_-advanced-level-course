using System;
using System.Collections;

class CSTest
{
	static void Main()
	{
		ArrayList ar = new ArrayList(10);
		ar.Add(1);
		ar.Add(2.34);
		ar.Add("string");

		int i = (int)ar[0];
		double d = (double)ar[1];
		string str = (string)ar[2];

		Console.WriteLine("{0}, {1}, {2}", i, d, str);
	}
}
