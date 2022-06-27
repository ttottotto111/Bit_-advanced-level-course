using System;

class CSTest
{
	static void Main()
	{
		Human Kim;
		Kim = new Human("김상형", 25);
		Kim.Intro();
	}
}

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
