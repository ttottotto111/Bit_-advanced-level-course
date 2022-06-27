using System;

class CSTest
{
	static int[] ar = { 1, 2, 3, 4, 5 };
	static int idx = 8;
	static void Main()
	{
		try
		{
			Console.WriteLine(ar[idx]);
		}
		catch (IndexOutOfRangeException e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
