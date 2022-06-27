using System;

class CSTest
{
	static int[] ar = { 1, 2, 3, 4, 5 };
	static int idx = 8;
	static public void Method1()
	{
		Console.WriteLine(ar[idx]);
	}
	static void Main()
	{
		try
		{
			Method1();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			Console.WriteLine(e.Source);
			Console.WriteLine(e.TargetSite);
			Console.WriteLine(e.StackTrace);
		}
	}
}
