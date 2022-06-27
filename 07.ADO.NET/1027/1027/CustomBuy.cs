using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027
{
    class CustomBuy
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int Price { get; set; }
        public string Dt { get; set; }

        public int Count { get; set; }

        public CustomBuy(int pid, string pname, int price, int count,string dt)
        {
            Pid = pid;
            Pname = pname;
            Price = price;
            Count = count;
            Dt = dt;
        }
    }
}
