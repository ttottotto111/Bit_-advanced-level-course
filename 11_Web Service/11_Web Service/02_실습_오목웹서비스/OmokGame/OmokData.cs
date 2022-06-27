using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace OmokGame
{	
	/// <summary>
	/// �������� �������� ������ �ְ�, ���� �� ���񽺿� ����ϴ� Ŭ����
	/// </summary>
	public class OmokData
	{	
		/// <summary>
		/// �ΰ����� ��ü�� ������
		/// </summary>		
		localhost.Service1 AI;

		/// <summary>
		/// �ٵ����� ������ ��Ÿ���� ����, 19*19�ܰ��� �� �ϳ��� ��輱�� �����.
		/// �ڵ����� 0���� �ʱ�ȭ�ȴ�
		/// </summary>		
		public int[,] nJums = new int[21,21];

		/// <summary>
		/// �����⸦ ���� ó������ ���� �а��� ���ʷ� �����صα� ���� ����
		/// </summary>		
		public Point[] ptStore = new Point[441];

		/// <summary>
		/// ���� �迭�� �������� �̿��ϱ� ���� ���̴� ���� 
		/// </summary>
		public int StackTop;
	
		public OmokData() 
		{
			//
			// TODO: Add constructor logic here
			//
			AI = new localhost.Service1();	// �ʱ�ȭ
			InitializeOmok();
			StackTop = 0;	//������ ����.	
		}

		/// <summary>
		/// ���� ������ �ʱ�ȭ�ϴ� �޼ҵ�
		/// </summary>
		public void InitializeOmok() 
		{
			nJums = new int[21,21];
			for(int i=0; i<21; i++) 
			{
				nJums[i,0] = (int)JumInfo.Boundary; //top ��輱 
				nJums[0,i] = (int)JumInfo.Boundary; //left ��輱 
				nJums[20,i] = (int)JumInfo.Boundary; //right ��輱 
				nJums[i,20] = (int)JumInfo.Boundary; //bottom ��輱 
			}
			ptStore = new Point[441];
		}


		/// <summary>
		/// ���ڷ� ���� ��ǥ�� ���ڷ� ���� ���� ������ �Է��Ѵ�
		/// </summary>
		/// <param name="ptChakJum">���� �� ���� ��ǥ</param>
		/// <param name="kindOfStone">���� �� ���� ����</param>		
		public void WriteJum(Point ptChakJum, int kindOfStone) 
		{
			//ptChackJum�� ����� ��ġ�� nTurn�� ����� ���� ������ ������!
			nJums[ptChakJum.X, ptChakJum.Y] = kindOfStone;
			//������ҿ� �ξ��� ��ġ�� ������. �� ���ÿ� Push!
			ptStore[StackTop].X = ptChakJum.X;	
			ptStore[StackTop].Y = ptChakJum.Y; 
			StackTop++;	
		}

		/// <summary>
		/// �ش� ���� ������� �������� �ִ��� ���� �ִ����� ����!
		/// </summary>
		/// <param name="i">�ش� ��ǥ�� x</param>
		/// <param name="j">�ش� ��ǥ�� y</param>
		/// <returns>�ش� ���� ����</returns>		
		public int GetKindOfJum(int i, int j) 
		{
			return(nJums[i,j]);
		}

		/// <summary>
		/// ����� ���� �����ϴ� �Լ� 
		/// ��, ����ڰ� ���� ���� ������ ���� � ����� ����� ���� �˾Ƴ��� �Լ� 
		/// </summary>
		/// <param name="ptJum">����ڰ� ���� ���� ���� ��ǥ</param>
		/// <param name="nKindOfStone">����ڰ� � ���� ���Ҵ°�</param>
		/// <returns>�����</returns>		
		public int ManageOfUserJum(Point ptJum, int nKindOfStone) 
		{
			//�ش����� �̹� ���� ������ �Ѿ
			if(GetKindOfJum(ptJum.X, ptJum.Y)==(int)JumInfo.Empty) 
			{ 
				// [,] �迭�� ������ ���ڷ� ���������� string���� ��ȯ�ؾ��Ѵ�.
				// ���� �������� ���η� (0,0).. (20,0)���� ǥ�õȴ�.
				string strJum = "";
				for(int j=0; j<21; j++)
				{
					for(int i=0; i<21; i++)
					{
						strJum = strJum.Insert(strJum.Length, nJums[i,j].ToString());
					}
				}

				try 
				{
					string str = AI.CheckChakJum(strJum, ptJum.X, ptJum.Y, nKindOfStone);
					//������ � ���� �ִ����� ������ ����
					WriteJum(ptJum, nKindOfStone);   
					switch(str) 
					{
						case "Win":
							//����ڰ� �̰��� ��
							return (int)Result.Win;	
						case "SamSam" : 
							//������� ����
							nJums[ptJum.X, ptJum.Y] = (int)JumInfo.Empty;	
							//���ÿ� �����ߴ� ���� ��ǥ�� POP!!
							StackTop--;	
							return (int)Result.SamSam;
						case "Nothing" :
							// �ƹ��͵� �ƴ� ���� ����
							return (int)Result.Nothing; 
					}
				} 
				catch(WebException e) 
				{	
					MessageBox.Show(e.Message, "���� �� ���񽺿� ������ ���� ������ �ֽ��ϴ�");
					return (int)Result.Problem;
				}


			}
			// �̹� ������ ���� �������� 
			return (int)Result.Occupied;	
		}


		/// <summary>
		/// ��ǻ�� ���� �����ϴ� �Լ� 
		/// ��, ��ǻ�Ͱ� ���� ���� �˾Ƴ���, �� ������ ���� � ����� ����� ���� �˾Ƴ��� �Լ� 
		/// </summary>
		/// <param name="ComStone">���� ����</param>
		/// <returns>�����</returns>		
		public int ManageOfAIJum(int ComStone) 
		{
			// �� �κ��� �� ���񽺸� �޴� �κ��̴�.
			try 
			{
				// [,] �迭�� ������ ���ڷ� ���������� string���� ��ȯ�ؾ��Ѵ�.
				// ���� �������� ���η� (0,0).. (20,0)���� ǥ�õȴ�.
				string strJum = "";
				for(int j=0; j<21; j++)
				{
					for(int i=0; i<21; i++)
					{
						strJum = strJum.Insert(strJum.Length, nJums[i,j].ToString());
					}
				}

				// ���� �� �޼ҵ带 ȣ��!!
				// �� �� �޼ҵ��� ���ϰ��� Point.ToString() ��, ���ڿ� "{X= ,Y= }"�̴�.
				// �̰͵� Point ����ü�� ��ȯ�� �ʿ䰡 �ִ�.
				StringBuilder strAIpt = new StringBuilder(AI.GetBestJum(strJum, ComStone));
				strAIpt.Replace("{X=", "");
				strAIpt.Replace("Y=", "");
				strAIpt.Replace("}", "");

				string str = strAIpt.ToString();
				char[] separators = new char[] {','};
				Point pt = new Point();
				string[] sub  = str.Split(separators);
				pt.X = Convert.ToInt32(sub[0]);	// beta2
				pt.Y = Convert.ToInt32(sub[1]);	// beta2
					
				WriteJum(pt, ComStone);	//��ǻ�Ͱ� �� �����ٰ� �ĵ��� �Է� 

				string strResult = AI.CheckChakJum(strJum, pt.X, pt.Y, ComStone);	// 	�����񽺸� �̿�����.
				if(strResult == "Win") return (int)Result.Win;
				else return (int)Result.Nothing;

			} 
			catch(WebException e) 
			{
				MessageBox.Show(e.Message, "���� �� ���񽺿� ������ ���� ������ �ֽ��ϴ�");
				return (int)Result.Problem;
			}
		}
	}
}
