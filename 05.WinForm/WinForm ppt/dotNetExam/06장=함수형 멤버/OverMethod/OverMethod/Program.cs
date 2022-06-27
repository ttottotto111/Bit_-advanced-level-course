using System;

class CSTest
{
	static void Method(short a) { Console.WriteLine("short"); }
	static void Method(int a) { Console.WriteLine("int"); }
	static void Method(uint a) { Console.WriteLine("uint"); }
	static void Method(long a) { Console.WriteLine("long"); }
	static void Method(double a) { Console.WriteLine("double"); }
	static void Main()
	{
		short s = 1234;
		Method(s);
	}
}
