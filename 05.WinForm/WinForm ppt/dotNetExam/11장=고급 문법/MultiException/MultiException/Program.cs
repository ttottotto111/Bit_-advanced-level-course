using System;

class CSTest
{
	static void Main()
	{
		int input;
		int[] ar = { 1, 2, 3, 4, 5 };
		int t;
		for (; ; )
		{
			try
			{
				Console.Write("첨자를 입력하시오(끝낼 때 100) : ");
				input = Convert.ToInt32(Console.ReadLine());
				if (input == 100) break;
				Console.WriteLine("ar[{0}] = {1}", input, ar[input]);
				t = 8 / input;
			}
			catch (IndexOutOfRangeException e)
			{
				Console.WriteLine("첨자가 틀렸어 : " + e.Message);
			}
			catch (DivideByZeroException e)
			{
				Console.WriteLine("0으로 나누지 마 : " + e.Message);
			}
			catch (FormatException e)
			{
				Console.WriteLine("숫자만 입력해야지 : " + e.Message);
			}
		}
	}
}
