using System;
using System.Collections.Generic;
using System.Linq;

class CSTest
{
	static void Main()
	{
		int[] ar = { 1, 2, 3, 4, 5 };
		int Query = (from n in ar select n).Count();
		Console.WriteLine(Query);
	}
}
