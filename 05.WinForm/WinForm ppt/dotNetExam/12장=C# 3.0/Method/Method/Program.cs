using System;

class CSTest
{
	static int Add(int a)
	{
		return a + 1;
	}

	static void Main()
	{
		int k = Add(3);
		Console.WriteLine("k = " + k);
	}
}
