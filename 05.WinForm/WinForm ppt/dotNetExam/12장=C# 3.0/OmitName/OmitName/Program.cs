using System;

class Human
{
	public string Name { get; set; }
	public int Age { get; set; }
	public string Addr { get; set; }
	public string Tel { get; set; }
	public DateTime Birth { get; set; }
}

class CSTest
{
	static void Main()
	{
		Human Lee = new Human
		{
			Name = "이순신",
			Age = 32,
			Addr = "충남",
			Birth = new DateTime(1545, 4, 28),
			Tel = "그런거 없을 걸..."
		};
		var Profile = new { Lee.Name, Lee.Birth };
		var Profile2 = new { Irum = Lee.Name, Saengil = Lee.Birth };
		Console.WriteLine("이름 : " + Profile.Name + ", 생일 : " + Profile.Birth);
	}
}
