using System;

delegate int dele1(int a, int b);
delegate int dele2();
delegate void dele3();

class CSTest
{
	static void Main()
	{
		dele1 d1 = (x, y) => x + y;
		int b = d1(4, 5);
		Console.WriteLine("b = " + b);

		dele2 d2 = () => 1234;
		int c = d2();
		Console.WriteLine("c = " + c);

		dele3 d3 = () => { Console.WriteLine("명령문으로 된 람다"); };
		d3();
	}
}
