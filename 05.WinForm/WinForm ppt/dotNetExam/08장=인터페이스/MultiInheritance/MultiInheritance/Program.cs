using System;

interface A1
{
	void a();
}

interface A2
{
	void a();
}

interface B : A1, A2
{
	void b();
}

class C : B
{
	public void a() { Console.WriteLine("a"); }
	public void b() { Console.WriteLine("b"); }
}

class CSTest
{
	static void Method(B b)
	{
		b.a();
	}
	static void Main()
	{
		C c = new C();
		c.a();
		Method(c);
	}
}
