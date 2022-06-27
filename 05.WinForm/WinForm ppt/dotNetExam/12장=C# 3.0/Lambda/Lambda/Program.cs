using System;

delegate int dele(int a);

class CSTest
{
	static void Main()
	{
		dele d = a => a + 1;
		int k = d(3);
		Console.WriteLine("k = " + k);
	}
}
