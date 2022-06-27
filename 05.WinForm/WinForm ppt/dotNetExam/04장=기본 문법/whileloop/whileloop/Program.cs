using System;

class CSTest
{
	static void Main()
	{
		int i = 1;
		int sum = 0;
		while (sum < 1000)
		{
			sum = sum + i;
			i++;
		}
		Console.WriteLine("합이 1000을 넘는 최초의 수 = {0}", i);
	}
}
