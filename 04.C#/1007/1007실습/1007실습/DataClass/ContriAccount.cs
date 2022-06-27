using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1007실습
{
    /// <summary>
    /// 기부 계좌 
    /// Account Class 상속 
    /// 입금시 1%의 이자가 기부금으로 빠져 나간다.
    /// 상위 클래스의 AddMoney 함수 재정의 
    /// 기부금 총액 저장 변수 필요 
    /// int contribution
    /// 출력시 총 기부액도 출력
    /// </summary>
    [Serializable]
    class ContriAccount : Account
    {
        public int Contribution { get; private set; }

        #region 생성자(2개)
        public ContriAccount(int id, String name) 
            : base(id, name)
        {
        }

        public ContriAccount(int id, String name, int balance)
            :base(id, name, (int)(balance - balance * 0.01))
        {
            Contribution = (int)(balance * 0.01);
        }
        #endregion

        public override void AddMoney(int val)
        {
            base.AddMoney((int)(val - val * 0.01));
            Contribution += (int)(val * 0.01);
        }

        public override void ShowAllData()
        {
            base.ShowAllData();
            Console.WriteLine("총 기부액 : " + Balance);
        }

        public override string ToString()
        {
            String temp = String.Format("\t{0}원",Contribution);
            return base.ToString() + temp;
        }
    }
}
