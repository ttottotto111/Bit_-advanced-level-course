using System;

class CSTest
{
	static void Main()
	{
		int[] ar = { 1, 2, 3, 4, 5 };
		unsafe
		{
			fixed (int* pi = &ar[0])
			{
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine(pi[i]);
				}
			}
		}
	}
}
