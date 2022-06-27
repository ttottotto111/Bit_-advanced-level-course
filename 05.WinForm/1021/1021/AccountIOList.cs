using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1021
{
    /// <summary>
    /// 계좌거래 리스트
    /// </summary>
    
    class AccountIOList
    {
        #region 프로퍼티
        private readonly string id;
        public string Id { get { return id; } }

        private readonly int input;
        public int Input { get { return input; } }

        private readonly int output;
        public int Output { get { return output; } }

        private readonly int balance;
        public int Balance { get { return balance; } }

        private readonly DateTime stime;
        public DateTime Stime { get { return stime; } }
        public string StimeDay { get { return stime.ToShortDateString(); } }
        public string StimeTime { get { return stime.ToShortTimeString(); } }
        #endregion

        #region 생성자

        public AccountIOList(string _id, int _input, int _output, int _balance)
        {
            id = _id;
            input = _input;
            output = _output;
            balance = _balance;
            stime = DateTime.Now;
        }

        #endregion
    }
}
