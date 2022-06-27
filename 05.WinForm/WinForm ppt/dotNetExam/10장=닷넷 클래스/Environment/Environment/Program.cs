using System;

class CSTest
{
	static void Main()
	{
		Console.WriteLine("MachineName : " + Environment.MachineName);
		Console.WriteLine("UserName : " + Environment.UserName);
		Console.WriteLine("Version : " + Environment.Version);
		Console.WriteLine("WorkingSet : " + Environment.WorkingSet);
		Console.WriteLine("CurrentDirectory : " + Environment.CurrentDirectory);
		Console.WriteLine("SystemDirectory : " + Environment.SystemDirectory);
		Console.WriteLine("OSVersion : " + Environment.OSVersion);
		Console.WriteLine("ProcessorCount : " + Environment.ProcessorCount);
		Console.WriteLine("TickCount : " + Environment.TickCount);
		Console.WriteLine("UserDomainName : " + Environment.UserDomainName);

		Console.WriteLine("내 문서 폴더 : " + Environment.GetFolderPath(
			Environment.SpecialFolder.MyDocuments));
	}
}
