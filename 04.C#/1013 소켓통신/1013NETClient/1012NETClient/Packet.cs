using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012NETClient
{
    class Packet
    {
        public static string InsertMember(Member mem)
        {
            string msg = null;
            msg += "PACKET_INSERTMEMBER\a";    // 회원 가입 요청 메시지
            msg += mem.Id.Trim() + "#"; 
            msg += mem.Pw.Trim() + "#";                 
            msg += mem.Name.Trim() + "#";                
            msg += mem.Age.ToString().Trim() + "#"; 
            msg += mem.Dt.ToString().Trim();  
            return msg;
        }

        public static string LoginMember(string id, string pw)
        {
            string msg = null;
            msg += "PACK_LOGIN\a";    // 로그인 메시지
            msg += id.Trim() + "#";
            msg += pw.Trim();
            return msg;
        }

        public static string LogOutMember(string id)
        {
            string msg = null;
            msg += "PACK_LOGOUT\a";    // 로그아웃 메시지
            msg += id.Trim();
            return msg;
        }

        public static string DelMember(string id)
        {
            string msg = null;
            msg += "PACK_DELMEMBER\a";    // 로그아웃 메시지
            msg += id.Trim();
            return msg;
        }

        public static string Shortmessage(string name, string smsg)
        {
            string msg = null;
            msg += "PACK_SHORTMESSAGE\a";    // 로그아웃 메시지
            msg += name.Trim() + "#";
            msg += smsg.Trim() + "#";
            msg += DateTime.Now.ToString();

            return msg;
        }
    }
}
