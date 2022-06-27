using System;
using System.Reflection;

namespace MySpace
{
	class Time
	{
		public int hour, min, sec;
		public Time(int h, int m, int s) { hour = h; min = m; sec = s; }
		public void OuTimeTypeime()
		{
			Console.WriteLine("현재 시간은 {0}시 {1}분 {2}초이다.", hour, min, sec);
		}
	}
}

class CSTest
{
	static void Main()
	{
		MySpace.Time Now = new MySpace.Time(1, 2, 3);
		Type TimeType = Now.GetType();
		//Type TimeType = Type.GetType("MySpace.Time");
		//Type TimeType = typeof(MySpace.Time);

		Console.WriteLine(TimeType.Name);
		Console.WriteLine(TimeType.FullName);
		Console.WriteLine(TimeType.Namespace);
		Console.WriteLine(TimeType.BaseType.Name);
		Console.WriteLine(TimeType.UnderlyingSystemType.Name);
		if (TimeType.IsValueType) { Console.WriteLine("값 타입입니다."); }

		FieldInfo[] TimeField = TimeType.GetFields();
		for (int i = 0; i < TimeField.Length; i++)
		{
			Console.WriteLine("{0}번째 필드 = {1}", i, TimeField[i].Name);
		}

		MethodInfo[] TimeMethod = TimeType.GetMethods();
		for (int i = 0; i < TimeMethod.Length; i++)
		{
			Console.WriteLine("{0}번째 메서드 = {1}", i, TimeMethod[i].Name);
		}
	}
}
