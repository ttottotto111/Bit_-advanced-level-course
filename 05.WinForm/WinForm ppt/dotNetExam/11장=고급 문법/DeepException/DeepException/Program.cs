using System;

class CSTest
{
	static int[] ar = { 1, 2, 3, 4, 5 };
	static int idx = 8;
	static public void Method1()
	{
		Method2();
	}
	static public void Method2()
	{
		Console.WriteLine(ar[idx]);
	}
	static void Main()
	{
		try
		{
			Method1();
		}
		catch (IndexOutOfRangeException e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
