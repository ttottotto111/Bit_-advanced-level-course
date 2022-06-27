using System;

class CSTest
{
	static void Main()
	{
		unsafe
		{
			int* pi = stackalloc int[5];
			for (int i = 0; i < 5; i++)
			{
				pi[i] = i * 2;
				Console.WriteLine(pi[i]);
			}
		}
	}
}
