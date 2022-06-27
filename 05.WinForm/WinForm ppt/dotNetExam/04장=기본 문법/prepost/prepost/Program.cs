using System;

class CSTest
{
	static void Main()
	{
		int i = 3, j = 3;
		Console.WriteLine("i={0}(전위), j={1}(후위)", ++i, j++);
		Console.WriteLine("i={0}, j={1}", i, j);
	}
}
