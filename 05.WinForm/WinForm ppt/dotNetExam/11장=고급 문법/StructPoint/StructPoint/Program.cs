using System;

class CSTest
{
	static void Main()
	{
		Position Pos = new Position(10, 20);
		unsafe
		{
			Position* pPos;
			pPos = &Pos;
			Console.WriteLine((*pPos).x);
			Console.WriteLine(pPos->y);
		}
	}
}

struct Position
{
	public int x, y;
	public Position(int ax, int ay) { x = ax; y = ay; }
}
