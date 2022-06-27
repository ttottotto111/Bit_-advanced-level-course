using System;

class CSTest
{
	static void Main()
	{
		int value = 3, vcopy;
		vcopy = value;
		vcopy = 4;
		Console.WriteLine("value={0},vcopy={1}", value, vcopy);

		int[] ar, arcopy;
		ar = new int[] { 1, 2, 3, 4, 5 };
		arcopy = ar;
		arcopy[1] = 1234;
		Console.WriteLine("ar[1]={0},arcopy[1]={1}", ar[1], arcopy[1]);
	}
}
