using System;

class GuGu
{
	public int this[int r, int c]
	{
		get
		{
			return (r * c);
		}
	}
}

class CSTest
{
	static void Main()
	{
		GuGu G = new GuGu();
		Console.WriteLine("3 * 8 = {0}", G[3, 8]);
	}
}
