using System;
using System.Collections.Generic;
using System.Linq;

class People
{
	public People(string aName, int aAge, bool aMale)
	{ Name = aName; Age = aAge; Male = aMale; }
	public string Name;
	public int Age;
	public bool Male;
}

class CSTest
{
	static void Main()
	{
		People[] arPeople = { new People("정우성", 36, true), new People("고소영", 32, 
			false) ,new People("배용준", 37, true), new People("김태희", 29, false) };

		IEnumerable<People> Query = from p in arPeople select p;
		foreach (People k in Query)
		{
			Console.WriteLine("이름 : " + k.Name + ", 나이 : " + k.Age +
				", 남자 : " + k.Male);
		}
	}
}
