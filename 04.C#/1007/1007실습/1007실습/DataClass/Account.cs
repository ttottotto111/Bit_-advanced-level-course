using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1007실습
{
    [Serializable]
    class Account
    {
        //맴버필드와 프로퍼티
        public int Id { get; private set; }
        public int Balance { get; private set; }
        public string Name { get; private set; }
        public DateTime MakeTime { get; set; }

        #region 생성자. (계좌번호, 이름), (계좌번호,이름, 입금액)
        public Account(int id, string name) : this(id, name, 0)
        {            
        }

        public Account(int id, string name, int money)
        {
            Id          = id;
            Balance     = money;
            Name        = name;
            MakeTime    = DateTime.Now;
        }
        #endregion

        #region 기능 메서드(입금,출금, 출력(다중라인)
        public virtual void AddMoney(int val)
        {
            if (val < 0)        
                throw new Exception("마이너스 금액 : " + val +"원");
            Balance += val;
        }
        public void MinMoney(int val)
        {
            if (val < 0)       
                throw new Exception("마이너스 금액 : " + val + "원");

            if (Balance < val)
            {
                String temp = String.Format("잔액부족[{0},{1}]", Balance, val);
                throw new Exception(temp);
            }
            Balance -= val;
        }
        public virtual void ShowAllData()
        {
            Console.WriteLine("계좌  ID : " + Id);
            Console.WriteLine("고객이름 : " + Name);
            Console.WriteLine("잔    액 : " + Balance + "원");
            Console.WriteLine("개 설 일 : " + MakeTime.ToLongDateString());
            Console.WriteLine("개 설 시 : " + MakeTime.ToLongTimeString());
        }
        #endregion
        
        //toString 오버라이드(자신의 정보를 문자열 반환)
        public override string ToString()
        {
            String temp = String.Format("[{0}]\t{1}\t{2}원\t{3}",
                Id, Name, Balance, MakeTime.ToString());
            return temp;
        }
    }
}
