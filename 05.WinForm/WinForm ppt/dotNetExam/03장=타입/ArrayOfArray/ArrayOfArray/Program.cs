using System;

class CSTest
{
	static void Main()
	{
		int[,] ar2 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
		int[][] aar = new int[3][];
		aar[0] = new int[] { 1, 2, 3, 4 };
		aar[1] = new int[] { 5, 6 };
		aar[2] = new int[] { 7, 8, 9, 10, 11, 12 };
		Console.WriteLine(aar[0][1]);
	}
}
