using System;

class Base { }
class Derived : Base { }

delegate Base dBase();
delegate Derived dDervied();

class CSTest
{
	public static Base GetBase() { return new Base(); }
	public static Derived GetDerived() { return new Derived(); }
	static void Main()
	{
		dBase db;
		db = GetBase;
		db = GetDerived;

		dDervied dd;
		// dd = GetBase;
		dd = GetDerived;
	}
}
