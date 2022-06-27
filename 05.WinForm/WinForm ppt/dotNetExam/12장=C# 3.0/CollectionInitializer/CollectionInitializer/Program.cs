using System;
using System.Collections.Generic;

class CSTest
{
	static void Main()
	{
		List<string> ar = new List<string> { "이승만", "박정희", "최규하" };
		foreach (var p in ar)
		{
			Console.WriteLine(p);
		}
	}
}
