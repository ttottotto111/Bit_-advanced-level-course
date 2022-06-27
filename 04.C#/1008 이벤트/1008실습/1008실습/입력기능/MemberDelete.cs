using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008실습
{
    class MemberDelete
    {
        public void DeletMember(Dictionary<string, Member> members, Member mem)
        {
            members.Remove(mem.Name);
        }

    }
}
