using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012NET
{
    class Control
    {
        #region 싱글톤
        //1. 생성자 은닉
        private Control() { }
        //2. 프로퍼티 선언
        static public Control Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static Control()
        {
            Singleton = new Control();
        }
        #endregion

        private Dictionary<string, Member> memlist = new Dictionary<string, Member>();
        WbServer server = new WbServer();

        #region wbserver에서 수신된 데이터 처리
        public byte[] RecvData(byte[] recvbyte)
        {
            string msg = Encoding.Default.GetString(recvbyte);

            string[] filter = msg.Split('\a');
            if (filter[0].Equals("PACKET_INSERTMEMBER") == true)
            {
                return InsertMember(filter[1]);
            }
            else if (filter[0].Equals("PACK_LOGIN") == true)
            {
                return LoginMember(filter[1]);
            }
            else if (filter[0].Equals("PACK_LOGOUT") == true)
            {
                return LogOutMember(filter[1]);
            }
            else if(filter[0].Equals("PACK_SHORTMESSAGE") == true)
            {
                //파일에 저장
                return recvbyte;        //echo
            }
            return Encoding.Default.GetBytes("NON"); 
        }

        private byte[] InsertMember(string msg)
        {
            try
            {
                //객체 생성(역직렬화)
                string[] filter = msg.Split('#');
                Member mem = new Member()
                {
                    Id = filter[0],
                    Pw = filter[1],
                    Name = filter[2],
                    Age = int.Parse(filter[3]),
                    Dt = DateTime.Parse(filter[4])
                };

                //저장
                memlist.Add(filter[0], mem);
                Console.WriteLine("[회원가입]" + mem);

                //리턴 패킷 생성 반환(ID, NAME)
                return Packet.InsertMember("S", mem.Id, mem.Name);
            }
            catch(Exception )
            {
                return Packet.InsertMember("F", "NO", "NO");
            }
        }

        private byte[] LoginMember(string msg)
        {
            try
            {
                //객체 생성(역직렬화)
                string[] filter = msg.Split('#');
                string id = filter[0];
                string pw = filter[1];

                //로그인 여부 판단     
                Console.WriteLine("[로그인여부판단]" + id);
                Member mem = memlist[id];

                //리턴 패킷 생성 반환(ID, NAME)
                if (mem.Pw.Equals(pw) == true)  
                    return Packet.LoginMember("S", id, mem);
                else
                    return Packet.LoginMember("F", "", null);
            }
            catch (Exception)
            {
                return Packet.LoginMember("F", "", null);
            }
        }

        private byte[] LogOutMember(string msg)
        {
            try
            {
                //객체 생성(역직렬화)
                string[] filter = msg.Split('#');
                string id = filter[0];

                //로그인 여부 판단     
                Console.WriteLine("[로그아웃여부판단]" + id);
                Member mem = memlist[id];

                //리턴 패킷 생성 반환(ID, NAME)
                if (mem != null)
                    return Packet.LogOutMember("S");
                else
                    return Packet.LogOutMember("F");
            }
            catch (Exception)
            {
                return Packet.LogOutMember("F");
            }
        }
        #endregion 

        public bool Init()
        {
            return server.StartServer(9000);                
        }        

        public void Exit()
        {

        }
    }
}
