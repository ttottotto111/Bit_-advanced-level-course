using System;
using System.Collections.Generic;

namespace _1008
{
    class Program
    {
        private List<Member> memlist = new List<Member>();

        public void SampleDataInput()
        {
            memlist.Add(new Member(10, "김승욱", 80));
            memlist.Add(new Member(5, "김길동", 80));
            memlist.Add(new Member(65, "이길동", 80));
            memlist.Add(new Member(57, "박길동", 80));
            memlist.Add(new Member(9, "나길동", 80));
            memlist.Add(new Member(20, "고길동", 80));

        }

        public void SortTest()
        {
            //memlist.Sort(); //ID
            memlist.Sort(new NameMemberComparer("DOWN")); //
        }

        public void PrintData()
        {
            foreach(Member mem in memlist)
            {
                Console.WriteLine(mem);
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.SampleDataInput();
            p.SortTest();
            p.PrintData();
        }
    }
}
