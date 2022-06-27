using System;
using System.Collections;

class CSTest
{
	static void Main()
	{
		ArrayList ar = new ArrayList(10);
		ar.Add("이승만");
		ar.Add("박정희");
		ar.Add("최규하");
		ar.Add("전두환");
		ar.Add("노태우");
		ar.Add("김영삼");
		ar.Add("김대중");
		ar.Add("노무현");
		ar.Add("이명박");
		foreach (object o in ar) Console.Write(o + ",");
		ar.Sort();
		ar.Reverse();
		Console.WriteLine();
		foreach (object o in ar) Console.Write(o + ",");
	}
}
