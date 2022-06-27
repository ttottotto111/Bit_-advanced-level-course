using System;

class CSTest
{
	static void Main()
	{
		int value = 3, vcopy = 3;
		Console.WriteLine("값 타입의 경우 : " + (value == vcopy ? "같다" : "다르다"));

		int[] ar = { 1, 2, 3, 4, 5 };
		int[] arcopy = { 1, 2, 3, 4, 5 };
		Console.WriteLine("참조 타입의 경우 : " + (ar == arcopy ? "같다" : "다르다"));
	}
}
