namespace DSWizard
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.aDOTestDataSet = new DSWizard.ADOTestDataSet();
			this.tblPeopleBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tblPeopleTableAdapter = new DSWizard.ADOTestDataSetTableAdapters.tblPeopleTableAdapter();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.maleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.aDOTestDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.maleDataGridViewCheckBoxColumn});
			this.dataGridView1.DataSource = this.tblPeopleBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 31);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(366, 150);
			this.dataGridView1.TabIndex = 0;
			// 
			// aDOTestDataSet
			// 
			this.aDOTestDataSet.DataSetName = "ADOTestDataSet";
			this.aDOTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tblPeopleBindingSource
			// 
			this.tblPeopleBindingSource.DataMember = "tblPeople";
			this.tblPeopleBindingSource.DataSource = this.aDOTestDataSet;
			// 
			// tblPeopleTableAdapter
			// 
			this.tblPeopleTableAdapter.ClearBeforeFill = true;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// ageDataGridViewTextBoxColumn
			// 
			this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
			this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
			this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
			// 
			// maleDataGridViewCheckBoxColumn
			// 
			this.maleDataGridViewCheckBoxColumn.DataPropertyName = "Male";
			this.maleDataGridViewCheckBoxColumn.HeaderText = "Male";
			this.maleDataGridViewCheckBoxColumn.Name = "maleDataGridViewCheckBoxColumn";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 209);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.aDOTestDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private ADOTestDataSet aDOTestDataSet;
		private System.Windows.Forms.BindingSource tblPeopleBindingSource;
		private DSWizard.ADOTestDataSetTableAdapters.tblPeopleTableAdapter tblPeopleTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn maleDataGridViewCheckBoxColumn;

	}
}

