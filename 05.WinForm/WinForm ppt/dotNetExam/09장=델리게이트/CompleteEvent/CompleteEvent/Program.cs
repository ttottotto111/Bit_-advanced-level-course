﻿using System;

delegate void Notice();
class Printer
{
	public void Print()
	{
		Console.WriteLine("수신된 데이터를 인쇄합니다.");
	}
}

class Receiver
{
	public event Notice OnComplete;
	public void Receive()
	{
		for (int i = 0; i < 100; i += 10)
		{
			Console.WriteLine(i + "% 수신중");
			System.Threading.Thread.Sleep(200);
		}
		if (OnComplete != null) OnComplete();
	}
}

class CSTest
{
	static void Main()
	{
		Printer P = new Printer();
		Receiver R = new Receiver();
		R.OnComplete += P.Print;
		R.Receive();
	}
}
