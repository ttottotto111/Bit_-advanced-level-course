using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class CSTest
{
	static void Main()
	{
		var Files = from f in Directory.GetFiles("c:\\") select f;
		foreach (var f in Files)
		{
			Console.WriteLine("이름 : " + f);
		}
	}
}
