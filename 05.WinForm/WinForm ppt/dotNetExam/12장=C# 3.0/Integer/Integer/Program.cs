using System;

public class Integer
{
	public int a;
	public Integer(int aa) { a = aa; }
	public int Add(int b) { return a + b; }
	public int Mul(int b) { return a * b; }
}

class CSTest
{
	static void Main()
	{
		Integer Num = new Integer(3);
		Console.WriteLine("덧셈 : " + Num.Add(2));
		Console.WriteLine("곱셈 : " + Num.Mul(2));
	}
}
