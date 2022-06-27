using System;

class Human
{
	public virtual void Intro() { Console.WriteLine("나 사람"); }
}

class Student : Human
{
	public override void Intro() { Console.WriteLine("나 학생"); }
}

class CSTest
{
	public static void OutValue<T>(T man) where T : Human
	{
		man.Intro();
	}
	static void Main()
	{
		Human A = new Human();
		Student B = new Student();
		string C = "나 문자열";

		OutValue(A);
		OutValue(B);
		//OutValue(C);
	}
}
