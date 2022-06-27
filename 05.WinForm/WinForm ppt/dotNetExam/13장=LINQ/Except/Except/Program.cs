using System;
using System.Collections.Generic;
using System.Linq;

class CSTest
{
	static void Main()
	{
		var My = new List<string> { "맨발의 기봉이", "뚝방전설", "디워", "마파도2", "타짜" };
		var Your = new List<string> { "뚝방전설", "왕의 남자", "중천", "디워", "라디오 스타" };

		var Query = (from y in Your select y).Except(from m in My select m);
		foreach (var s in Query)
		{
			Console.WriteLine(s);
		}
	}
}
