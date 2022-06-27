using System;

delegate int dele(int a, int b);

class CSTest
{
	public static int Add(int a, int b)
	{
		return a + b;
	}
	static void Main()
	{
		dele d = Add;
		int k = d(2, 3);
		Console.WriteLine(k);
	}
}
