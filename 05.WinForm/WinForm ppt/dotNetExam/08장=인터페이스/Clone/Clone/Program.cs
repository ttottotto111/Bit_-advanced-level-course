using System;

class C : ICloneable
{
	public int v;
	public C(int av) { v = av; }
	public object Clone()
	{
		return new C(v);
	}
}

class CSTest
{
	static void Main()
	{
		C a = new C(1234);
		C b = (C)a.Clone();
		b.v = 5678;
		Console.WriteLine("a = {0}, b = {1}", a.v, b.v);
	}
}
