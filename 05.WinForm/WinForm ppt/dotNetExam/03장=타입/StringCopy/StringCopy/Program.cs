using System;

class CSTest
{
	static void Main()
	{
		string s1 = "텔레토비";
		string s2 = s1;
		s2 = "마시마로";
		Console.WriteLine("s1={0}, s2={1}", s1, s2);

		string s3 = "로보트 태권 V";
		string s4 = "로보트 태권 V";
		Console.WriteLine("문자열의 경우 : " + (s3 == s4 ? "같다" : "다르다"));
	}
}
