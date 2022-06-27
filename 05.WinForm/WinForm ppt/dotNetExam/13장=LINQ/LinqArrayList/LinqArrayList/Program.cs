using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class CSTest
{
	static void Main()
	{
		ArrayList ar = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		IEnumerable<int> Query = from int n in ar where (n % 3 == 0) select n;
		foreach (int k in Query)
		{
			Console.WriteLine(k);
		}
	}
}
