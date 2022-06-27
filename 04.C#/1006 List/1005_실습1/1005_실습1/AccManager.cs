using System;
using System.Collections.Generic;
using System.Text;

namespace _1005_실습1
{
    class AccManager
    {
		private List<Account> acclist = new List<Account>();

		private void SerchSameAcc(int id)
        {
			foreach (Account acc in acclist)
			{
				if (acc.Id == id)
				{
					throw new Exception("중복된 ID");
				}
			}
		}

        public void MakeAccount()              // 계좌 개설을 위한 함수
		{
			try
			{
				Console.WriteLine("계좌 개설 -----------------");
				int id = WbGlobal.InputInteger("계 좌 ID");
				SerchSameAcc(id);	//중복된 ID 오류
				string name = WbGlobal.InputString("이    름");
				int balance = WbGlobal.InputInteger("입 금 액");

				Account acc = new Account(id, name, balance);
				acclist.Add(acc);
				Console.WriteLine("계좌 개설 성공.");
			}
			catch(Exception ex)
            {
				Console.WriteLine("계좌 개설 실패.");
				Console.WriteLine("실패 이유 : " + ex.Message);
			}
		}

		public void SearchAllAccount()         // 전체 저장정보 출력
		{
			//for (int i = 0; i < acclist.Count; i++)
			//{
			//	Account acc = acclist[i];
			//	acc.ShowAllData();
			//}

			Console.WriteLine("저장개수 : " + acclist.Count);
			Console.WriteLine("--------------------------------------------------");

			foreach(Account acc in acclist)
            {
				acc.ShowAllData1();
            }
		}

		public void Deposit()                  // 입 금
		{
			try
			{
				int id = WbGlobal.InputInteger("계좌 ID");
				int money = WbGlobal.InputInteger("입금액");

				foreach (Account acc in acclist)
				{
					if (acc.Id == id)
					{
						acc.AddMoney(money);
						Console.WriteLine("입금완료");
						return;
					}
				}
				throw new Exception("유효하지 않은 ID 입니다.");
			}
			catch(Exception ex)
            {
				Console.WriteLine("입금 에러가 발생했습니다.");
				Console.WriteLine("원인 : "+ex.Message);
			}
		}

		public void Withdraw()				   // 출 금
		{
			try
			{
				int id = WbGlobal.InputInteger("계좌 ID");
				int money = WbGlobal.InputInteger("출금액");

				foreach(Account acc in acclist)
				{
					if(acc.Id == id)
                    {
						acc.MinMoney(money);
						Console.WriteLine("출금완료");
						return;
					}
                }
				throw new Exception("유효하지 않은 ID 입니다.");
			}
			catch(Exception ex)
            {
				Console.WriteLine("출금 에러가 발생했습니다.");
				Console.WriteLine("원인 : " + ex.Message);
			}
		}
        		
		public void SelectAccount()			   //검색
		{
			try
			{
				int id = WbGlobal.InputInteger("검색할 계좌 ID");

				foreach (Account acc in acclist)
				{
					if (acc.Id == id)
					{
						acc.ShowAllData();
						return;
					}
				}
				throw new Exception("유효하지 않은 ID 입니다.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("검색 에러가 발생했습니다.");
				Console.WriteLine("원인 : " + ex.Message);
			}
		}   

		public void DeleteAccount()			   //삭제
		{
			try
			{
				int id = WbGlobal.InputInteger("계 좌 ID");

				foreach (Account acc in acclist)
				{
					if (acc.Id == id)
					{
						acclist.Remove(acc);	//RemoveAt(인덱스)
						Console.WriteLine("삭제 완료");
						return;
					}
				}
				throw new Exception("유효하지 않은 ID 입니다.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("삭제 에러가 발생했습니다.");
				Console.WriteLine("원인 : " + ex.Message);
			}
		}   
	}
}
