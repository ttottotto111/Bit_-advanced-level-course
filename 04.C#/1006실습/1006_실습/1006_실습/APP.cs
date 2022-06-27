using System;
using System.Collections.Generic;
using System.Text;

namespace 예약_관리_프로그램_10_06
{
    class APP
    {
		private MemManager manager = new MemManager();

		public void Init()
		{
			Console.Clear();
			Console.WriteLine("***********************************************");
			Console.WriteLine(" 주제 : C#을 예약_관리_프로그램            *"); 
			Console.WriteLine(" 날짜 : 2020.10.06                             *");
			Console.WriteLine(" 구현 : 강건                                  *");
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
					case ConsoleKey.F1: manager.MakeMember(); break;
					case ConsoleKey.F2: manager.SearchAllMember(); break;
					case ConsoleKey.F3: manager.EditMemberPhone(); break;
					case ConsoleKey.F4: manager.SelectMember(); break;
					case ConsoleKey.F5: manager.DeleteMember(); break;
					case ConsoleKey.F6: manager.ReserveBusSeat(); break;
					case ConsoleKey.F7: manager.CancelReserveBusSeat(); break;
					case ConsoleKey.F8: manager.SearchBusSeat(); break;
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
			Console.WriteLine("* [F1] 회원 등록                               *");
			Console.WriteLine("* [F2] 회원 전체 출력                          *");
			Console.WriteLine("* [F3] 회원 번호 수정                               *");
			Console.WriteLine("* [F4] 회원 검색                               *");
			Console.WriteLine("* [F5] 회원 탈퇴                               *");
			Console.WriteLine("* [F6] 좌석 예약                        *");
			Console.WriteLine("* [F7] 좌석 예약 취소                       *");
			Console.WriteLine("* [F8] 좌석 예약 검색                      *");
			Console.WriteLine("* [ESC] 프로그램 종료                          *");
			Console.WriteLine("***********************************************");
			manager.BusSeatPrint();
			Console.WriteLine("***********************************************");
		}

		private void fnEnter()
		{
			Console.WriteLine("Press Any Key\n");
			Console.ReadLine();
		}
	}
}
