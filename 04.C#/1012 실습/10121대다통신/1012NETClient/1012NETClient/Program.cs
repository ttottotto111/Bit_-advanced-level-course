using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012NETClient
{
    class Program
    {
        Wb_client server = new Wb_client();

        public bool StartClient(string ip, int port)
        {
            return server.StartClient(ip, port);
        }
        public void Run()
        {
            string buf = string.Empty;
            while (true)
            {
                if (InputData(ref buf) == false)
                    break;

                if (server.SendData(buf) == false)
                    break;
            }

            server.EndClient();
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

        static void Main(string[] args)
        {
            Program pr = new Program();  
            if(pr.StartClient("127.0.0.1", 9000) == true)
                pr.Run();
        }
    }
}
