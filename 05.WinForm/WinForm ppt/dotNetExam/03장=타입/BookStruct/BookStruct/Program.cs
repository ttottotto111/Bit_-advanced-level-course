using System;

class CSTest
{
	static void Main()
	{
		Book b;
		b.Name = "노점상으로 떼돈벌기";
		b.Price = 10000;
		Console.WriteLine("책 제목 : {0}, 가격 : {1}", b.Name, b.Price);
	}
}

struct Book
{
	public string Name;
	public int Price;
}
