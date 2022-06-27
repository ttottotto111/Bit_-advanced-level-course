using System;

class CSTest
{
	static public int TotalSum(int from, int to)
	{
		int sum = 0;
		for (int i = from; i <= to; i++)
		{
			sum += i;
		}
		return sum;
	}
	static void Main()
	{
		Console.WriteLine("10 ~ 20의 합계 = {0}", TotalSum(10, 20));
	}
}
