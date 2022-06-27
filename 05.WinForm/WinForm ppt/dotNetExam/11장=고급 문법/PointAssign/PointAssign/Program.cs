using System;

class CSTest
{
	static void Main()
	{
		int i = 3, j;
		unsafe
		{
			int* pi;
			pi = &i;
			j = *pi;
		}
		Console.WriteLine("i={0},j={1}", i, j);
	}
}
