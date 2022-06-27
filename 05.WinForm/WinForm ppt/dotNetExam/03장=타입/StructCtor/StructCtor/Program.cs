using System;

class CSTest
{
	static void Main()
	{
		Book b = new Book("노점상으로 떼돈벌기", 10000);
		b.OutBook();
	}
}

struct Book
{
	public string Name;
	public int Price;
	public Book(string aName, int aPrice)
	{
		Name = aName;
		Price = aPrice;
	}
	public void OutBook()
	{
		Console.WriteLine("책 제목 : {0}, 가격 : {1}", Name, Price);
	}
}
