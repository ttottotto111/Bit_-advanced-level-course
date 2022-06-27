using System;

public static class Int32Ext
{
	public static int Dubae(this int n)
	{
		return n * 2;
	}
	public static int Jegop(this int n)
	{
		return n * n;
	}
}

class CSTest
{
	static void Main()
	{
		Console.WriteLine("덧셈 : " + 5.Dubae());
		Console.WriteLine("제곱 : " + 5.Jegop());
	}
}
