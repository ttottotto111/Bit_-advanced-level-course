using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027
{
    class BookBuy
    {
        public int Cid { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Addr { get; set; }

        public BookBuy(int cid, string sname, string phone, string addr)
        {
            Cid = cid;
            Name = sname;
            Phone = phone;
            Addr = addr;
        }
    }
}
