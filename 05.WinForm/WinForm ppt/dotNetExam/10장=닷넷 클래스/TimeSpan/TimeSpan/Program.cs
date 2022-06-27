using System;

class CSTest
{
	static void Main()
	{
		DateTime A = new DateTime(2006, 8, 13);
		DateTime B = new DateTime(2007, 6, 29);
		TimeSpan C = B - A;
		Console.WriteLine(C);

		A = new DateTime(2007, 1, 1);
		C = new TimeSpan(1000, 0, 0, 0);
		B = A + C;
		Console.WriteLine(B);
	}
}
