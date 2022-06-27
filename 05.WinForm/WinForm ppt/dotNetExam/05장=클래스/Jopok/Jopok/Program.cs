using System;

class CSTest
{
	static void Main()
	{
		Jopok NalaliPa;
		NalaliPa = new Jopok("김상형", 25, 500);
		NalaliPa.Intro();
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

class Jopok
{
	readonly private Human Dumok;
	private int Jolgae;
	public Jopok(string aName, int aAge, int aJolgae)
	{
		Dumok = new Human(aName, aAge);
		Jolgae = aJolgae;
	}
	public void Intro()
	{
		Console.WriteLine("대빵 신상 명세");
		Dumok.Intro();
		Console.WriteLine("조직원:{0}명", Jolgae);
	}
}
