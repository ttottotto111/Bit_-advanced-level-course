using System;

class CSTest
{
	public static void PlusOne(int p) { p++; }
	public static void PlusOneRef(ref int p) { p++; }
	public static void GetValue(out int p) { p = 1234; }

	static void Main()
	{
		int a = 1, b;
		PlusOne(a);
		Console.WriteLine("a={0}", a);
		PlusOneRef(ref a);
		Console.WriteLine("a={0}", a);
		GetValue(out b);
		Console.WriteLine("b={0}", b);
	}
}
