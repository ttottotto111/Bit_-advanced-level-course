using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1029
{
    class LogicalDB
    {
        public DataTable BookTable { get; set; }

        public string BookTableName { get { return BookTable.TableName.ToString(); } }
        public int BookTableColumnCount { get { return BookTable.Columns.Count; } }
        public DataColumnCollection BookColumns { get { return BookTable.Columns; } }

        public void CreateTable()
        {
            BookTable = new DataTable("Books");

            //4개의 컬럼 추가(PID : 자동증가, Name, Price, BirthDate)

            //PID
            DataColumn dc_pid = new DataColumn();
            dc_pid.ColumnName = "PID";
            dc_pid.DataType = typeof(int);
            dc_pid.AutoIncrement = true;
            dc_pid.AutoIncrementSeed = 1;
            dc_pid.AutoIncrementStep = 1;
            BookTable.Columns.Add(dc_pid);

            //Name
            DataColumn dc_name = new DataColumn("Name", typeof(string));
            dc_name.AllowDBNull = false;
            BookTable.Columns.Add(dc_name);

            //Price
            DataColumn dc_price = new DataColumn("Price", typeof(int));
            dc_price.AllowDBNull = false;
            BookTable.Columns.Add(dc_price);

            //BirthDate
            DataColumn dc_dt = new DataColumn("BirthDate", typeof(DateTime));
            dc_dt.AllowDBNull = false;
            BookTable.Columns.Add(dc_dt);

            //primary key등록
            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = dc_pid;
            BookTable.PrimaryKey = pkeys;
        }

        public void InsertBook(string name, int price, DateTime dt)
        {
            try
            {
                DataRow dr = BookTable.NewRow();
                dr["Name"] = name;
                dr["Price"] = price;
                dr["BirthDate"] = dt;

                BookTable.Rows.Add(dr);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void BindingGridView(DataGridView dgv)
        {
            dgv.DataSource = BookTable;
        }

        public void DeleteBook(int pid)
        {
            try
            {
                DataRow dr = BookTable.Rows.Find(pid);
                BookTable.Rows.Remove(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
