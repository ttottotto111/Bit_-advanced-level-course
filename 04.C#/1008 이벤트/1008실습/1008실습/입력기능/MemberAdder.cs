using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008실습
{
    /// <summary>
    /// 사용자로부터 객체 저장 정보를 입력받아 Member 반환
    /// </summary>
    class MemberAdder
    {        
        public Member GetInsertMember(Dictionary<string, Member> members)
        {
            Console.Write("이름을 입력하세요 : ");
            string name = Console.ReadLine();

            NameCheck(members, name);

            Console.Write("주소를 입력하세요 : ");
            string addr = Console.ReadLine();

            InputDataCheck(name, addr);

            return new Member(name, addr);
        }
        
        private void NameCheck(Dictionary<string, Member> members, string name)
        {
            if(members.ContainsKey(name) == true)
            {
                throw new Exception("동일 이름이 존재합니다");
            }
        }

        private void InputDataCheck(string name, string addr)
        {
            if (name.Length == 0)
                throw new Exception("이름이 입력되지 않았습니다");
            if(addr.Length == 0)
                throw new Exception("주소가 입력되지 않았습니다");
        }
    }
}
