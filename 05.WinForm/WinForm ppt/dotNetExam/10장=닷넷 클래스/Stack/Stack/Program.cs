using System;
using System.Collections;

class CSTest
{
	static void Main()
	{
		Stack st = new Stack();
		st.Push(1);
		st.Push(2);
		st.Push(3);

		Console.WriteLine(st.Pop());
		Console.WriteLine(st.Pop());
		Console.WriteLine(st.Pop());
	}
}
