using System;

class Message
{
	private Message() { }
	public static void Warning()
	{
		Console.WriteLine("그렇게 하면 안 좋을 텐데...");
	}
	public static void Error()
	{
		Console.WriteLine("그렇게 하면 안 돼지!");
	}
	public static void Advice()
	{
		Console.WriteLine("요렇게 하는게 어때?");
	}
}

// class Message2 : Message { }

class CSTest
{
	static void Main()
	{
		// Message M = new Message();
		Message.Warning();
		Message.Error();
		Message.Advice();
	}
}
