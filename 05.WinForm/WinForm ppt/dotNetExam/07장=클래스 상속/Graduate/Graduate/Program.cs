using System;

class Human
{
	protected string Name;
	protected int Age;
	public Human(string aName, int aAge)
	{
		Name = aName;
		Age = aAge;
	}
}

class Student : Human
{
	protected int StNum;
	public Student(string aName, int aAge, int aStNum)
		: base(aName, aAge)
	{
		StNum = aStNum;
	}
	public void Study()
	{
		Console.WriteLine("23은 6, 24 8, 25 10, 26은 12...");
	}
}

class Graduate : Student
{
	protected string Major;
	public Graduate(string aName, int aAge, int aStNum, string aMajor)
		: base(aName, aAge, aStNum)
	{
		Major = aMajor;
	}
	public void WriteThesis()
	{
		Console.WriteLine("서론, 본론, 결론 어쩌고 저쩌고");
	}
}

class CSTest
{
	static void Main()
	{
		Graduate Park = new Graduate("박미영", 32, 9101223, "영문학");
		Park.WriteThesis();
	}
}
