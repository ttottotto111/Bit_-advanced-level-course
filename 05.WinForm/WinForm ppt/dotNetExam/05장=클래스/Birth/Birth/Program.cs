using System;

class CSTest
{
	static void Main()
	{
		Human Kim;
		Kim = new Human("김상형", 1980, 1, 2);
		Kim.Intro();
	}
}

class Human
{
	private class Date
	{
		int y, m, d;
		public Date(int ay, int am, int ad)
		{
			y = ay;
			m = am;
			d = ad;
		}
		public void OutDate()
		{
			Console.WriteLine("{0}년 {1}월 {2}일", y, m, d);
		}
	}
	private string Name;
	private Date Birth;
	public Human(string aName, int ay, int am, int ad)
	{
		Name = aName;
		Birth = new Date(ay, am, ad);
	}
	public void Intro()
	{
		Console.WriteLine("이름:" + Name);
		Console.Write("생년월일:");
		Birth.OutDate();
	}
}
