namespace MakeTable
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tblPeople = new System.Windows.Forms.Button();
			this.tblSale = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(516, 150);
			this.dataGridView1.TabIndex = 0;
			// 
			// tblPeople
			// 
			this.tblPeople.Location = new System.Drawing.Point(158, 188);
			this.tblPeople.Name = "tblPeople";
			this.tblPeople.Size = new System.Drawing.Size(75, 23);
			this.tblPeople.TabIndex = 1;
			this.tblPeople.Text = "tblPeople";
			this.tblPeople.UseVisualStyleBackColor = true;
			this.tblPeople.Click += new System.EventHandler(this.tblPeople_Click);
			// 
			// tblSale
			// 
			this.tblSale.Location = new System.Drawing.Point(291, 188);
			this.tblSale.Name = "tblSale";
			this.tblSale.Size = new System.Drawing.Size(75, 23);
			this.tblSale.TabIndex = 2;
			this.tblSale.Text = "tblSale";
			this.tblSale.UseVisualStyleBackColor = true;
			this.tblSale.Click += new System.EventHandler(this.tblSale_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(540, 236);
			this.Controls.Add(this.tblSale);
			this.Controls.Add(this.tblPeople);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button tblPeople;
		private System.Windows.Forms.Button tblSale;
	}
}

