using System;
using System.Collections.Generic;
using System.Linq;

class People
{
	public People(string aName, int aAge, bool aMale)
	{ Name = aName; Age = aAge; Male = aMale; }
	public string Name;
	public int Age;
	public bool Male;
}

class Sale
{
	public Sale(string aCustomer, string aItem, DateTime aODate)
	{ Customer = aCustomer; Item = aItem; ODate = aODate; }
	public string Customer;
	public string Item;
	public DateTime ODate;
}

class CSTest
{
	static void Main()
	{
		People[] arPeople = { new People("정우성", 36, true), new People("고소영", 32, 
			false) ,new People("배용준", 37, true), new People("김태희", 29, false) };
		Sale[] arSale = { new Sale("정우성", "면도기", new DateTime(2008,1,1)),
						  new Sale("고소영", "화장품", new DateTime(2008,1,2)),
						  new Sale("김태희", "핸드폰", new DateTime(2008,1,3)),
						  new Sale("김태희", "휘발유", new DateTime(2008,1,4)) };

		var Query = from p in arPeople
					join s in arSale on p.Name equals s.Customer
					select new { p.Name, p.Age, s.Item, s.ODate };
		foreach (var k in Query)
		{
			Console.WriteLine("{0}세의 {1}이(가) {2}을(를) {3}에 구입했음",
				k.Age, k.Name, k.Item, k.ODate);
		}
	}
}
