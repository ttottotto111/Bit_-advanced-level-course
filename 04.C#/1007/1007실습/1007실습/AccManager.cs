using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace _1007실습
{
    class AccManager
    {
        //key : 계좌id, value : Account
        private Dictionary<int, Account> accounts  = new Dictionary<int, Account>();

        //거래 리스트
        private List<AccList> acclists = new List<AccList>();

        #region 거래리스트 기능

        private void InsertAccList(int id, int input, int output, int balance)
        {
            AccList acc = new AccList(id, input, output, balance);
            acclists.Add(acc);
        }

        private void SelectAccList(int id, ref List<AccList> list)
        {
            foreach(AccList acc in acclists)
            {
                if(acc.Id == id)
                {
                    list.Add(acc);
                }
            }
        }

        private void DeleteAccList(int id)
        {
            foreach(AccList ac in acclists)
            {
                if(ac.Id ==id)
                {
                    acclists.Remove(ac);
                }
            }
        }

        #endregion

        #region 계좌기능

        //동일한 계좌번호가 저장요청했을 때 예외를 발생 
        private void SearchSameAcc(int id)
        {
            if (accounts.ContainsKey(id) == true)
                throw new Exception("중복된 ID가 있습니다.");
        }

        public void MakeAccount()              // 계좌 개설을 위한 함수
		{
            try
            {
                Console.WriteLine("계좌 개설 -----------------");
                Console.WriteLine("[1]일반계좌 [2]신용계좌 [3]기부계좌");
                int select = WbGlobal.InputInteger("계좌선택");
                //------------------------------------------------
                int id = WbGlobal.InputInteger("계좌ID");
                SearchSameAcc(id);
                string name = WbGlobal.InputString("이름");
                int balance = WbGlobal.InputInteger("입금액");
                //-----------------------------------------------

                Account acc = null;
                switch (select)
                {
                    case 1: acc = new Account(id, name, balance);       break;
                    case 2: acc = new FaithAccount(id, name, balance);  break;
                    case 3: acc = new ContriAccount(id, name, balance); break;
                    default: throw new Exception("잘못된 계좌를 선택");
                }

                accounts.Add(acc.Id,acc);

                Console.WriteLine("계좌 개설이 완료되었습니다.");

                //거래 리스트를 저장
                InsertAccList(id, balance, 0, balance);
            }
            catch(Exception ex)
            {
                Console.WriteLine("계좌 개설이 실패했습니다.");
                Console.WriteLine("이유 : " + ex.Message);
            }
        }

		public void SearchAllAccount()       // 전체 저장정보 출력.순회
		{
            //for (int i = 0; i < acclist.Count; i++)
            //{
            //             Account acc = acclist[i];
            //	acc.ShowAllData1();
            //}

            Console.WriteLine("저장개수 : " + accounts.Count);
            Console.WriteLine("---------------------------------------");
            foreach (KeyValuePair<int, Account> kvp in accounts)
            {
                //Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
                Account acc = kvp.Value;
                Console.WriteLine(acc); //acc.toString()
            }
        }

		public void Deposit()                  // 입 금
		{
            try
            {
                int id = WbGlobal.InputInteger("계좌ID");
                int money = WbGlobal.InputInteger("입금액");

                Account acc = accounts[id]; 
                acc.AddMoney(money);
                Console.WriteLine("입금 완료");

                //거래리스트에 저장
                InsertAccList(id, money, 0, acc.Balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine("입금 에러가 발생했습니다.");
                Console.WriteLine("원인 : " + ex.Message);
            }
        }

        public void Withdraw()             // 출 금
		{
            try
            {
                int id = WbGlobal.InputInteger("계좌 ID");
                int money = WbGlobal.InputInteger("출금액");

                Account acc = accounts[id];
                acc.MinMoney(money);
                Console.WriteLine("출금완료");

                //거래리스트에 저장
                InsertAccList(id, 0, money, acc.Balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine("출금 에러가 발생했습니다.");
                Console.WriteLine("원인 : " + ex.Message);
            }
        }

        public void SelectAccount()
        {
            try
            {
                int id = WbGlobal.InputInteger("계좌ID");
                Account acc = accounts[id];
                acc.ShowAllData();

                //거래리스트 추가로 출력
                List<AccList> alist = new List<AccList>();
                SelectAccList(id, ref alist);
                Console.WriteLine("\n거래 내역");
                foreach(AccList ac in alist)
                {
                    Console.WriteLine(ac);      //ac.toString()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("계좌 조회 에러가 발생했습니다.");
                Console.WriteLine("이유 : " + ex.Message);
            }
        }

        //SelectAccount 참조
        //삭제할 계좌 ID를 입력받아 검색 후 삭제 : 삭제 함수는 MSDN찾기
        public void DeleteAccount()
        {
            try
            {
                int id = WbGlobal.InputInteger("계좌ID");
                if (accounts.Remove(id) == false)
                    throw new Exception("해당 계좌번호가 없습니다.");
                Console.WriteLine("삭제 완료");

                //거래 내역도 삭제
                DeleteAccList(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("삭제 에러가 발생했습니다.");
                Console.WriteLine("이유 : " + ex.Message);
            }
        }

        #endregion

        #region 파일 IO기능

        public void Init()
        {
            FileExample.Read2(ref accounts);
        }
        public void Exit()
        {
            FileExample.Write2(accounts);
        }
        #endregion
    }
}
