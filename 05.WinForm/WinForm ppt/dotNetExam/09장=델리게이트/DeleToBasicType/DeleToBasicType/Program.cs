using System;

delegate void dLong(long a);
delegate void dInt(int a);

class CSTest
{
	public static void GetLong(long a) { }
	public static void GetInt(int a) { }
	static void Main()
	{
		dLong dl;
		dl = GetLong;
		//dl = GetInt;

		dInt di;
		//di = GetLong;
		di = GetInt;
	}
}
