using System;

class CSTest
{
	static void Main()
	{
		string s = "둘";
		switch (s)
		{
			case "하나":
				Console.WriteLine(1);
				break;
			case "둘":
				Console.WriteLine(2);
				break;
			case "셋":
				Console.WriteLine(3);
				break;
			default:
				Console.WriteLine("그 외의 숫자");
				break;
		}
	}
}
