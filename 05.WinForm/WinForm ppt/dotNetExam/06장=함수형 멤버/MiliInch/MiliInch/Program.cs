using System;

class Inch
{
	public double len;
	public Inch(double alen) { len = alen; }
	public void OutValue() { Console.WriteLine("{0:F2}인치", len); }
	public static implicit operator Mili(Inch i)
	{
		return new Mili((uint)(i.len * 25.4));
	}
	public static implicit operator Inch(Mili m)
	{
		return new Inch(m.len / 25.4);
	}
}

class Mili
{
	public uint len;
	public Mili(uint alen) { len = alen; }
	public void OutValue() { Console.WriteLine("{0}밀리", len); }
}

class CSTest
{
	static void Main()
	{
		Inch disk = new Inch(0);
		Mili shoes = new Mili(0);

		disk.len = 3.5;
		shoes = disk;
		shoes.OutValue();

		shoes.len = 275;
		disk = shoes;
		disk.OutValue();
	}
}
