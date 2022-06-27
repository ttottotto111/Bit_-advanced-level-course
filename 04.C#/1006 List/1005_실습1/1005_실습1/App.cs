using System;

namespace _1005_실습1
{
    class App
    {
		private AccManager manager = new AccManager();
	
		public void Init()
        {
			Console.Clear();
			Console.WriteLine("***********************************************");
			Console.WriteLine(" 주제 : C#을 이용한 프로그램 실습             *");
			Console.WriteLine(" 날짜 : 2020.10.5                             *");
			Console.WriteLine(" 구현 : 김승욱                                  *");
			Console.WriteLine("***********************************************");
			Console.ReadKey();
		}
		public void Run()
        {
			ConsoleKeyInfo ReadKey;
			while (true)
			{
				Console.Clear();
				MenuPrint();
				ReadKey = Console.ReadKey();
				switch (ReadKey.Key)
				{
					case ConsoleKey.F1: manager.MakeAccount(); break;
					case ConsoleKey.F2: manager.SearchAllAccount(); break;
					case ConsoleKey.F3: manager.Deposit(); break;
					case ConsoleKey.F4: manager.Withdraw(); break;
					case ConsoleKey.F5: manager.SelectAccount(); break;
					case ConsoleKey.F6: manager.DeleteAccount(); break;
					case ConsoleKey.Escape: return;
					//default: Console.WriteLine("Not defined menu"); break;
				}
                fnEnter();
            }
		}
		public void Exit()
		{
			Console.Clear();
			Console.WriteLine("***********************************************");
			Console.WriteLine("*프로그램을 종료합니다.                       *");
			Console.WriteLine("***********************************************");
		}
		private void MenuPrint()
        {
			Console.WriteLine("***********************************************");
			Console.WriteLine("* [F1] 계좌 개설                               *");
			Console.WriteLine("* [F2] 계좌 전체 출력                          *");
			Console.WriteLine("* [F3] 계좌 입금                               *");
			Console.WriteLine("* [F4] 계좌 출금                               *");
			Console.WriteLine("* [F5] 계좌 조회                               *");
			Console.WriteLine("* [F6] 개설된 계좌 삭제                        *");
			Console.WriteLine("* [ESC] 프로그램 종료                          *");
			Console.WriteLine("***********************************************");
		}

        private void fnEnter()
        {
            Console.WriteLine("Press Any Key\n");
            Console.ReadLine();
        }
    }
}
