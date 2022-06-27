namespace ReadWriteXml
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnWriteXmlTable = new System.Windows.Forms.Button();
            this.btnReadXmlTable = new System.Windows.Forms.Button();
            this.btnWriteXmlDataSet = new System.Windows.Forms.Button();
            this.btnReadXmlDataSet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "구입목록";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "고객목록";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(341, 24);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(345, 150);
            this.dataGridView2.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(323, 150);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnWriteXmlTable
            // 
            this.btnWriteXmlTable.Location = new System.Drawing.Point(14, 191);
            this.btnWriteXmlTable.Name = "btnWriteXmlTable";
            this.btnWriteXmlTable.Size = new System.Drawing.Size(225, 23);
            this.btnWriteXmlTable.TabIndex = 12;
            this.btnWriteXmlTable.Text = "tblePeople XML로 기록하기";
            this.btnWriteXmlTable.UseVisualStyleBackColor = true;
            this.btnWriteXmlTable.Click += new System.EventHandler(this.btnWriteXmlTable_Click);
            // 
            // btnReadXmlTable
            // 
            this.btnReadXmlTable.Location = new System.Drawing.Point(14, 220);
            this.btnReadXmlTable.Name = "btnReadXmlTable";
            this.btnReadXmlTable.Size = new System.Drawing.Size(225, 23);
            this.btnReadXmlTable.TabIndex = 13;
            this.btnReadXmlTable.Text = "XML 파일에서 tblPeople 읽기";
            this.btnReadXmlTable.UseVisualStyleBackColor = true;
            this.btnReadXmlTable.Click += new System.EventHandler(this.btnReadXmlTable_Click);
            // 
            // btnWriteXmlDataSet
            // 
            this.btnWriteXmlDataSet.Location = new System.Drawing.Point(341, 191);
            this.btnWriteXmlDataSet.Name = "btnWriteXmlDataSet";
            this.btnWriteXmlDataSet.Size = new System.Drawing.Size(225, 23);
            this.btnWriteXmlDataSet.TabIndex = 14;
            this.btnWriteXmlDataSet.Text = "데이터 집합을 XML로 기록하기";
            this.btnWriteXmlDataSet.UseVisualStyleBackColor = true;
            this.btnWriteXmlDataSet.Click += new System.EventHandler(this.btnWriteXmlDataSet_Click);
            // 
            // btnReadXmlDataSet
            // 
            this.btnReadXmlDataSet.Location = new System.Drawing.Point(341, 220);
            this.btnReadXmlDataSet.Name = "btnReadXmlDataSet";
            this.btnReadXmlDataSet.Size = new System.Drawing.Size(225, 23);
            this.btnReadXmlDataSet.TabIndex = 15;
            this.btnReadXmlDataSet.Text = "XML 파일에서 데이터 집합 읽기";
            this.btnReadXmlDataSet.UseVisualStyleBackColor = true;
            this.btnReadXmlDataSet.Click += new System.EventHandler(this.btnReadXmlDataSet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 257);
            this.Controls.Add(this.btnReadXmlDataSet);
            this.Controls.Add(this.btnWriteXmlDataSet);
            this.Controls.Add(this.btnReadXmlTable);
            this.Controls.Add(this.btnWriteXmlTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnWriteXmlTable;
        private System.Windows.Forms.Button btnReadXmlTable;
        private System.Windows.Forms.Button btnWriteXmlDataSet;
        private System.Windows.Forms.Button btnReadXmlDataSet;
    }
}

