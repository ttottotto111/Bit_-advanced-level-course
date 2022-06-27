using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012NETClient
{
    class Program
    {
        public bool StartClient(string ip, int port)
        {
            return Control.Singleton.StartClient(ip, port);
        }

        public void Run()
        {
            while(true)
            {
                Console.Clear();
                if (Control.Singleton.IsLogin == false)
                {
                    MenuPrint();
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape: return;
                        case ConsoleKey.F1: Control.Singleton.InsertMember(); break;
                        case ConsoleKey.F2: Control.Singleton.LoginMember(); break;
                        case ConsoleKey.F3: Control.Singleton.LogOutMember(); break;
                        case ConsoleKey.F4: Control.Singleton.DelMember(); break;
                    }

                    Console.WriteLine("\n\n아무키나 누르세요......");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("====================================================================");
                    Console.WriteLine("exit 입력시 채팅종료");
                    Console.WriteLine("====================================================================");

                    while (true)
                    {
                        string smsg = Console.ReadLine();
                        if (smsg.Equals("exit") == true)
                        {
                            Control.Singleton.IsLogin = false;
                            break;
                        }
                        Control.Singleton.ShortMessage(smsg);
                    }
                }
            }
            //string buf = string.Empty;
            //while (true)
            //{
            //    if (InputData(ref buf) == false)
            //        break;

            //    if (server.SendData(buf) == false)
            //        break;
            //}

            //server.EndClient();
        }

        private bool InputData(ref string buf)
        {
            Console.WriteLine("[문자열입력]");
            buf = Console.ReadLine();
            if (buf == string.Empty)
                return false;

            if (buf.Length > 1024)
                throw new Exception("문자열의 크기가 너무 큽니다.");

            return true;
        }

        private void MenuPrint()
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("[ESC]프로그램 종료 [F1]회원가입 [F2]로그인 [F3]로그아웃 [F4]회원탈퇴");
            Console.WriteLine("====================================================================");
        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            //127.0.0.1
            if (pr.StartClient("61.81.98.100", 9000) == true)
                pr.Run();
        }
    }
}
