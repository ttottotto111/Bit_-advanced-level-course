using System;

class Human
{
	private string Name;
	private int Age;
	public Human(string aName, int aAge)
	{
		Name = aName;
		Age = aAge;
	}
	public void Intro()
	{
		Console.WriteLine("이름:" + Name);
		Console.WriteLine("나이:" + Age);
	}
}

class Student
{
	public Human H;
	protected int StNum;
	public Student(string aName, int aAge, int aStNum)
	{
		StNum = aStNum;
		H = new Human(aName, aAge);
	}
	public void Intro()
	{
		H.Intro();
		Console.WriteLine("학번:" + StNum);
	}
	public void Study()
	{
		Console.WriteLine("하늘 천 따지 검을 현 누를 황");
	}
}

class CSTest
{
	static void Main()
	{
		Student Kim;
		Kim = new Student("김상형", 25, 8906299);
		Kim.Intro();
		Kim.Study();
	}
}
