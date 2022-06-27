using System;

class CSTest
{
	static void Main()
	{
		string str = "This is a book.Good Moring";
		string[] word = str.Split(new Char[] { ' ', '.' });
		foreach (string W in word)
		{
			Console.WriteLine(W);
		}
	}
}
