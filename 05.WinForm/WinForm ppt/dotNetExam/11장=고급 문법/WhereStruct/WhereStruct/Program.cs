using System;

class Wrapper<T> where T : struct
{
	T Value;
	public Wrapper() { Value = default(T); }
	public Wrapper(T aValue) { Value = aValue; }
	public T Data
	{
		get { return Value; }
		set { Value = value; }
	}
	public void OutValue()
	{
		Console.WriteLine(Value);
	}
}

class CSTest
{
	static void Main()
	{
		Wrapper<int> gi = new Wrapper<int>(1234);
		gi.OutValue();
		//Wrapper<string> gs = new Wrapper<string>("문자열");
		//gs.OutValue();
	}
}
