using System;

class var
{
	public int Field;
}

class CSTest
{
	static void Main()
	{
		var a;
		a = new var();
		a.Field = 1234;

		Console.WriteLine(a.Field);
	}
}
