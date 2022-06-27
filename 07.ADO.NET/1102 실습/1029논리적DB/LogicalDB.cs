using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1029논리적DB
{
    class LogicalDB
    {
        public DataTable BookTable { get; set; }

        readonly string schema_fname    = "books.xsd";
        readonly string fname           = "book.xml";

        public void Save()
        {
            //테이블의 구조(컬럼 정보)
            BookTable.WriteXmlSchema(schema_fname, true);

            //테이블의 데이터(로우데이터)
            BookTable.WriteXml(fname, true);
        }

        public void Load()
        {
            if (File.Exists(schema_fname))
            {
                BookTable = new DataTable("Books");
                //테이블의 컬럼 생성
                BookTable.ReadXmlSchema(schema_fname);
                if (File.Exists(fname))
                {
                    //테이블의 로우데이터 저장
                    BookTable.ReadXml(fname);
                }
            }
        }

        public string BookTableName {  get { return BookTable.TableName.ToString(); } }

        public int BookTableColumnCount { get { return BookTable.Columns.Count; } }

        public DataColumnCollection BookColumns { get { return BookTable.Columns;  } }


        public void CreateTable()
        {
            BookTable = new DataTable("Books");

            //4개의 컬럼 추가(PID:자동증가, Name, Price, BirthDate)
            DataColumn dc_pid = new DataColumn();
            dc_pid.ColumnName = "PID";
            dc_pid.DataType = typeof(int);
            dc_pid.AutoIncrement = true;
            dc_pid.AutoIncrementSeed = 1;
            dc_pid.AutoIncrementStep = 1;
            BookTable.Columns.Add(dc_pid);

            DataColumn dc_name = new DataColumn("Name", typeof(string));
            dc_name.AllowDBNull = false;
            BookTable.Columns.Add(dc_name);

            DataColumn dc_price = new DataColumn("Price", typeof(int));
            dc_price.AllowDBNull = false;
            BookTable.Columns.Add(dc_price);

            DataColumn dc_dt = new DataColumn("BirthDate", typeof(DateTime));
            dc_dt.AllowDBNull = false;
            BookTable.Columns.Add(dc_dt);

            //primary key등록
            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = dc_pid;

            BookTable.PrimaryKey = pkeys;
        }
        
        //DataTable 과 DataGridView 컨트롤을 Binding(연결 - 동기화)
        public void BindingGridView(DataGridView dgv)
        {
            dgv.DataSource = BookTable; 
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
    
        public void DeleteBook(int pid)
        {
            try
            {
                DataRow dr = BookTable.Rows.Find(pid);
                BookTable.Rows.Remove(dr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
