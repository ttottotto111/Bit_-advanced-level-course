using System;

delegate int IntOp(int a, int b);

class CSTest
{
	public static int Add(int a, int b) { return a + b; }
	public static int Mul(int a, int b) { return a * b; }
	static void Main()
	{
		IntOp[] arOp = { Add, Mul };
		int a = 3, b = 5;
		int o;
		Console.Write("어떤 연산을 하고 싶습니까? (1:덧셈, 2:곱셈) ");
		o = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("결과는 {0} 입니다.", arOp[o - 1](a, b));
	}
}
