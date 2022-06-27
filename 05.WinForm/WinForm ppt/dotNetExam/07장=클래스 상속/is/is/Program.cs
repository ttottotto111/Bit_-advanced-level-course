using System;

class Human { }
class Student : Human { }
class Graduate : Student { }
class Assistant : Human { }
class Professor : Human { }
class Suwi : Human { }

class CSTest
{
	static void Register(Human H)
	{
		if (H is Student || H is Assistant)
		{
			Console.WriteLine("등록했다 치고");
		}
		else
		{
			Console.WriteLine("학생이 아니므로 등록 안됨");
		}
	}

	static void Main()
	{
		Graduate Kim = new Graduate();
		Assistant Lee = new Assistant();
		Professor Park = new Professor();
		Suwi Choi = new Suwi();
		Register(Kim);
		Register(Lee);
		Register(Park);
		Register(Choi);
	}
}
