using System;

class CSTest
{
	static void Main()
	{
		int i = 3;
		switch (i)
		{
			case 1:
				Console.WriteLine("하나");
				break;
			case 2:
				Console.WriteLine("둘");
				break;
			case 3:
				Console.WriteLine("셋");
				break;
			default:
				Console.WriteLine("그 외의 숫자");
				break;
		}
	}
}
