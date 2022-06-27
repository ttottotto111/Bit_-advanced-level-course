using System;

class CSTest
{
	public static void Main()
	{
		Console.Title = "콘솔 테스트";
		Console.BackgroundColor = ConsoleColor.Blue;
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.Clear();
		Console.Beep();
		Console.WriteLine("색상을 변경했습니다.");
		Console.ReadLine();
		Console.ResetColor();
		Console.SetCursorPosition(10, 10);
		Console.WriteLine("디폴트 색상입니다.");
		Console.ReadLine();
	}
}
