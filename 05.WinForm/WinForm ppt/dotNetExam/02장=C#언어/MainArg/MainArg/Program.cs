class FirstCon
{
	static void Main(string[] args)
	{
		if (args.Length != 2)
		{
			System.Console.WriteLine("반드시 두 개의 인수가 필요합니다.");
			return;
		}
		System.Console.WriteLine("{0}를 {1}로 복사합니다.", args[0], args[1]);
	}
}
