using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1021
{
    class AccManager
    {
        #region 싱글톤
        //1. 생성자 은닉
        private AccManager()
        {
           
        }
        //2. 프로퍼티 선언
        static public AccManager Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static AccManager()
        {
            Singleton = new AccManager();
        }
        #endregion

        private Dictionary<string, NormalAcc> acclist = new Dictionary<string, NormalAcc>();
        public Dictionary<string, NormalAcc> Acclist { get { return acclist; } }

        //계좌번호 계좌번호생성
        public string MakeAccountID(AccountType type)
        {
            string id = string.Empty;
            if (type == AccountType.NON)
                throw new Exception("계좌타입을 선택하세요.");
            else if (type == AccountType.NORMALACC)
                id = +1 + "-";
            else if (type == AccountType.PERDEPOSIT)
                id = +2 + "-";
            else if (type == AccountType.FUNDACC)
                id = +3 + "-";

            Random r = new Random();
            id += r.Next(0, 1000) + "-";
            id += r.Next(0, 1000);

            return id;
        }

        //성공실패 계좌개설
        public bool InsertAccount(AccountType type,string id,  string name, int money)
        {
            try
            {
                NormalAcc acc = null;

                if(type ==AccountType.NORMALACC)
                acc = new NormalAcc(type, id, name, money);

                acclist.Add(id, acc);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        //계좌 계좌 번호로 검색
        public NormalAcc IdToAccount(string id)
        {
            return acclist[id];
        }

        //계좌 계좌 이름으로 검색
        public List<NormalAcc> NameToAccount(string name)
        {
            List<NormalAcc> temp = new List<NormalAcc>();

            foreach(KeyValuePair<string, NormalAcc> data in acclist)
            {
                if(data.Value.Name.Equals(name)==true)
                {
                    temp.Add(data.Value);
                }
            }
            return temp;
        }

        //입금
        public void InputMoney(string id, int money)
        {
            IdToAccount(id).InputMoney(money);
        }

        //출금
        public void OutputMoney(string id, int money)
        {
            IdToAccount(id).OutputMoney(money);
        }

        //계좌이체
        public void TransMoney(string myid, string transid, int money)
        {
            IdToAccount(myid).OutputMoney(money);
            IdToAccount(transid).InputMoney(money);
        }

        //삭제
        public void DeleteAccount(string id)
        {
            acclist.Remove(id);
        }

        //시뮬레이션
        public Simulation SimulRun(string id, int count)
        {
            int idx = 0;
            int money = 0;
            int incount = 0;
            int outcount = 0; ;

            NormalAcc acc = IdToAccount(id);
            Simulation simul = new Simulation();
            Random r = new Random();

            //반복문 : 반복문의 횟수는 count
            for (int i = 0; i < count; i++)
            {
                idx = r.Next(1, 3);
                money = r.Next(1, 11) * 1000;

                if (idx == 1)
                {
                    InputMoney(id, money);
                    incount++;
                }
                else if (idx == 2)
                {
                    OutputMoney(id, money);
                    outcount++;
                }
            }

            simul.Count = count;
            simul.Inputcount = incount;
            simul.Outputcount = outcount;
            simul.Balance = acc.Balance;

            return simul;
        }
    }
}
