using System;

class CSTest
{
	public static int Add(int a, int b) { return a + b; }
	public static int Mul(int a, int b) { return a * b; }
	static void Main()
	{
		int a = 3, b = 5;
		int o;
		Console.Write("어떤 연산을 하고 싶습니까? (1:덧셈, 2:곱셈) ");
		o = Convert.ToInt32(Console.ReadLine());
		switch (o)
		{
			case 1:
				Console.WriteLine("결과는 {0} 입니다.", Add(a, b));
				break;
			case 2:
				Console.WriteLine("결과는 {0} 입니다.", Mul(a, b));
				break;
		}
	}
}
