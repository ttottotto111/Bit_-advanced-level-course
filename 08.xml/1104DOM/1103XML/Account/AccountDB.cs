using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wb.XMLPaser;

namespace WB.Database
{
    class AccountDB
    {
        #region 싱글톤
        //1. 생성자 은닉
        private AccountDB()
        {
        }
        //2. 프로퍼티 선언
        static public AccountDB Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static AccountDB()
        {
            Singleton = new AccountDB();
        }
        #endregion

        private DataTable account_table;
        public DataTable Account_Table {  get { return account_table; } }

        //테이블 생성 컬럼 생성
        public void CreateTable()
        {
            account_table = new DataTable("Accounts");

            //4개의 컬럼 추가(PID:자동증가, Name, Price, BirthDate)
            DataColumn dc_pid = new DataColumn();
            dc_pid.ColumnName = "accid";
            dc_pid.DataType = typeof(int);
            dc_pid.AutoIncrement = true;
            dc_pid.AutoIncrementSeed = 1000;
            dc_pid.AutoIncrementStep = 10;
            account_table.Columns.Add(dc_pid);

            DataColumn dc_name = new DataColumn("name", typeof(string));
            dc_name.AllowDBNull = false;
            account_table.Columns.Add(dc_name);

            DataColumn dc_price = new DataColumn("balance", typeof(int));
            dc_price.AllowDBNull = false;
            account_table.Columns.Add(dc_price);
            
            //primary key등록
            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = dc_pid;

            account_table.PrimaryKey = pkeys;
        }

        //AccountList를 인자로 받아 테이블에 저장
        public void InsertAllAccount(List<Account> acclist)
        {
            foreach(Account acc in acclist)
            {
                InsertAccount(acc.Id, acc.Name, acc.Balance);
            }
        }

        //Account를 테이블에 저장
        private void InsertAccount(int accid, string name, int price)
        {
            try
            {
                DataRow dr      = account_table.NewRow();
                dr["accid"]     = accid;
                dr["name"]      = name;
                dr["balance"]   = price;

                account_table.Rows.Add(dr);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    
        //데이터테이블에서 계좌의ID만 획득해 List<int>로 반환
        public List<int> GetAccIDList()
        {
            List<int> accidlist = new List<int>();

            foreach (DataRow dr in account_table.Rows)
            {
                accidlist.Add(int.Parse(dr["accid"].ToString()));
            }

            return accidlist;
        }
    
        //계좌번호를 받아서 계좌를 반환
        public Account AccIdToAccount(int accid)
        {
            Account acc = null;
            foreach (DataRow dr in account_table.Rows)
            {
                int id = int.Parse(dr["accid"].ToString());
                if( id == accid)
                {
                    acc = new Account(                    
                        id,
                        dr["name"].ToString(),
                        int.Parse(dr["balance"].ToString())
                     );
                    break;
                }
            }
            return acc;
        }
    }
}
