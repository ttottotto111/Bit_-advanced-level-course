using System;

delegate int dele(int a, int b);

class CSTest
{
	static void Main()
	{
		dele d = delegate(int a, int b) { return a + b; };
		int k = d(2, 3);
		Console.WriteLine(k);
	}
}
