using System;

class CSTest
{
	public static void Main()
	{
		int[] ar = { 29, 64, 90, 16, 78 };
		int Max = 0;

		foreach (int a in ar)
		{
			if (Max < a) Max = a;
		}
		Console.WriteLine("가장 큰 값은 {0}입니다.", Max);
	}
}
