using System;

class CSTest
{
	public static void Main()
	{
		int i = 1234;
		double d = 5.6789;
		Console.WriteLine("문자열");
		Console.WriteLine(i);
		Console.WriteLine(d);

		// 서식을 사용할 수 있다.
		Console.WriteLine("정수는 {0}이고 실수는 {1}이다", i, d);
		Console.WriteLine("자리수 테스트:->{0}<- ->{0,6}<- ->{0,-6}<-", i);
		Console.WriteLine("->{0:F0}<- ->{0:F2}<- ->{0:F4}<-", d);
	}
}
