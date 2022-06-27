using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027
{
    class Custom
    {
        public int CID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Addr { get; set; }

        public Custom(int _cid, string _name, string _phone, string _addr)
        {
            CID = _cid;
            Name = _name;
            Phone = _phone;
            Addr = _addr;
        }
    }
}
