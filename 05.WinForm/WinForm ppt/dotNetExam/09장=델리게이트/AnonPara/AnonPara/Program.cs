using System;

delegate int dele(int a, int b);

class CSTest
{
	static int Calc(dele d)
	{
		return d(2, 3);
	}
	static void Main()
	{
		int k;
		k = Calc(delegate(int a, int b) { return a + b; });
		Console.WriteLine(k);
		k = Calc(delegate(int a, int b) { return a * b; });
		Console.WriteLine(k);
	}
}
