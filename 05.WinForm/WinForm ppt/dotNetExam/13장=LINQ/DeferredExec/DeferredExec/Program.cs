using System;
using System.Collections.Generic;
using System.Linq;

class CSTest
{
	static void Main()
	{
		int[] ar = { 1, 2, 3, 4, 5 };
		IEnumerable<int> Query = from n in ar select n;
		foreach (int k in Query)
		{
			Console.WriteLine(k);
		}

		Console.WriteLine();
		ar[2] = 9999;
		foreach (int k in Query)
		{
			Console.WriteLine(k);
		}
	}
}
