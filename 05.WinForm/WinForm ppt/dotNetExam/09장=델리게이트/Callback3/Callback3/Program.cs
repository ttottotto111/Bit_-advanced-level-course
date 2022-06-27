using System;

class Archive
{
	public delegate bool CompProg(int nFile);
	public static bool Compress(int nFiles, CompProg Prog)
	{
		for (int i = 0; i < nFiles; i++)
		{
			if (Prog(i) == false)
			{
				return false;
			}
			System.Threading.Thread.Sleep(500);
		}
		return true;
	}
}

class CSTest
{
	public static bool Progress(int nFile)
	{
		Console.WriteLine("{0}번째 파일을 압축하는 중입니다(취소시 Esc).", nFile + 1);
		if (Console.KeyAvailable)
		{
			ConsoleKeyInfo cki;
			cki = Console.ReadKey(false);
			if (cki.Key == ConsoleKey.Escape)
			{
				return false;
			}

		}
		return true;
	}
	static void Main()
	{
		if (Archive.Compress(10, Progress) == true)
		{
			Console.WriteLine("모든 파일을 압축했습니다.");
		}
		else
		{
			Console.WriteLine("취소되었습니다.");
		}
	}
}
