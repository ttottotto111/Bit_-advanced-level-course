using System;

class CSTest
{
	static void Main()
	{
		Pixel p1 = new Pixel(1, 2, 3);
		Pixel p2 = p1;
		p2.Pos.x = 1234;
		p2.Color = 5678;
		p1.OutPixel();
		p2.OutPixel();
	}
}

struct Position
{
	public int x, y;
	public Position(int ax, int ay) { x = ax; y = ay; }
}

class Pixel
{
	public Position Pos;
	public int Color;
	public Pixel(int ax, int ay, int ac) { Pos = new Position(ax, ay); Color = ac; }
	public void OutPixel() { Console.WriteLine("x={0},y={1},Color={2}", Pos.x, Pos.y, Color); }
}
