using System;

delegate int dele(int a, int b);

class CSTest
{
	public static void SetDelegate(out dele d)
	{
		int k = 5;
		d = delegate(int a, int b) { return a + b + k; };
	}
	static void Main()
	{
		dele d;
		SetDelegate(out d);
		int z = d(2, 3);
		Console.WriteLine(z);
	}
}
