using System;

class CSTest
{
	static void Main()
	{
		string str;
		int i = 1234;
		double d = 3.14;
		str = string.Format("정수는 {0}이고 실수는 {1}이다.", i, d);
		Console.WriteLine(str);
	}
}
