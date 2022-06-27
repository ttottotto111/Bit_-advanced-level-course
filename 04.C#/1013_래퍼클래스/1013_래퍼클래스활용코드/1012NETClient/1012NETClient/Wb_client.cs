using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace _1012NETClient
{
    class Wb_client
    {
        //private Socket client = null;
        private TcpClient server;
        private NetworkStream ns;
        public bool StartClient(string ip, int port)
        {
            try
            {                
                server = new TcpClient(ip, port);  // 서버에 접속
                Console.WriteLine("서버 연결 성공");
                ns = server.GetStream();

                //수신 스레드 생성
                Thread thread = new Thread(new ThreadStart(RecvThread));
                thread.Start();

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
            try
            {
                byte[] data = new byte[1024];
                data = Encoding.Default.GetBytes(buf);
                ns.Write(data, 0, data.Length);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public void EndClient()
        {
         //   client.Close();
        }

        #region private        

        private void RecvThread()
        {
            byte[] myReadBuffer = new byte[1024];
            while (true)
            {
                ns.Read(myReadBuffer, 0, myReadBuffer.Length);

                Console.WriteLine("수신 메시지: " + Encoding.Default.GetString(myReadBuffer));
            }
        }
         
        #endregion


    }
}
