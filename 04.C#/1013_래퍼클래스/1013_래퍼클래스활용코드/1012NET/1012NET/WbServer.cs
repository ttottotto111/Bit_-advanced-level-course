using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1012NET
{
    class WbServer
    {
        //private Socket server;
        private TcpListener server;
        private List<TcpClient> socketlist = new List<TcpClient>();

        /// <summary>
        /// 대기소켓 create, bind, listen, accept(thread기반)
        /// </summary>
        /// <param name="port">서버소켓 생성시 사용될 포트번호</param>
        public bool StartServer(int port)
        {
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);  // TCP 7000번 포트 열기
                server.Start();

                Thread thread = new Thread(new ThreadStart(ListenThread));
                //thread.IsBackground = true;
                thread.Start();// 스레드 실행

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[에러]" + ex.Message);
                return false;
            }
        }

        #region StartServer에서 내부적으로 호출하는 함수들(시작 함수)
        

        //Thread 함수
        private void ListenThread()
        {
           while(true)
            {
                try
                {
                    //1. accept함수 호출
                    TcpClient client = server.AcceptTcpClient();

                    //2. 생성된 통신 소켓 저장
                    socketlist.Add(client);

                    //3. 통신thread 생성
                    Thread th = new Thread(new ParameterizedThreadStart(WorkThread));
                    th.Start(client);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("[Accept에러]" + ex.Message);
                }
            }
        }
               

        private void WorkThread(object obj)
        {
            TcpClient clientsock = (TcpClient)obj;
            NetworkStream ns = clientsock.GetStream();

            try
            {
                while (true)
                {

                    byte[] recvbyte = new byte[1024];

                    ns.Read(recvbyte, 0, recvbyte.Length);

                    //1대 다 전송==============================================
                    foreach (TcpClient s in socketlist)
                    {
                        ns.Write(recvbyte, 0, recvbyte.Length);
                    }
                }
            }
            catch(Exception ex)
            {
                //소켓 종료 처리
                Console.WriteLine("소켓 송수신에러 : " + ex.Message);
                socketlist.Remove(clientsock);
                clientsock.Close();
            }            
        }

        #endregion


       
        
    }
}
