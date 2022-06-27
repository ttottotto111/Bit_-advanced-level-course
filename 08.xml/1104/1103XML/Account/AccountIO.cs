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

        //파싱코드
        public static AccountIO MakeAccountIO(XmlReader xr)
        {
            int accid   = int.Parse(xr.GetAttribute("accid"));
            int input   = int.Parse(xr.GetAttribute("input"));
            int output  = int.Parse(xr.GetAttribute("output"));
            int balance = int.Parse(xr.GetAttribute("balance"));

            return new AccountIO(accid, input, output, balance);
        }

        public override string ToString()
        {
            return Id + ", " + Input + ", " + Output + ", " + Balance;
        }
    }
}
