using System;
using System.Collections;

class Human
{
	private string Name;
	private int Age;
	public Human(string aName, int aAge)
	{
		Name = aName;
		Age = aAge;
	}
	public override bool Equals(object obj)
	{
		Human Other = (Human)obj;
		return (Name == Other.Name && Age == Other.Age);
	}
	public override int GetHashCode()
	{
		return Age + Name[0];
	}
}

class CSTest
{
	static void Main()
	{
		Hashtable ht = new Hashtable();
		Human A = new Human("이순신", 32);
		Human B = new Human("을지문덕", 35);
		Human C = new Human("김유신", 29);
		Human D = new Human("계백", 28);
		ht.Add(A, "과장");
		ht.Add(B, "부장");
		ht.Add(C, "대리");
		ht.Add(D, "대리");
		Console.WriteLine(ht[A]);
	}
}
