using System;

class CSTest
{
	public static void Main()
	{
		int[,] ar = { 
			{ 1, 2, 3},
			{ 4, 5, 6}
		};
		foreach (int a in ar)
		{
			Console.WriteLine(a);
		}
	}
}
