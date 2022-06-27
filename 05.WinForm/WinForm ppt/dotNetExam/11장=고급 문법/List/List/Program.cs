using System;
using System.Collections.Generic;

class CSTest
{
	static void Main()
	{
		List<string> ar = new List<string>(10);
		ar.Add("이승만");
		ar.Add("박정희");
		ar.Add("최규하");
		//ar.Add(1234);
		//ar.Add(5.678);
		foreach (string s in ar) Console.Write(s + ",");
	}
}
