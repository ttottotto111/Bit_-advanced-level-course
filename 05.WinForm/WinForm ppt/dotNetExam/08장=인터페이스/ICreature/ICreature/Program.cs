using System;

interface ICreature
{
	void Propagate();	 // 생물은 번식한다.
}

interface IPlant : ICreature
{
	void Flower();	   // 식물은 꽃을 피운다.
}

interface IAnimal : ICreature
{
	void Move();		// 동물은 이동한다.
}

class Lion : IAnimal
{
	public void Move() { Console.WriteLine("왔다리 갔다리"); }
	public void Propagate() { Console.WriteLine("이걸 어떻게 표현하지...^_^"); }
}

class CSTest
{
	static void Main()
	{
		Lion Simba = new Lion();
		Simba.Move();
	}
}
