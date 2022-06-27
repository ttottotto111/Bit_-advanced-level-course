using System;

class Base { }
class Derived : Base { }

delegate void dBase(Base a);
delegate void dDervied(Derived a);

class CSTest
{
	public static void GetBase(Base a) { }
	public static void GetDerived(Derived a) { }
	static void Main()
	{
		dBase db;
		db = GetBase;
		// db = GetDerived;

		dDervied dd;
		dd = GetBase;
		dd = GetDerived;
	}
}
