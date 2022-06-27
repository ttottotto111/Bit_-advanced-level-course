using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyButton
{
	/// <summary>
	/// Form1�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private MyButton.RainbowButton button1;
		private MyButton.RainbowButton2 button2;
		private MyButton.RainbowButton3 button3;
		/// <summary>
		/// �ʼ� �����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
				if (components != null) 
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
			this.button1 = new MyButton.RainbowButton();
			this.button2 = new MyButton.RainbowButton2();
			this.button3 = new MyButton.RainbowButton3();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(40, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 104);
			this.button1.TabIndex = 0;
			this.button1.Text = "��ư1";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(40, 144);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 96);
			this.button2.TabIndex = 1;
			this.button2.Text = "��ư2";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(176, 48);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(208, 168);
			this.button3.TabIndex = 2;
			this.button3.Text = "��ư3";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 19);
			this.ClientSize = new System.Drawing.Size(424, 286);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("����ü", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.Name = "Form1";
			this.Text = "������ ��ư �����";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �ش� ���� ���α׷��� �� �������Դϴ�.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
