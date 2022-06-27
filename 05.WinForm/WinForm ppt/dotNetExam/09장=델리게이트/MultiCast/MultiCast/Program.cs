using System;

delegate void dele(int a);

class CSTest
{
	public static void Method1(int a) { Console.WriteLine("Method1 " + a); }
	public static void Method2(int a) { Console.WriteLine("Method2 " + a); }
	static void Main()
	{
		dele d;
		d = Method1;
		d += Method2;
		d(34);
	}
}
