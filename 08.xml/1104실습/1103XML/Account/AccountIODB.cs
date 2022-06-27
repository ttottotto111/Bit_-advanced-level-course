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
    class AccountIODB
    {
        #region 싱글톤
        //1. 생성자 은닉
        private AccountIODB()
        {
        }
        //2. 프로퍼티 선언
        static public AccountIODB Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static AccountIODB()
        {
            Singleton = new AccountIODB();
        }
        #endregion

        private DataTable accountio_table;
        public DataTable AccountIO_Table { get { return accountio_table; } }

        //테이블 생성 컬럼 생성
        public void CreateTable()
        {
            accountio_table = new DataTable("Accountios");

            DataColumn dc_pid = new DataColumn();
            dc_pid.ColumnName = "accid";
            dc_pid.DataType = typeof(int);
            accountio_table.Columns.Add(dc_pid);

            DataColumn dc_input = new DataColumn("input", typeof(int));
            dc_input.AllowDBNull = false;
            accountio_table.Columns.Add(dc_input);

            DataColumn dc_output = new DataColumn("output", typeof(int));
            dc_output.AllowDBNull = false;
            accountio_table.Columns.Add(dc_output);

            DataColumn dc_price = new DataColumn("balance", typeof(int));
            dc_price.AllowDBNull = false;
            accountio_table.Columns.Add(dc_price);            
        }

        //AccountList를 인자로 받아 테이블에 저장
        public void InsertAllAccountIO(List<AccountIO> accIOlist)
        {
            foreach (AccountIO acc in accIOlist)
            {
                InsertAccountIO(acc.Id, acc.Input, acc.Output, acc.Balance);
            }
        }

        //Account를 테이블에 저장
        private void InsertAccountIO(int accid, int input, int output, int price)
        {
            try
            {
                DataRow dr = accountio_table.NewRow();
                dr["accid"] = accid;
                dr["input"] = input;
                dr["output"] = output;
                dr["balance"] = price;

                accountio_table.Rows.Add(dr);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    
        //계좌번호를 받아서 해당 계좌의 거래리스트를 반환
        public List<AccountIO> AccIdToAccountIOList(int accid)
        {
            List<AccountIO> acclist = new List<AccountIO>();

            foreach (DataRow dr in accountio_table.Rows)
            {
                int id = int.Parse(dr["accid"].ToString());
                if (id == accid)
                {
                    AccountIO io = new AccountIO(                    
                        id,
                        int.Parse(dr["input"].ToString()),
                        int.Parse(dr["output"].ToString()),
                        int.Parse(dr["balance"].ToString())
                     );
                    acclist.Add(io);
                }
            }
            return acclist;
        }
    }
}
