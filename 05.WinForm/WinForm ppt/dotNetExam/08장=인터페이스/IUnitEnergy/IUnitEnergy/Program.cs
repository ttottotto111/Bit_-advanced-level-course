using System;

interface IUnit
{
	int Energy { get; }
}

class Marine : IUnit
{
	private int Life = 100;
	public int Energy
	{
		get { return Life; }
	}
}

class Zealot : IUnit
{
	private int Shield = 50;
	private int Life = 50;
	public int Energy
	{
		get { return Shield + Life; }
	}
}

class CSTest
{
	static void Main()
	{
		Marine M = new Marine();
	}
}
