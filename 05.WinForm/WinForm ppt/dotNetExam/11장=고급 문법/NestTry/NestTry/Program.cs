using System;

class CSTest
{
	static void Main()
	{
		short Price, Num, Total = 0;
		try
		{
			Console.Write("단가를 입력하시오 : ");
			Price = Convert.ToInt16(Console.ReadLine());
			Console.Write("개수를 입력하시오 : ");
			try
			{
				Num = Convert.ToInt16(Console.ReadLine());
				checked { Total = (short)(Price * Num); }
			}
			catch (OverflowException e)
			{
				Console.WriteLine(e.Message);
			}
			Console.WriteLine("총 가격은 {0}입니다.", Total);
		}
		catch (FormatException e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
