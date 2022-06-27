using System;

class CSTest
{
	static void Main()
	{
		Random R = new Random();
		for (int i = 0; i < 100; i++)
		{
			Console.CursorLeft = R.Next(80);
			Console.CursorTop = R.Next(24);
			Console.Write('.');
		}
	}
}
