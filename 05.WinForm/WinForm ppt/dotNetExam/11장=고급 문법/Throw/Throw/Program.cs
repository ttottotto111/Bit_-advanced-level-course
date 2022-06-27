using System;

class CSTest
{
	static void AddKim(string Kim)
	{
		if (Kim[0] != '김')
		{
			throw new FormatException("김가만 등록할 수 있다.");
		}
		Console.WriteLine(Kim + "등록 완료");
	}
	static void Main()
	{
		try
		{
			AddKim("김서방");
			AddKim("오서방");
		}
		catch (FormatException e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
