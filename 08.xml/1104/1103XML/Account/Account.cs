using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wb.XMLPaser
{
    class Account
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public int Balance { get; private set; }

        public Account(int id, string name, int balance)
        {
            Id      = id;
            Name    = name;
            Balance = balance;
        }

        //파싱코드
        public static Account MakeAccount(XmlReader xr)
        {
            int accid   = int.Parse(xr.GetAttribute("accid"));
            string name = xr.GetAttribute("name");
            int balance = int.Parse(xr.GetAttribute("balance")); 

            return new Account(accid, name, balance);
        }

        public override string ToString()
        {
            return Id + ", " + Name + ", " + Balance;
        }
    }
}
