using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace _1012NETClient
{
    class Wb_client
    {
        private Socket client = null;

        public bool StartClient(string ip, int port)
        {
            try
            {
                CreateSocket(ip, port);        
                
                //수신 스레드 생성
                Thread thread = new Thread(new ParameterizedThreadStart(RecvThread));
                thread.Start(client);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러 ->" + ex.Message);
                return false;
            }
        }

        public bool SendData(string buf)
        {
            byte[] data = new byte[1024];
            data = Encoding.Default.GetBytes(buf);
            if (SendData(client, data) == false)
                return false;
            return true;
        }

        public void EndClient()
        {
            client.Close();
        }

        #region private
        private void CreateSocket(string ip, int port)
        {
            client = new Socket(AddressFamily.InterNetwork,
                                          SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);
            client.Connect(ipep);
            Console.WriteLine("서버 연결 성공");
        }

        private void RecvThread(object obj)
        {
            Socket clientSocket = (Socket)obj;
            while (true)
            {
                byte[] recvbyte = null;
                if (ReceiveData(clientSocket, ref recvbyte) == false)
                    break;
                Console.WriteLine("수신 메시지: " + Encoding.Default.GetString(recvbyte));
            }
        }
         
        #endregion

        #region 수신과 송신
        //수신
        private bool ReceiveData(Socket client, ref byte[] data)
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // 수신할 데이터 크기 알아내기 
                byte[] data_size = new byte[4];
                recv_data = client.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                data = new byte[size];

                // 실제 데이터 수신
                while (total < size)
                {
                    recv_data = client.Receive(data, total, left_data, 0);
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

        //전송
        private bool SendData(Socket client, byte[] data)
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
                send_data = client.Send(data_size);

                // 실제 데이터 전송
                while (total < size)
                {
                    send_data = client.Send(data, total, left_data, SocketFlags.None);
                    total += send_data;
                    left_data -= send_data;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion
    }
}
