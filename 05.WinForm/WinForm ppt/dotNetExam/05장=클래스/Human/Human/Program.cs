﻿using System;

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

class Human
{
	public string Name;
	public int Age;
	public void Intro()
	{
		Console.WriteLine("이름:" + Name);
		Console.WriteLine("나이:" + Age);
	}
}
