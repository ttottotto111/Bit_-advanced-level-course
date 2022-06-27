namespace TypedDataSet
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
            this.aDOTestDataSet = new TypedDataSet.ADOTestDataSet();
            this.tblPeopleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblPeopleTableAdapter = new TypedDataSet.ADOTestDataSetTableAdapters.tblPeopleTableAdapter();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textName = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.textName2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textAge = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(376, 150);
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
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(12, 184);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 21);
            this.textName.TabIndex = 1;
            this.textName.Text = "정우성";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(134, 184);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(115, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "의 나이 조사";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // textName2
            // 
            this.textName2.Location = new System.Drawing.Point(12, 226);
            this.textName2.Name = "textName2";
            this.textName2.Size = new System.Drawing.Size(100, 21);
            this.textName2.TabIndex = 3;
            this.textName2.Text = "배용준";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "의 나이를";
            // 
            // textAge
            // 
            this.textAge.Location = new System.Drawing.Point(210, 226);
            this.textAge.Name = "textAge";
            this.textAge.Size = new System.Drawing.Size(53, 21);
            this.textAge.TabIndex = 5;
            this.textAge.Text = "99";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(284, 226);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "세로 변경";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 269);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.textAge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textName2);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDOTestDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ADOTestDataSet aDOTestDataSet;
        private System.Windows.Forms.BindingSource tblPeopleBindingSource;
        private TypedDataSet.ADOTestDataSetTableAdapters.tblPeopleTableAdapter tblPeopleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn maleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox textName2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAge;
        private System.Windows.Forms.Button btnUpdate;
    }
}

