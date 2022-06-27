using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008실습
{
    class MemberSelectAll
    {
        public void SelectAllMember(Dictionary<string, Member> members)
        {
            Console.WriteLine("저장 개수 : " + members.Count);
            foreach(KeyValuePair<string, Member> pair in members)
            {
                Console.WriteLine("[{0}] {1}", pair.Key, pair.Value);
            }
        }
    }
}
