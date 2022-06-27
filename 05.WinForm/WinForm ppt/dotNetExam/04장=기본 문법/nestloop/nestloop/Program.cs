using System;

class CSTest
{
	static void Main()
	{
		for (int dan = 1; dan <= 9; dan++)
		{
			for (int i = 1; i <= 9; i++)
			{
				Console.WriteLine("{0} * {1} = {2}", dan, i, dan * i);
			}
			Console.WriteLine();
		}
	}
}
