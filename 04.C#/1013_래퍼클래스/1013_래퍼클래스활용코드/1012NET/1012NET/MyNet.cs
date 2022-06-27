using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Text;

namespace _1012NET
{
    class MyNet
    {
        public static void fun1()
        {
            // IPEndPoint
            // 로컬 주소를 바인드 하거나 소켓과 원격 주소를 연결할 때 사용
            IPAddress ex = IPAddress.Parse("61.81.98.44");
            IPEndPoint ie = new IPEndPoint(ex, 8000);

            Console.WriteLine("ToString()    : {0}", ie.ToString());
            Console.WriteLine("AddressFamily : {0}", ie.AddressFamily);
            Console.WriteLine("Address       : {0}", ie.Address);
            Console.WriteLine("Port          : {0}", ie.Port);
            Console.WriteLine("MaxPort:{0}MinPort:{1}", IPEndPoint.MaxPort, IPEndPoint.MinPort);

        }

        #region 네트워크 정보 출력
        public static void fun2()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                GatewayIPAddressInformationCollection Gatewayaddresses =
                        adapterProperties.GatewayAddresses;
                IPAddressCollection dhcpServers = adapterProperties.DhcpServerAddresses;
                IPAddressCollection dnsServers = adapterProperties.DnsAddresses;

                Console.WriteLine("네트워크 카드 : " + adapter.Description); // 네트워크 정보
                Console.WriteLine("  Physical Address ........... : " + adapter.GetPhysicalAddress());
                Console.WriteLine("  IP Address ................. : " + Get_MyIP());

                // Gateway 정보 출력
                if (Gatewayaddresses.Count > 0)
                {
                    foreach (GatewayIPAddressInformation address in Gatewayaddresses)
                    {
                        Console.WriteLine("  Gateway Address ............ : " + address.Address.ToString());
                    }
                }
                // DHCP 정보 출력
                if (dhcpServers.Count > 0)
                {
                    foreach (IPAddress dhcp in dhcpServers)
                    {
                        Console.WriteLine("  DHCP Servers ............... : " + dhcp.ToString());
                    }
                }
                // DNS 정보 출력
                if (dnsServers.Count > 0)
                {
                    foreach (IPAddress dns in dnsServers)
                    {
                        Console.WriteLine("  DNS Servers ................ : " + dns.ToString());
                    }
                }
            }
        }
        // 자기 자신의 IP 정보 출력
        public static string Get_MyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }


        #endregion

        //서버 기본 코드
        public static void fun3()
        {           

            //1. 대기소켓 생성 ===============================================
            Socket server = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);
            //2. bind
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 7000);
            server.Bind(ipep);

            //3. listen 
            server.Listen(20);
            //===========================================================
            
            //4. Accept
            Console.WriteLine("서버 시작... 클라이언트 접속 대기중...");
            //client : 통신소켓
            Socket client = server.Accept();  // 클라이언트 접속 대기

            // 접속한 클라이언트 아이피 주소와 접속 포트번호 출력
            IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("{0}주소, {1}포트 접속", ip.Address, ip.Port);

            //5. send 
            //byte[] data = Encoding.Default.GetBytes("환영합니다.*^^*");
            string msg = "환영합니다.*^^*";
            byte[] data = Encoding.Default.GetBytes(msg);
            client.Send(data, data.Length, SocketFlags.None); 

            //6. recv
            data = new byte[1024];
            if (client.Receive(data) != 0)  // 수신한 문자열이 있으면 화면에 출력
                Console.WriteLine("수신 메시지: " + Encoding.Default.GetString(data));
            else
                Console.WriteLine("수신 데이터 없음...");

            //7. 소켓 연결 끊기
            client.Close();         
            server.Close();
        }

        //클라이언트 기본 코드
        public static void fun4()
        {
            try
            {
                //1. 소켓 생성(서버랑 동일한)
                Socket server = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Stream, ProtocolType.Tcp);

                //2. 연결 "61.81.98.100"
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
                server.Connect(ipep);  // 127.0.0.1 서버 7000번 포트에 접속시도
                Console.WriteLine("서버에 접속...");  // 만약 서버 접속이 실패하면 예외 발생

                //3. recive
                byte[] data = new byte[1024];
                server.Receive(data);
                Console.WriteLine("수신 데이터: " + Encoding.Default.GetString(data));

                //4. send
                server.Send(Encoding.Default.GetBytes("데이터 전송..."));

                //5. close
                server.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //byte[] string 변환
        public static void fun5()
        {
            string msg = "hello 한글처리!!!";
            byte[] byte1 = Encoding.Default.GetBytes(msg);
            Console.WriteLine(byte1.Length);

            string msg1 = Encoding.Default.GetString(byte1);
            Console.WriteLine(msg1);
        }

        Socket client;
        //크기 + 데이터  전송
        private void SendData(byte[] data)
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
                send_data = this.client.Send(data_size);

                // 실제 데이터 전송
                while (total < size)
                {
                    send_data = this.client.Send(data, total, left_data, SocketFlags.None);
                    total += send_data;
                    left_data -= send_data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //크기 + 데이터 수신
        private void ReceiveData(byte[] data)
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // 수신할 데이터 크기 알아내기 
                byte[] data_size = new byte[4];
                recv_data = this.client.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                data = new byte[size];

                // 실제 데이터 수신
                while (total < size)
                {
                    recv_data = this.client.Receive(data, total, left_data, 0);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
