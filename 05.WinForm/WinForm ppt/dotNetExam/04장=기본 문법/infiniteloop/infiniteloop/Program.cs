using System;

class CSTest
{
	static void Main()
	{
		for (; ; )
		{
			Console.WriteLine("앗싸. 게임 한 판 하고");
			Console.WriteLine("또 할래(Y/N)?");
			ConsoleKeyInfo cki = Console.ReadKey();
			if (cki.Key == ConsoleKey.N) break;
			Console.WriteLine();
		}
	}
}
