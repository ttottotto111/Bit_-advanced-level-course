using System;
using System.Collections;

class CSTest
{
	public static IEnumerable IntIterator(int s, int e)
	{
		for (int i = s; i <= e; i++) yield return i;
	}
	static void Main()
	{
		foreach (int x in IntIterator(1, 9))
			foreach (int y in IntIterator(1, 9))
				Console.WriteLine("{0} * {1} = {2}", x, y, x * y);
	}
}
