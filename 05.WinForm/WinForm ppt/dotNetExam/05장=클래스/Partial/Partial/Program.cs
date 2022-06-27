using System;

class CSTest
{
	static void Main()
	{
		Human Kim;
		Kim = new Human();
		Kim.Name = "김상형";
		Kim.Age = 25;
		Kim.Intro();
	}
}

partial class Human
{
	public int Age;
	public string Name;
}

partial class Human
{
	public void Intro()
	{
		Console.WriteLine("이름:" + Name);
		Console.WriteLine("나이:" + Age);
	}
}
