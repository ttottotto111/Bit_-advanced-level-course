using System.Data;

namespace Validation2
{


	partial class ADOTestDataSet
	{
		partial class tblPeopleDataTable
		{
			protected override void OnColumnChanging(DataColumnChangeEventArgs e)
			{
				if (e.Column.ColumnName == "Age")
				{
					if ((int)e.ProposedValue < 0 || (int)e.ProposedValue > 100)
					{
						e.Row.SetColumnError("Age", "나이는 0 ~ 100 사이여야 합니다.");
					}
					else
					{
						e.Row.SetColumnError("Age", "");
					}
				}
			}

			public override void BeginInit()
			{
				base.BeginInit();
				RowChanging += new DataRowChangeEventHandler(tblPeopleDataTable_RowChanging);
			}

			public void tblPeopleDataTable_RowChanging(object sender, DataRowChangeEventArgs e)
			{
				tblPeopleRow R = (tblPeopleRow)e.Row;
				if ((bool)R.Male == false)
				{
					if ((int)R.Age > 40)
					{
						e.Row.SetColumnError("Age", "여성의 나이는 40세 이하여야 합니다.");
					}
					else
					{
						e.Row.SetColumnError("Age", "");
					}
				}
			}
		}
	}
}
