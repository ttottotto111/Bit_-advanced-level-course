using System;

class CSTest
{
	static void Main()
	{
		int i;
		int sum = 0;
		for (i = 1; i <= 100; i++)
		{
			sum = sum + i;
		}
		Console.WriteLine("1~100까지의 합계 = {0}", sum);
	}
}
