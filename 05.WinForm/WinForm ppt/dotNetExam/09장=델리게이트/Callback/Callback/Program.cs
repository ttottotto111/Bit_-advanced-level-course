﻿using System;

class Archive
{
	public static void Compress(int nFile)
	{
		for (int i = 0; i < nFile; i++)
		{
			Console.WriteLine("{0}번째 파일을 압축하는 중이다...", i + 1);
			System.Threading.Thread.Sleep(500);
		}
	}
}

class CSTest
{
	static void Main()
	{
		Archive.Compress(10);
		Console.WriteLine("모든 파일을 압축했습니다.");
	}
}
