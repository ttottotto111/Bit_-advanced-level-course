using System;

class CSTest
{
	static void Main()
	{
		string str = "123456789";
		Console.WriteLine("최초 : " + str);
		str = str.Insert(3, "abcd");
		Console.WriteLine("삽입 : " + str);
		str = str.Remove(5, 4);
		Console.WriteLine("삭제 : " + str);
		str = str.Replace('8', '팔');
		Console.WriteLine("대체 : " + str);
	}
}
