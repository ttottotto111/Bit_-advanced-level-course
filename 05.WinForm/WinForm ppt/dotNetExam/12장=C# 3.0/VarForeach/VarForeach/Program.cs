using System;

class Human
{
	public string Name { get; set; }
	public int Age { get; set; }
}

class CSTest
{
	static void Main()
	{
		Human Lee = new Human();
		Lee.Name = "이순신";
		Lee.Age = 32;
		Console.WriteLine("이름 : " + Lee.Name + ", 나이 : " + Lee.Age);
	}
}
