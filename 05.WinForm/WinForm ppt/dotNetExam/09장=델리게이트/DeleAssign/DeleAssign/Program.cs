using System;

delegate int dele(int a, string b);
delegate void deleout(int a, out int b);

class CSTest
{
	static void Main()
	{
		dele d1 = delegate(int a, string b) { return 0; };
		//dele d2 = delegate(double a) { return 0; };
		//dele d3 = delegate(int a, string b) { };
		dele d4 = delegate { return 0; };
		int k = d4(1, "abcd");

		deleout d5 = delegate(int a, out int b) { b = 0; };
		//deleout d6 = delegate { };
	}
}
