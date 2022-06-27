using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012NETClient
{
    class Member
    {
        public string Id { get; set; }   
        public string Pw { get; set;  }
        public string Name { get; set; }
        public int Age { get; set; }

        public DateTime Dt { get; set; }

        public Member() { }
        public Member(string id, string pw, string name, int age)
        {
            Id = id;
            Pw = pw;
            Name = name;
            Age = age;
            Dt = DateTime.Now;
        }

        public override string ToString()
        {
            String temp = String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                Id, Pw, Name, Age, Dt.ToLongDateString(), Dt.ToLongTimeString());
            return temp;
        }
    }
}
