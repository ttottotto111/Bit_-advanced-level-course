using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//C# thread는 생성된 모든 thread가 종료되어야만 main thread가 죽는다. 
//만약, main이 죽으면 모든 thread를 죽이기 위해서는 thread 속성값을 변경....
// Thread thread = new Thread(new ThreadStart(ListenThread));
// thread.IsBackground = true;
// thread.Start();// 스레드 실행
namespace _1012NET
{
    class Program
    {
        public bool Init()
        {
            Logo();
            return Control.Singleton.Init();            
        }

        public void Exit()
        {
            Control.Singleton.Exit();
            Ending();
        }

        private void Logo()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine(" 서버 시작");
            Console.WriteLine(" 서버 IP   : 61.81.98.100");
            Console.WriteLine(" 서버 PORT : 9000");
            Console.WriteLine("***************************************************\n");
        }

        private void Ending()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("서버를 종료합니다.");
            Console.WriteLine("***************************************************");
        }

        static void Main(string[] args)
        {
            Program pr = new Program();
            if(pr.Init() == false)
                pr.Exit();                  
        }
    }
}
