using System;
using System.Collections.Generic;
using System.Text;

namespace _1005_실습1
{
	class Account
	{
		readonly int id;	//생성자에서 초기화 수행
		int balance;
		string name;

        #region Get&Set
        public int Balance
        {
            get { return balance; }
            private set { balance = value; }
        }
        public int Id
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
		#endregion

		#region 생성자
		public Account(int id, string name, int balance)
		{
			this.id = id;
			Balance = balance;
			Name = name;
		}

		public Account(Account acc)
		{
			this.id = acc.Id;
			Balance = acc.Balance;
			Name = acc.Name;
		}
		#endregion

		#region 기능구현
		public void AddMoney(int val)
		{
			if (val < 0)
				throw new Exception("잘못된 금액입니다. " + val + "원");

			Balance += val;
		}

		public void MinMoney(int val)
		{
			if (val < 0)
				throw new Exception("잘못된 금액입니다. " + val + "원");
			if (val > Balance)
				throw new Exception("잔액이 부족합니다. " +"[잔액] "+Balance+"원" +"[요청액] "+ val + "원");
			Balance -= val;
		}

		public void ShowAllData()
		{
			Console.Write("[ID] " + Id);
			Console.Write(" [이름] " + Name);
			Console.Write(" [잔액] " + Balance);
		}
		public void ShowAllData1()
		{
			Console.Write("[ID] " + Id);
			Console.Write(" [이름] " + Name);
			Console.Write(" [잔액] " + Balance);
		}

		#endregion
	}
}
