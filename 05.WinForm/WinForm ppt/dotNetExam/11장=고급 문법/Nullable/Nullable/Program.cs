using System;

class CSTest
{
	public static void Main()
	{
		int? Age;
		Age = 3;
		if (Age.HasValue)
		{
			Console.WriteLine(Age);
		}
		else
		{
			Console.WriteLine("알 수 없는 나이임");
		}
	}
}
