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
        private Socket server;
        private List<Socket> socketlist = new List<Socket>();

        /// <summary>
        /// 대기소켓 create, bind, listen, accept(thread기반)
        /// </summary>
        /// <param name="port">서버소켓 생성시 사용될 포트번호</param>
        public bool StartServer(int port)
        {
            try
            {
                CreateSocket(port);

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
        private void CreateSocket(int port)
        {
            server = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
            server.Bind(ipep);
            server.Listen(20);
        }

        //Thread 함수
        private void ListenThread()
        {
           while(true)
            {
                try
                {
                    //1. accept함수 호출
                    Socket clientsock = Accept();

                    //2. 생성된 통신 소켓 저장
                    socketlist.Add(clientsock);

                    //3. 통신thread 생성
                    Thread th = new Thread(new ParameterizedThreadStart(WorkThread));
                    th.Start(clientsock);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("[Accept에러]" + ex.Message);
                }
            }
        }

        private Socket Accept()
        {
            IPEndPoint curip = (IPEndPoint)server.LocalEndPoint;
            Console.WriteLine("서버 시작... 클라이언트 접속 대기중...");
            //Console.WriteLine("서버 주소 - {0}:{1}", curip.Address, curip.Port);//>
            Console.WriteLine("서버 주소 - {0}:{1}", "  61.81.98.100", curip.Port);//>

            //client : 통신소켓
            Socket client = server.Accept();  // 클라이언트 접속 대기

            // 접속한 클라이언트 아이피 주소와 접속 포트번호 출력
            IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("{0}주소, {1}포트 접속", ip.Address, ip.Port);

            return client;
        }

        private void WorkThread(object obj)
        {
            Socket clientsock = (Socket)obj;

            while(true)
            {
               
                byte[] recvbyte = null;

                //수신
                if (ReceiveData(clientsock, ref recvbyte) == false)
                    break;

                //1대 다 전송==============================================
                foreach(Socket s in socketlist)
                {
                    SendData(s, recvbyte);
                }
            }

            //소켓 종료 처리
            socketlist.Remove(clientsock);
            clientsock.Close();
        }

        #endregion

        #region 수신 & 송신
       
        private bool ReceiveData(Socket sock, ref byte[] data)
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // 수신할 데이터 크기 알아내기 
                byte[] data_size = new byte[4];
                recv_data = sock.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                data = new byte[size];

                // 실제 데이터 수신
                while (total < size)
                {
                    recv_data = sock.Receive(data, total, left_data, 0);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void SendData(Socket sock, byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int left_data = size;
                int send_data = 0;

                // 전송할 데이터의 크기 전달
                byte[] data_size = new byte[4];
                data_size = BitConverter.GetBytes(size);
                send_data = sock.Send(data_size);

                // 실제 데이터 전송
                while (total < size)
                {
                    send_data = sock.Send(data, total, left_data, SocketFlags.None);
                    total += send_data;
                    left_data -= send_data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
