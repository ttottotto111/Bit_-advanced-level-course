using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormTotalExam
{
	/// <summary>
	/// Form2�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btn_Close;
		private System.Windows.Forms.Label lbl_Info;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2()
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent�� ȣ���� ���� ������ �ڵ带 �߰��մϴ�.
			//
		}

		/// <summary>
		/// ��� ���� ��� ���ҽ��� �����մϴ�.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form �����̳ʿ��� ������ �ڵ�
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ������ �ڵ� ������� �������� ���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbl_Info = new System.Windows.Forms.Label();
			this.btn_Close = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbl_Info
			// 
			this.lbl_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbl_Info.Location = new System.Drawing.Point(0, 6);
			this.lbl_Info.Name = "lbl_Info";
			this.lbl_Info.Size = new System.Drawing.Size(288, 178);
			this.lbl_Info.TabIndex = 0;
			// 
			// btn_Close
			// 
			this.btn_Close.Location = new System.Drawing.Point(0, 200);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(288, 56);
			this.btn_Close.TabIndex = 1;
			this.btn_Close.Text = "â �ݱ�";
			this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.btn_Close);
			this.Controls.Add(this.lbl_Info);
			this.Name = "Form2";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public string lblInfo
		{
			set
			{
				this.lbl_Info.Text = value;
			}
	    }

		private void Form2_Load(object sender, System.EventArgs e)
		{
			this.Size = new Size(300, 300);
		}

		private void btn_Close_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
	}
}
