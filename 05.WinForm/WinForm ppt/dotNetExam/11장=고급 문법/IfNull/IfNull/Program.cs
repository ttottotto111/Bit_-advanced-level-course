using System;

class CSTest
{
	public static void Main()
	{
		int? Age = null;
		int MyAge;
		MyAge = Age ?? 25;
		Console.WriteLine("내 나이는 {0}살입니다.", MyAge);
	}
}
