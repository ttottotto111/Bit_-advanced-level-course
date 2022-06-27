using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Reflection;
using System.Resources;

namespace OmokGame
{	
	/// <summary>
	/// ��ǥ �ϳ��� ���� ����
	/// </summary>
	enum JumInfo 
	{
		
		Empty,		// �����
		Black,		// ���� ���� �����ִ�
		White,		// �� ���� �����ִ�
		Boundary	// �׵θ��̴�.
	}
	
	/// <summary>
	/// ������� �ǹ�
	/// </summary>
	enum Result 
	{
		Win,		// �¸�
		SamSam,		// ���
		Nothing,	// �ƹ� ����� ������ �ʴ� ���� ����
		Occupied,	// �̹� ������ ���� �������� 
		Problem		// �� ���񽺿� ������ ������	
	}

	/// <summary>
	/// �� ���� �����ǰ� �޴��� �ִ� ������, ���� �ֵ� ���̴�.
	/// </summary>
	/// <remarks>
	/// ������, ������, �� �̹����� ���� Bitmap Ŭ���� ����� �̿��Ѵ�. 
	/// �׸���, ȭ�鿡 ���õ� ���� ������� �ִ�.
	/// </remarks>
	public class OmokForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// ������� ���� �����ϴ� ��Ʈ�� Ŭ����
		/// </summary>
		Bitmap UserBitmap;
		/// <summary>
		/// ��ǻ���� ���� �����ϴ� ��Ʈ�� Ŭ����
		/// </summary>
		Bitmap ComBitmap;
		/// <summary>
		/// ������ �̹����� �����ϴ� ��Ʈ�� Ŭ����
		/// </summary>
		Bitmap BoardBitmap;		
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;

		/// <summary>
		/// �ٵ��� ���� �ܰ��� �ȼ��� ��Ÿ���� ���
		/// </summary>
		const int TopMarginPixel = 3;  
		/// <summary>
		/// �ٵ��� ���� �ܰ��� �ȼ��� ��Ÿ���� ���
		/// </summary>
		const int LeftMarginPixel = 4;
		/// <summary>
		/// �� �ϳ��� ������ ���� �����ϴ� �ȼ��� ���� 19 ���� 19���� ��Ÿ���� ���
		/// </summary>
		const int JumArea = 19;

		/// <summary>
		/// �¸��� �� ���콺�� ĸ���ϱ� ���� ���̴� ����
		/// </summary>
		bool bMouseCapture;

		/// <summary>
		/// ���� �ϴ� ���� ������������� ��ǻ������ �����ϴ� ����
		/// </summary>
		int nKindOfStartStone;


		/// <summary>
		/// �¸��� �Ķ�� ���� ��Ÿ���ִ� �ʵ�
		/// �� ������ �¸��� �� �����⸦ �ϸ� �ٽ� �ٵ����� Ȱ��ȭ�ǰԲ� �ϱ� ���� �ʿ��ϴ�.
		/// </summary>		
		bool bWinAfter;

		/// <summary>
		/// �¸��� �� �����⸦ �ϸ� �ٽ� ���콺�� �������� �ǵ��� ���ƾ� �ϹǷ�, �� ������ ���� ���콺 ĸ�ĸ� Ǭ��.		
		/// </summary>		
		bool bWinMulligi;

		/// <summary>
		/// ����� �̰�ٰ� �˸��� ����
		/// </summary>
		bool bUserWin;
		/// <summary>
		/// ��ǻ�Ͱ� �̰�ٰ� �˸��� ����
		/// </summary>
		bool bComWin;
		/// <summary>
		/// �� ������ �ϱ����� ���̴� �޴� ������
		/// </summary>
		private System.Windows.Forms.MenuItem menuItemNew;
		/// <summary>
		/// �����⸦ ���� �޴� ������
		/// </summary>
		private System.Windows.Forms.MenuItem menuItemMulligi;
		/// <summary>
		/// ���� �������� ��ġ�� �������� �޴� ������
		/// </summary>
		private System.Windows.Forms.MenuItem menuCurrentOmokPanInfo;
		/// <summary>
		/// ��������� ������ ���� �޴� ������
		/// </summary>
		private System.Windows.Forms.MenuItem menuItemQuit;
		/// <summary>
		/// ������ ǥ���ϴ� �޴� ������
		/// </summary>
		private System.Windows.Forms.MenuItem menuItemInfo;
		private System.Windows.Forms.MenuItem menuItem2;

		/// <summary>
		/// ���� �δ� ���� ���� ��� �����Ͱ� ���� �ȴ�.
		/// �׸���, �� �ʵ带 ���ؼ� ���� �� ���񽺿� ����Ѵ�.
		/// </summary>
		OmokData omokData;

		/// <summary>
		/// ������
		/// </summary>
		public OmokForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		
			try 
			{
				BoardBitmap = new Bitmap(@"board.GIF");			
				ClientSize = BoardBitmap.Size;

				omokData = new OmokData();

				// ���� ���� �����ش�.
				StartForm sf = new StartForm();

				// ���� ���� �ϴ��� �� �� �ִ�.
				if(sf.ShowDialog() == DialogResult.Yes) 
				{
					nKindOfStartStone = (int)JumInfo.Black;
					UserBitmap = new Bitmap(@"black.GIF");
					UserBitmap.MakeTransparent(Color.Cyan);
					ComBitmap = new Bitmap(@"white.GIF");
					ComBitmap.MakeTransparent(Color.Cyan);
				}
				else 
				{
					nKindOfStartStone = (int)JumInfo.White;
					UserBitmap = new Bitmap(@"white.GIF");
					UserBitmap.MakeTransparent(Color.Cyan);
					ComBitmap = new Bitmap(@"black.GIF");
					ComBitmap.MakeTransparent(Color.Cyan);
				}

				omokData = new OmokData();

				if(nKindOfStartStone == (int)JumInfo.White) 
				{	//������ ���̸�
					Point point = new Point(10,10);		//���� ó�� �� �ڸ��� �����ϰ�
					omokData.WriteJum(point, nKindOfStartStone); //��(������)�� �д� 
					TurnStone(ref nKindOfStartStone);	//�׸��� �ٽ� ����ڵ��� �ٲ��ش�. 
				}
			} 
			catch(ArgumentException e) 
			{
				MessageBox.Show(e.ToString(), "�̹��� ������ ��θ� �����ϼ���");
			}
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItemNew = new System.Windows.Forms.MenuItem();
			this.menuItemMulligi = new System.Windows.Forms.MenuItem();
			this.menuCurrentOmokPanInfo = new System.Windows.Forms.MenuItem();
			this.menuItemQuit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItemInfo = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemNew,
																					  this.menuItemMulligi,
																					  this.menuCurrentOmokPanInfo,
																					  this.menuItemQuit});
			this.menuItem1.Text = "����";
			// 
			// menuItemNew
			// 
			this.menuItemNew.Index = 0;
			this.menuItemNew.Text = "������";
			this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
			// 
			// menuItemMulligi
			// 
			this.menuItemMulligi.Index = 1;
			this.menuItemMulligi.Text = "�Ѽ� ������";
			this.menuItemMulligi.Click += new System.EventHandler(this.menuItemMulligi_Click);
			// 
			// menuCurrentOmokPanInfo
			// 
			this.menuCurrentOmokPanInfo.Index = 2;
			this.menuCurrentOmokPanInfo.Text = "���� �������� ��ġȭ";
			this.menuCurrentOmokPanInfo.Click += new System.EventHandler(this.menuItemCurrentOmokPanInfo_Click);
			// 
			// menuItemQuit
			// 
			this.menuItemQuit.Index = 3;
			this.menuItemQuit.Text = "������";
			this.menuItemQuit.Click += new System.EventHandler(this.menuItemQuit_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemInfo});
			this.menuItem2.Text = "����";
			// 
			// menuItemInfo
			// 
			this.menuItemInfo.Index = 0;
			this.menuItemInfo.Text = "����";
			this.menuItemInfo.Click += new System.EventHandler(this.menuItemInfo_Click);
			// 
			// OmokForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(404, 369);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "OmokForm";
			this.Text = "���� �� ���񽺸� �̿��� �ΰ����� �������";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new OmokForm());
		}

		/// <summary>
		/// ȭ�鿡 �̹����� ��Ÿ���� �޼ҵ�
		/// </summary>
		/// <param name="e">�� ��ü���� ȭ��� ���õ� Graphics��ü�� �̿��Ѵ�</param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			// �ٵ����� �׸�
			Graphics g = e.Graphics;
			if (BoardBitmap != null) 
			{
				g.DrawImage (BoardBitmap, ClientRectangle);
			}	
			// �ٵϵ��� �׸�
			for(int i=1; i<=19; i++)
			{
				for(int j=1; j<=19; j++) 
				{
					//�������� ������ ������ ȭ�鿡 ���
					if(omokData.GetKindOfJum(i,j) == (int)JumInfo.Black) 
					{
						g.DrawImage(UserBitmap, LeftMarginPixel+((i-1)*JumArea), TopMarginPixel+((j-1)*JumArea), 18, 18);
					}
						//���� ������ ������ ȭ�鿡 ��� 
					else if(omokData.GetKindOfJum(i,j) == (int)JumInfo.White) 
					{
						g.DrawImage(ComBitmap, LeftMarginPixel+((i-1)*JumArea), TopMarginPixel+((j-1)*JumArea), 18, 18);
					}
				}
			}
			g.Dispose();

		}

		/// <summary>
		/// �����ǿ� ���콺�� ������ ȣ��Ǵ� �޼ҵ�
		/// </summary>
		/// <param name="e">�� ���ڷ� ���콺�� Ŭ���Ѱ��� ��ǥ�� �о��</param>
		protected override void OnMouseDown(MouseEventArgs e) 
		{
			bool bAICapture = false;

			//�¸����� �Ѽ� ������, ���콺ĸ�ĸ� Ǯ��, ���� �ٲ۴�.
			if(bWinMulligi == true) 
			{	
				bMouseCapture = false;
				//�¸� �߿��� ���� �̰����� �̸� ���� �ٲپ� �־�� �ȴ�
				if(bComWin && !bUserWin)	
				{
					TurnStone(ref nKindOfStartStone);
				}
			}

			if(bMouseCapture == false) 
			{
				//���콺�� ������ �ȼ��� �ٵ��� 19*19ǥ�� ������ data
				Point ptChakJum = new Point();	
				//�ȼ���ǥ�� 19*19�� ��ȯ, 19�� �ٵ��� �� cell�� �ȼ� �� 
				ptChakJum.X = (e.X - LeftMarginPixel)/JumArea+1; 
				ptChakJum.Y = (e.Y - TopMarginPixel)/JumArea+1;

				//����� ���� ���� ����
				switch((Result)omokData.ManageOfUserJum(ptChakJum, nKindOfStartStone)) 
				{
					case Result.Win :
						bMouseCapture = true;
						bAICapture = true;

						bUserWin = true;
						bComWin = false;	//����� �¸������� ��Ÿ���� ����
						bWinAfter = true;

						Invalidate(new Rectangle(LeftMarginPixel+((ptChakJum.X-1)*JumArea), TopMarginPixel+((ptChakJum.Y-1)*JumArea), 18, 18));
						// 5�� ���� ������ �̾ �����ָ� ������...
						MessageBox.Show("You win, congratulation!", "*^^*");
						break;

					case Result.SamSam :
						MessageBox.Show("��, �ű�θ� ����Դϴ�. \n�ٽ� �μ���!!", "-.-;");
						bAICapture = true; //����̴ϱ� �ٽ� �α����� ��� AI�� ���
						break;

					case Result.Nothing :
						TurnStone(ref nKindOfStartStone);	//���� �ΰ� ��ǻ�͵��� �Ѱ��ְ�,
						bAICapture = false;		//��ǻ�� AI�� �ϱ����ؼ�
						// ȭ�� �������� ���ֱ� ���� ���ŵ� �κи� ȭ�鿡 �ٽ� �ѷ��ش�.
						Invalidate(new Rectangle(LeftMarginPixel+((ptChakJum.X-1)*JumArea), TopMarginPixel+((ptChakJum.Y-1)*JumArea), 18, 18));
						break;

					case Result.Occupied :
						//�ִµ� ���� �� �θ� ����ڰ� �ٽ� �ξ�� �ϴϱ�, TRUE��!
						bAICapture = true;	
						break;
					default :
						break;
				}

	
				//��ǻ�Ͱ� �δ� �Ϳ� ���� ó��
				if(bAICapture==false) 
				{
					switch((Result)omokData.ManageOfAIJum(nKindOfStartStone)) 
					{
						case Result.Win :
							bMouseCapture = true;

							//���� �¸� �߽��� ��Ÿ���� ������
							bComWin = true;
							bUserWin = false;
							bWinAfter = true;
							Invalidate(new Rectangle(LeftMarginPixel+((omokData.ptStore[omokData.StackTop-1].X-1)*JumArea), TopMarginPixel+((omokData.ptStore[omokData.StackTop-1].Y-1)*JumArea), 18, 18));
							MessageBox.Show("Com win, You lose", "-_-;");
							break;
						case Result.SamSam :
							break;
						case Result.Nothing :
							TurnStone(ref nKindOfStartStone);
							// ȭ�� �������� ���ֱ� ���� ���ŵ� �κи� ȭ�鿡 �ٽ� �ѷ��ش�.
							Invalidate(new Rectangle(LeftMarginPixel+((omokData.ptStore[omokData.StackTop-1].X-1)*JumArea), TopMarginPixel+((omokData.ptStore[omokData.StackTop-1].Y-1)*JumArea), 18, 18));
							break;
						default :
							break;
					}
				}
			}

			//�¸����� �Ѽ� ������ �¸��Ѱ��� ���������� 
			bWinMulligi = false;	
		}

		/// <summary>
		/// ���� ���� �����ִ� �޼���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemNew_Click(object sender, System.EventArgs e)
		{
			bMouseCapture = false;
			//���� ���� �����ϸ� ����ؼ� ��ȭ���ڸ� �ٽ� ���� ���� while����.
	
			// ���� ���� �����ش�.
			StartForm sf = new StartForm();
		
			// ���� ���� �ϴ��� �� �� �ִ�.
			if(sf.ShowDialog() == DialogResult.Yes) 
			{
				nKindOfStartStone = (int)JumInfo.Black;
				UserBitmap = new Bitmap(@"black.GIF");
				UserBitmap.MakeTransparent(Color.Cyan);
				ComBitmap = new Bitmap(@"white.GIF");
				ComBitmap.MakeTransparent(Color.Cyan);
			}
			else 
			{
				nKindOfStartStone = (int)JumInfo.White;
				UserBitmap = new Bitmap(@"white.GIF");
				UserBitmap.MakeTransparent(Color.Cyan);
				ComBitmap = new Bitmap(@"black.GIF");
				ComBitmap.MakeTransparent(Color.Cyan);
			}
			GameStart();
		}

		/// <summary>
		/// ����ڿ� ���� ������ �ٲپ� �ִ� �Լ�
		/// </summary>
		/// <param name="turn">���� ���� ���� ������ ��Ÿ���� ���� ���´�.</param>		
		void TurnStone(ref int turn) 
		{
			if(turn == (int)JumInfo.Black)	turn = (int)JumInfo.White;
			else turn = (int)JumInfo.Black;
		}

		/// <summary>
		///  ù ��ȭ���ڸ� ��ġ�� ����Ǵ� �Լ��μ� �ٵ����� �ʱ�ȭ�� 
		///  ������ ������ �� �ְԲ� �ϴ� �Լ� 
		/// </summary>
		public void GameStart()
		{
			omokData.InitializeOmok();			//�ٵ��� �ʱ�ȭ ��, ������ �� ����
			Invalidate();		//OnPaint�Լ� ȣ��! (���� ���߿� ���Լ��� �Ҹ������� �ٽ� �׷��� �ϹǷ�)

			if(nKindOfStartStone==(int)JumInfo.White) 
			{				//������ ���̸�
				Point point = new Point(10,10);		//���� ó�� �� �ڸ��� �����ϰ�
				omokData.WriteJum(point, nKindOfStartStone); //��(������)�� �д� 
				TurnStone(ref nKindOfStartStone);			//�׸��� �ٽ� ����ڵ��� �ٲ��ش�. 
			}

		}

		/// <summary>
		/// ���α׷��� �����ϴ� �޼ҵ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemQuit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// ���� ���� �����ִ� �޼ҵ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemInfo_Click(object sender, System.EventArgs e)
		{
			AboutForm f = new AboutForm();
			f.ShowDialog();
		}

		/// <summary>
		/// �Ѽ� �����⸦ �ϴ� �޼ҵ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemMulligi_Click(object sender, System.EventArgs e)
		{
			if(omokData.StackTop > 0) 
			{
				omokData.StackTop--;
				omokData.nJums[omokData.ptStore[omokData.StackTop].X, omokData.ptStore[omokData.StackTop].Y] = (int)JumInfo.Empty;
				Invalidate(new Rectangle(LeftMarginPixel+((omokData.ptStore[omokData.StackTop].X-1)*JumArea), TopMarginPixel+((omokData.ptStore[omokData.StackTop].Y-1)*JumArea), 18, 18));
			}
			if(omokData.StackTop > 0) 
			{
				omokData.StackTop--;
				omokData.nJums[omokData.ptStore[omokData.StackTop].X, omokData.ptStore[omokData.StackTop].Y] = (int)JumInfo.Empty;
				Invalidate(new Rectangle(LeftMarginPixel+((omokData.ptStore[omokData.StackTop].X-1)*JumArea), TopMarginPixel+((omokData.ptStore[omokData.StackTop].Y-1)*JumArea), 18, 18));
			}

			if(bWinAfter) 
			{	//�¸��� �� �����⸦ �Ѵٸ� 
				bWinMulligi = true;	
				bWinAfter = false;	//�̱�������� ���ư�����
			}
		}

		/// <summary>
		/// �������� ��ġȭ�ؼ� �����ִ� �޼ҵ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void menuItemCurrentOmokPanInfo_Click(object sender, System.EventArgs e)
		{
			OmokJumsInfoForm opf = new OmokJumsInfoForm();
			string str = "";
			for(int j=0; j<21; j++)
			{
				for(int i=0; i<21; i++)
				{
					str = str.Insert(str.Length, omokData.nJums[i,j].ToString());
				}
			}
			opf.InputOmokPan(str);
			if(opf.ShowDialog() == DialogResult.OK) 
			{
				for(int j=0; j<21; j++) 
				{
					for(int i=0; i<21; i++) 
					{
						omokData.nJums[i,j] = Convert.ToInt32(opf.strOmokPan[i+j*21].ToString());
					}
				}
				Invalidate();
			}

		}

	}
}
