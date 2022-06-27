using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008실습
{
    class Application
    {
        #region 싱글톤
        //1. 생성자 은닉
        private Application() { }
        //2. 프로퍼티 선언
        static public Application Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static Application()
        {
            Singleton = new Application();
        }
        #endregion

        public void Run()
        {
            MemberManager mem = MemberManager.Singleton;
            EventViewer ev = new EventViewer();     //<===============

            while (true)
            {
                Console.Clear();
                MenuPrint();
                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F1: mem.AddMember();        break;
                    case ConsoleKey.F2: mem.SelectAllMember();  break;
                    case ConsoleKey.F3: mem.SelectMember();     break;
                    case ConsoleKey.F4: mem.UpdateMember();     break;
                    case ConsoleKey.F5: mem.DeleteMember();     break;
                }
                Console.WriteLine("\n\n아무키나 누르세요");
                Console.ReadKey();
            }
        }
        private void MenuPrint()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("[ESC] 프로그램 종료");
            Console.WriteLine("[F1] 회원 추가");
            Console.WriteLine("[F2] 회원 전체출력");
            Console.WriteLine("[F3] 회원 검색");
            Console.WriteLine("[F4] 회원 수정");
            Console.WriteLine("[F5] 회원 삭제");
            Console.WriteLine("----------------------------------------");
        }
    }
}
