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

        public static Account MakeDomAccount(XmlAttributeCollection col)
        {
            int accid = int.Parse(col["accid"].Value);
            string name = col["name"].Value;
            int balance = int.Parse(col["balance"].Value);

            return new Account(accid, name, balance);
        }

        public override string ToString()
        {
            return Id + ", " + Name + ", " + Balance;
        }
    }
}
