using System;

class CSTest
{
	static void Main()
	{
		string str = "나랏 말싸미 듕귁에 달아 문짜와로 서로 사맛디 아니할쌔";
		Console.WriteLine(str.IndexOf("문짜"));
		Console.WriteLine(str.IndexOf("미국"));
		Console.WriteLine(str.IndexOf('아'));
		Console.WriteLine(str.LastIndexOf('아'));
		Console.WriteLine(str.IndexOfAny(new char[] { '강', '아', '지' }));
	}
}
