using System;

class CSTest
{
	static void Main()
	{
		Human Kim = new Human("김상형", 25);
		Kim.Intro();
		Human Lee = new Human("이순신");
		Lee.Intro();
	}
}

class Human
{
	private string Name;
	private int Age;
	public Human(string aName, int aAge)
		: this(aName)
	{
		Age = aAge;
	}
	public Human(string aName)
	{
		Name = aName;
		Age = 1;
	}
	public void Intro()
	{
		Console.WriteLine("이름:" + Name);
		Console.WriteLine("나이:" + Age);
	}
}
