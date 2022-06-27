using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012NET
{
    class Packet
    {
        public static byte[] InsertMember(string flag, string id, string name)
        {
            string msg = null;
            msg += "ACK_INSERTMEMBER\a";    // 회원 가입 요청 메시지
            msg += flag + "#";
            msg += id.Trim() + "#";
            msg += name.Trim();
            return Encoding.Default.GetBytes(msg);
        }

        public static byte[] LoginMember(string flag, string id, Member mem)
        {
            string msg = null;
            msg += "ACK_LOGINMEMBER\a";    // 회원 가입 요청 메시지
            if (flag == "S")
            {
                msg += flag + "#";
                msg += mem.Id + "#";
                msg += mem.Pw + "#";
                msg += mem.Name + "#";
                msg += mem.Age.ToString().Trim() + "#";
                msg += mem.Dt.ToString().Trim();
            }
            else
            {
                msg += flag + "#";
            }
            return Encoding.Default.GetBytes(msg);
        }

        public static byte[] LogOutMember(string flag)
        {
            string msg = null;
            msg += "ACK_LOGOUTMEMBER\a";    // 회원 가입 요청 메시지
            msg += flag;
           
            return Encoding.Default.GetBytes(msg);
        }

    }
}
