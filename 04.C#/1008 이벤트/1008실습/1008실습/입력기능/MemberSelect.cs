using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008실습
{
    class MemberSelect
    {
        public Member GetSelectMember(Dictionary<string, Member> members)        {
            Console.WriteLine("====회원 검색====");            Console.Write("이름을 입력하세요 : ");            string name = Console.ReadLine();

            NameCheck(members, name);

            return members[name];
        }

        private void NameCheck(Dictionary<string, Member> members, string name)        {            if (members.ContainsKey(name) == false)            {                throw new Exception("검색하신 이름은 존재하지 않습니다.");            }        }
    }

}
