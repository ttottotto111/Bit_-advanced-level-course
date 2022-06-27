using System;

class Human
{
	public string Name;
	public int Age;
}

class Couple
{
	public Human Man;
	public Human Wife;
}

class CSTest
{
	static void Main()
	{
		Couple Inko = new Couple();
		Inko.Man = new Human();
		Inko.Man.Name = "차인표";
		Inko.Man.Age = 40;
		Inko.Wife = new Human();
		Inko.Wife.Name = "신애라";
		Inko.Wife.Age = 38;

		Console.WriteLine("남편 : {0}세 {1}, 아내 : {2}세 {3}",
			Inko.Man.Age, Inko.Man.Name, Inko.Wife.Age, Inko.Wife.Name);
	}
}
