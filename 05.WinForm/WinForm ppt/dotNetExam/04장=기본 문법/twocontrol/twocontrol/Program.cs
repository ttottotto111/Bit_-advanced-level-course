using System;

class CSTest
{
	static void Main()
	{
		int i, j;
		for (i = 1, j = 2; i <= 10; i++, j += 2)
		{
			Console.WriteLine("i = {0}, j= {1}", i, j);
		}
	}
}
