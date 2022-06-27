using System;

class CSTest
{
	public static int AddAll(params int[] nums)
	{
		int sum = 0;
		for (int i = 0; i < nums.Length; i++)
		{
			sum += nums[i];
		}
		return sum;
	}

	static void Main()
	{
		int[] ar = { 3, 4, 5 };
		Console.WriteLine("1+2 = {0}", AddAll(new int[2] { 1, 2 }));
		Console.WriteLine("3+4+5 = {0}", AddAll(ar));
		Console.WriteLine("6+7+8+9 = {0}", AddAll(6, 7, 8, 9));
	}
}
