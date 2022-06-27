using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008실습
{
    class Member
    {
        public string Name { get; private set; }
        public string Addr { get; set; }
        public DateTime DTime { get; private set; }

        public Member(string name) : this(name, "")
        {
        }

        public Member(string name, string addr)
        {
            Name = name;
            Addr = addr;
            DTime = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}\t{3}",
                Name, Addr, DTime.ToLongDateString(), DTime.ToLongTimeString());
        }

        public void Print()
        {
            Console.WriteLine("[이름] " + Name);
            Console.WriteLine("[주소] " + Addr);
            Console.WriteLine("[날짜] " + DTime.ToShortDateString());
            Console.WriteLine("[시간] " + DTime.ToShortTimeString());
        }
    }
}
