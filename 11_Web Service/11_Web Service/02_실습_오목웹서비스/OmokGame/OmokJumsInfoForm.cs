using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OmokGame
{
	/// <summary>
	/// ���� �������� ��ġȭ�ؼ� �����ִ� ���̴�.
	/// �������� ���Ƿ� �ٲٱ����ؼ� ��ġ�� ������ ���� �ִ�.
	/// </summary>
	public class OmokJumsInfoForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string strOmokPan;

		public OmokJumsInfoForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(0, 269);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(137, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "���Ƿ� �ٲٷ��� ���� ���ڵ��� �����ϼ���";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.AutoSize = false;
			this.textBox1.MaxLength = 441;
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(135, 260);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// OmokJumsInfoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(137, 309);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBox1,
																		  this.button1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "OmokJumsInfoForm";
			this.Opacity = 0.7;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "���� �������� ����";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// ���Ƿ� �������� ��ġ�� �ٲپ��ٸ� �� ��ġ�� ������ �Ѵ�.
		/// �߸��� ��ġ�� �Է��ϸ� �ٲ��� �ʴ´�.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
			// ���� ���� ǥ�������� �´��� �˻��Ѵ�.
			Regex regex = new Regex(@"^3{21}(3[0-2]{19}3){19}3{21}$");
			if(regex.IsMatch(textBox1.Text)) 
			{
				strOmokPan = string.Copy(textBox1.Text);			
				DialogResult = DialogResult.OK;
				Close();	
			}
			else 
			{
				MessageBox.Show("�������� �߸� �ԷµǾ����ϴ�.");
			}
		}

		public void InputOmokPan(string str) 
		{
			strOmokPan = string.Copy(str);
			textBox1.Text = strOmokPan;			
		}

	}
}
