using System;

namespace _1005_hw
{
    class Account
    {
        private int m_id;
        private int m_balance;
        private string m_name;

        public Account() { }

        public Account(int id, string name, int bal)
        {
            this.M_Id = id;
            this.M_Balance = bal;
            this.M_Name = name;
        }

        public int M_Id
        {
            get { return m_id; }
            private set { m_id = value; }
        }
        public int M_Balance
        {
            get { return m_balance; }
            private set { m_balance = value; }
        }
        public string M_Name
        {
            get { return m_name; }
            private set { m_name = value; }
        }

        public void AddMoney(int val)
        {
            m_balance += val;
        }
        public void MinMoney(int val)
        {
            m_balance -= val;
        }

        public void ShowAllData()
        {
            Console.WriteLine("[ID] " + M_Id);
            Console.WriteLine("[이름] " + M_Name);
            Console.WriteLine("[잔액] " + M_Balance);
        }
    }
}
