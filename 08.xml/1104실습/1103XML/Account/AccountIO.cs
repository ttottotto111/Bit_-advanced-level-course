using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wb.XMLPaser
{
    class AccountIO
    {
        public int Id { get; private set; }
        public int Input { get; private set; }
        public int Output { get; private set; }
        public int Balance { get; private set; }
              
        public AccountIO(int id, int input, int output, int balance)
        {
            Id = id;
            Input = input;
            Output = output;
            Balance = balance;
        }

        public static AccountIO MakeDomAccountIO(XmlAttributeCollection col)
        {
            int accid = int.Parse(col["accid"].Value);
            int input = int.Parse(col["input"].Value);
            int output = int.Parse(col["output"].Value);
            int balance = int.Parse(col["balance"].Value);

            return new AccountIO(accid, input, output, balance);
        }

        public override string ToString()
        {
            return Id + ", " + Input + ", " + Output + ", " + Balance;
        }
    }
}
