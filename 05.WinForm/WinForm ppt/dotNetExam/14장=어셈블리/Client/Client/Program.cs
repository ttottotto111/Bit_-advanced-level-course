using System;
using Server;

//*
class CSTest
{
	static void Main()
	{
		Console.WriteLine("3 + 2 = {0}", IntCalc.Add(3, 2));
		Console.WriteLine("3 - 2 = {0}", IntCalc.Sub(3, 2));
		Console.ReadLine();
	}
}
//*/

/*
class IntCalc2 : IntCalc
{
	public static void OutMessage()
	{
		Console.WriteLine("새로 추가한 메시지 출력 메서드입니다.");
	}
}

class CSTest
{
	static void Main()
	{

		Console.WriteLine("3 + 2 = {0}", IntCalc2.Add(3, 2));
		Console.WriteLine("3 - 2 = {0}", IntCalc2.Sub(3, 2));
		IntCalc2.OutMessage();
		Console.ReadLine();
	}
}
//*/
