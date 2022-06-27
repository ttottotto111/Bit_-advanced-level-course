using System;

class NotKimException : ApplicationException
{
	public NotKimException(string message) : base(message) { }
	public string ErrorName;
}

class CSTest
{
	static void AddKim(string Kim)
	{
		if (Kim[0] != '김')
		{
			NotKimException NotKim = new NotKimException("김가만 등록할 수 있다.");
			NotKim.HelpLink = "김가 동호회 규약.txt";
			NotKim.Source = "CSTest.cs";
			NotKim.ErrorName = Kim;
			throw NotKim;
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
		catch (NotKimException e)
		{
			Console.WriteLine(e.Message + e.ErrorName[0] + "가는 등록안됨");
		}
	}
}
