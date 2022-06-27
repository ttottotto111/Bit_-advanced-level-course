using System;
using System.Collections.Generic;
using System.Text;

namespace _1005_hw
{
    class AccManager
    {
        Account[] pArray;

        int index;

        public AccManager()
        {
            index = 0;
            pArray = new Account[100];
        }

        public void MakeAccount()
        {
            int id;
            string name;
            int balance;

            Console.WriteLine("***********************************************");
            Console.Write("계좌 ID : ");
            string tempid = Console.ReadLine();
            id = int.Parse(tempid);
            Console.Write("이   름 : ");
            name = Console.ReadLine();
            Console.Write("입 금 액 : ");
            string tempbal = Console.ReadLine();
            balance = int.Parse(tempbal);

            pArray[index++] = new Account(id, name, balance);
            fnEnter();
        }
        public void SearchAllAccount()
        {
            for (int i = 0; i < index; i++)
            {
                pArray[i].ShowAllData();
            }
            fnEnter();
        }
        public void Deposit()
        {
            int money;
            int id;
            Console.Write("계좌 ID : ");
            string tempid = Console.ReadLine();
            id = int.Parse(tempid);
            Console.Write("입 금 액 : ");
            string tempbal = Console.ReadLine();
            money = int.Parse(tempbal);

            for (int i = 0; i < index; i++)
            {
                if (pArray[i].M_Id == id)
                {
                    pArray[i].AddMoney(money);
                    Console.Write("입금완료");
                    fnEnter();
                    return;
                }
            }
            Console.Write("유효하지 않은 ID 입니다.");
            fnEnter();
        }
        public void Withdraw()
        {
            int money;
            int id;
            Console.Write("계좌 ID : ");
            string tempid = Console.ReadLine();
            id = int.Parse(tempid);
            Console.Write("출 금 액 : ");
            string tempbal = Console.ReadLine();
            money = int.Parse(tempbal);
            for (int i = 0; i < index; i++)
            {
                if (pArray[i].M_Id == id)
                {
                    if (pArray[i].M_Balance < money)
                    {
                        Console.Write("잔액부족");
                        fnEnter();
                        return;
                    }
                    pArray[i].MinMoney(money);
                    Console.Write("출금 완료");
                    fnEnter();
                    return;
                }
            }
            Console.Write("유효하지 않은 ID 입니다.");
            fnEnter();
        }
        private void fnEnter()
        {
            Console.WriteLine("Press Any Key");
            Console.ReadKey();
        }
    }
}
