using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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

		var Query = new XElement("사람들", from p in arPeople
										select new XElement("사람", new XElement("이름", p.Name),
											new XElement("나이", p.Age), new XElement("남자", p.Male)));
		Console.WriteLine(Query);
	}
}
