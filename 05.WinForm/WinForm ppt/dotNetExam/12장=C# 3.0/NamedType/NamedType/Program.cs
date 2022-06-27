using System;

class Human
{
	public Human(string aName, int aAge)
	{
		Name = aName;
		Age = aAge;
	}
	public string Name { get; set; }
	public int Age { get; set; }
}

class CSTest
{
	static void Main()
	{
		Human Lee = new Human("이순신", 32);
		Console.WriteLine("이름 : " + Lee.Name + ", 나이 : " + Lee.Age);
	}
}
