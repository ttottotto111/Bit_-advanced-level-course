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

class Teacher : Human
{
	protected string Subject;
	public Teacher(string aName, int aAge, string aSubject)
		: base(aName, aAge)
	{
		Subject = aSubject;
	}
	public void Teach()
	{
		Console.WriteLine("얘들아 공부 열심히 해라");
	}
}

class Thief : Human
{
	protected int Career;
	public Thief(string aName, int aAge, int aCareer)
		: base(aName, aAge)
	{
		Career = aCareer;
	}
	public void Steal()
	{
		Console.WriteLine("오늘은 어디를 털어 볼까?");
	}
}

class CSTest
{
	static void Main()
	{
		Teacher Eng = new Teacher("박미영", 35, "영어");
		Thief KangDo = new Thief("야월담", 25, 3);
		Eng.Teach();
		KangDo.Steal();
	}
}
