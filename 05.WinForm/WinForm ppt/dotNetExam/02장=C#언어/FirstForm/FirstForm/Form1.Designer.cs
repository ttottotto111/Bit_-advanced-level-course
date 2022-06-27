namespace FirstForm
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
			this.LblFruit = new System.Windows.Forms.Label();
			this.BtnApple = new System.Windows.Forms.Button();
			this.BtnOrange = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LblFruit
			// 
			this.LblFruit.AutoSize = true;
			this.LblFruit.Location = new System.Drawing.Point(112, 83);
			this.LblFruit.Name = "LblFruit";
			this.LblFruit.Size = new System.Drawing.Size(29, 12);
			this.LblFruit.TabIndex = 0;
			this.LblFruit.Text = "Fruit";
			// 
			// BtnApple
			// 
			this.BtnApple.Location = new System.Drawing.Point(48, 164);
			this.BtnApple.Name = "BtnApple";
			this.BtnApple.Size = new System.Drawing.Size(75, 23);
			this.BtnApple.TabIndex = 1;
			this.BtnApple.Text = "Apple";
			this.BtnApple.UseVisualStyleBackColor = true;
			this.BtnApple.Click += new System.EventHandler(this.BtnApple_Click);
			// 
			// BtnOrange
			// 
			this.BtnOrange.Location = new System.Drawing.Point(171, 164);
			this.BtnOrange.Name = "BtnOrange";
			this.BtnOrange.Size = new System.Drawing.Size(75, 23);
			this.BtnOrange.TabIndex = 2;
			this.BtnOrange.Text = "Orange";
			this.BtnOrange.UseVisualStyleBackColor = true;
			this.BtnOrange.Click += new System.EventHandler(this.BtnOrange_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.BtnOrange);
			this.Controls.Add(this.BtnApple);
			this.Controls.Add(this.LblFruit);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LblFruit;
		private System.Windows.Forms.Button BtnApple;
		private System.Windows.Forms.Button BtnOrange;
	}
}

