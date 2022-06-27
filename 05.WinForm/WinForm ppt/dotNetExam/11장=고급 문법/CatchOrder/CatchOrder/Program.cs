using System;

class CSTest
{
	static void Main()
	{
		try
		{
			int i = 0;
			int k = 5 / i;
		}
		catch (DivideByZeroException e)
		{
			Console.WriteLine("0으로 나누지 마십시오. : " + e.Message);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		catch
		{
			Console.WriteLine("이유는 모르겠지만 하옇든 잘못되었습니다.");
		}
	}
}
