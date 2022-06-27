using System;

class C
{
	public int v;
	public C(int av) { v = av; }
}

class CSTest
{
	static void Main()
	{
		C a = new C(1234);
		C b = a;
		b.v = 5678;
		Console.WriteLine("a = {0}, b = {1}", a.v, b.v);
	}
}
