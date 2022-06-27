using System;

class Staff { }
class Manager : Staff { }
class Personnel : Staff { }
class Account : Staff { }
class Finance : Account { }

class CSTest
{
	static void Main()
	{
		Staff[] nojo = new Staff[100];
		nojo[0] = new Manager();
		nojo[1] = new Personnel();
		nojo[2] = new Account();
		nojo[3] = new Manager();
		nojo[4] = new Finance();
	}
}
