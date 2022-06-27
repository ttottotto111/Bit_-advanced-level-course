using System;

class CSTest
{
	public static void Main()
	{
		string Name, sAge;
		int Age;
		Console.Write("이름을 입력하세요 : ");
		Name = Console.ReadLine();
		Console.WriteLine(Name);

		Console.Write("나이를 입력하세요 : ");
		sAge = Console.ReadLine();
		Age = Convert.ToInt32(sAge);
		Console.WriteLine(Age);
	}
}
