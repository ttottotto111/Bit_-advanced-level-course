using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1131정답지
{
    class App
    {
        #region 싱글톤
        private static App singleton;
        public static App Singleton { get{ return singleton; } }

        static App()
        {
            singleton = new App();
        }
        #endregion
    
        public ConsoleKey Print()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("[ESC] 프로그램 종료");
            Console.WriteLine("[F1] 입력기능");
            Console.WriteLine("[F2] 삭제기능");
            Console.WriteLine("[F3] 검색기능");
            Console.WriteLine("[F4] 수정기능");
            Console.WriteLine("-----------------------------------------------");

            return Console.ReadKey().Key;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();

                StuManager.Singleton.PrintAll();

                ConsoleKey key = Print();
                switch (key)
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F1: StuManager.Singleton.InsertStudent(); break;
                    case ConsoleKey.F2: StuManager.Singleton.DeleteStudent(); break;
                    case ConsoleKey.F3: StuManager.Singleton.SelectStudent(); break;
                    case ConsoleKey.F4: StuManager.Singleton.UpdateStudent(); break;
                }

                Console.WriteLine("아무키나 누르세요");
                Console.ReadKey();
            }          

        }
    
    }
}
