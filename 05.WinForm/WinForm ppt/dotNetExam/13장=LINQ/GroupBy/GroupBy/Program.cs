using System;
using System.Collections.Generic;
using System.Linq;

class Staff
{
	public Staff(string aName, string aDepart, int aSalary)
	{ Name = aName; Depart = aDepart; Salary = aSalary; }
	public string Name;
	public string Depart;
	public int Salary;
}

class CSTest
{
	static void Main()
	{
		Staff[] arStaff = { new Staff("김유신", "관리부", 180),
							new Staff("유관순", "지원부", 190),
							new Staff("안중근", "영업부", 185),
							new Staff("윤봉길", "생산부", 200),
							new Staff("강감찬", "영업부", 150),
							new Staff("정몽주", "관리부", 170),
							new Staff("안창남", "생산부", 175),
							new Staff("이윤복", "지원부", 210),
							new Staff("신숙주", "영업부", 220),
							new Staff("성삼문", "영업부", 205),
							new Staff("이자겸", "생산부", 205),
						  };

		IEnumerable<IGrouping<string, Staff>> Query =
			from p in arStaff group p by p.Depart;

		foreach (IGrouping<string, Staff> g in Query)
		{
			Console.WriteLine("\r\n" + g.Key);
			foreach (Staff k in g)
			{
				Console.WriteLine("이름 : " + k.Name + ", 월급 : " + k.Salary);
			}
		}
	}
}
