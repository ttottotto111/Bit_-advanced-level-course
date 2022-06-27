using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field,
	AllowMultiple = true, Inherited = false)]
class ProgrammerAttribute : Attribute
{
	private string Name;
	private string Time;
	public ProgrammerAttribute(string aName)
	{
		Name = aName;
		Time = "기록없음";
	}
	public string When
	{
		get { return Time; }
		set { Time = value; }
	}
}

class CSTest
{
	[Programmer("Kim")]
	static public int Field1 = 0;

	[Programmer("Kim", When = "2007년 6월 29일")]
	static public void Method1() { }

	[Programmer("Lee")]
	static public void Method2() { }

	[Programmer("Park"), Programmer("Choi")]
	static public void Method3() { }

	static void Main()
	{
	}
}
