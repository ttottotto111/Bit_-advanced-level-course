using System;

class CSTest
{
	public static void Main()
	{
		ConsoleKeyInfo cki;
		int x = 40, y = 12;
		for (; ; )
		{
			Console.Clear();
			Console.SetCursorPosition(x, y);
			Console.Write('#');
			cki = Console.ReadKey(true);
			switch (cki.Key)
			{
				case ConsoleKey.LeftArrow:
					x--;
					break;
				case ConsoleKey.RightArrow:
					x++;
					break;
				case ConsoleKey.UpArrow:
					y--;
					break;
				case ConsoleKey.DownArrow:
					y++;
					break;
				case ConsoleKey.Q:
					return;
			}
		}
	}
}
