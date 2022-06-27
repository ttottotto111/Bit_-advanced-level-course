using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008실습
{
    class MemberUpdate
    {
        public void UpdateAddr(Member mem)
        {
            Console.Write("주소 : ");            string addr = Console.ReadLine();            InputDataCheck(addr);            mem.Addr = addr;
        }

        private void InputDataCheck(string addr)        {            if (addr.Length == 0)                throw new Exception("주소가 입력되지 않았습니다.");        }
    }
}
