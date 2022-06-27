using System;
using System.Text.RegularExpressions;

class CSTest
{
	static void Main()
	{
		string str = "김상형, 김상민, 김철수, 박상형, 김미형, 김철부지형, 김형, 김상형님 ";
		MatchCollection Find = Regex.Matches(str, @"\b김\S+형\b");
		foreach (Match M in Find)
		{
			Console.WriteLine(M.Value);
		}
	}
}
