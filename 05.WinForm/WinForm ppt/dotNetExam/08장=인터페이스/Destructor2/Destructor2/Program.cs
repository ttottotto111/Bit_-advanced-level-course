using System;

class Socket : IDisposable
{
	private int SocketPort;
	public Socket(int port)
	{
		SocketPort = port;
		Console.WriteLine("{0} 포트로 소켓을 연결한다.", port);
	}
	public void Dispose()
	{
		SocketPort = 0;
		Console.WriteLine("소켓 연결을 해제한다.");
	}
}

class CSTest
{
	static void Main()
	{
		Socket S = new Socket(1234);
		Console.WriteLine("주거니 받거니 통신했다 치고...");
		S.Dispose();
	}
}
