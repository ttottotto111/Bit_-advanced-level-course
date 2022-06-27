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
        static void Main(string[] args)
        {
            WbServer server = new WbServer();
            server.StartServer(9000);
        }
    }
}
