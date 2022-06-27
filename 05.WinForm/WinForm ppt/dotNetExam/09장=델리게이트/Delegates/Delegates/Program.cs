﻿using System;

delegate int delea(string s);
delegate double deleb(int i, long l);
delegate void delec(char ch);

class CSTest
{
	public static int a(string s) { Console.WriteLine(s); return 0; }
	public static double b(int i, long l) { Console.WriteLine(i); return 1.0; }
	public static void c(char ch) { Console.WriteLine(ch); }

	static void Main()
	{
		delea da = a;
		da("a 메서드");
		deleb db = b;
		db(1234, 5678);
		delec dc = c;
		dc('델');
	}
}
