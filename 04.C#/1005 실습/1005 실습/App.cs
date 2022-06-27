using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1005_hw
{
	class App
	{
		AccManager manager = new AccManager();
		public void Init()
		{
			Logo();
		}

		/*
		MAKEACC   : 계좌 개설
		SEARCHALL : 전체 계좌 조회
		DEPOSIT   : 입금
		WITHDRAW  : 출금
		INQUIRE   : 잔액조회
		DELACC    : 계좌 삭제
		*/
		public void Run()
		{

			while (true)
			{
				Console.Clear();
				MenuPrint();
				ConsoleKeyInfo info = Console.ReadKey(true);
				switch (info.Key)
				{
					case ConsoleKey.F1: manager.MakeAccount(); break;
					case ConsoleKey.F2: manager.SearchAllAccount(); break;
					case ConsoleKey.F3: manager.Deposit(); break;
					case ConsoleKey.F4: manager.Withdraw(); break;
					case ConsoleKey.F5: Console.WriteLine("계좌 이름 입력 후 해당 계좌 정보 출력"); break;
					case ConsoleKey.F6: Console.WriteLine("계좌 이름 입력 후 해당 계좌 삭제"); break;
					case ConsoleKey.Escape: return;
					default: Console.WriteLine("Not defined menu"); break;
				}
			}
		}


		public void Exit()
		{
			Ending();
		}

		private void Logo()
		{
			Console.Clear();
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine(" 주제 : C#을 이용한 프로그램 실습             *");
			Console.WriteLine(" 날짜 : 2020.10.5                             *");
			Console.WriteLine(" 구현 : 김승욱                                *");
			Console.WriteLine("-----------------------------------------------");
			Console.ReadKey();
		}

		private void Ending()
		{
			Console.Clear();
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine(" 프로그램을 종료합니다.                       *");
			Console.WriteLine("-----------------------------------------------");
			Console.ReadKey();
		}

		private void MenuPrint()
		{
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("* [F1] 계좌 개설                               *");
			Console.WriteLine("* [F2] 계좌 전체 출력                          *");
			Console.WriteLine("* [F3] 계좌 입금                               *");
			Console.WriteLine("* [F4] 계좌 출금                               *");
			Console.WriteLine("* [F5] 계좌 조회                               *");
			Console.WriteLine("* [F6] 개설된 계좌 삭제                        *");
			Console.WriteLine("* [ESC] 프로그램 종료                          *");
			Console.WriteLine("-----------------------------------------------");
		}
	}
}
