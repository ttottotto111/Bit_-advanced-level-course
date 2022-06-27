using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VideoBang
{
    public partial class Form1 : Form
    {
        private SqlConnection Con, Con2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = "Server=(local);database=Video;" +
                "Integrated Security=true";
            Con.Open();
            Con2 = new SqlConnection();
            Con2.ConnectionString = "Server=(local);database=Video;" +
                "Integrated Security=true";
            Con2.Open();

            RefreshMember();
            RefreshVideo();
            RefreshRent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Con.Close();
            Con2.Close();
        }

        private void RefreshMember()
        {
            int nRent;
            lvMember.Items.Clear();
            SqlCommand Com = new SqlCommand("SELECT Pk, Name, Grade, Money FROM tblMember", Con);
            SqlDataReader R = Com.ExecuteReader();
            while (R.Read())
            {
                SqlCommand Com2 = new SqlCommand("SELECT COUNT(*) FROM tblRent WHERE Who = " + 
                    R["Pk"].ToString() + " AND Retdate IS NULL", Con2);

                nRent = (int)Com2.ExecuteScalar();
                lvMember.Items.Add(new ListViewItem(new string[] { R["Pk"].ToString(),
                    R["Name"].ToString(), R["Grade"].ToString(), R["Money"].ToString(), 
                    nRent.ToString()}));
            }
            R.Close();
        }

        private void RefreshVideo()
        {
            int Num, nRent;
            lvVideo.Items.Clear();
            SqlCommand Com = new SqlCommand("SELECT Pk, Name, Genre, Num FROM tblVideo", Con);
            SqlDataReader R = Com.ExecuteReader();
            while (R.Read())
            {
                Num = (int)R["Num"];
                SqlCommand Com2 = new SqlCommand("SELECT COUNT(*) FROM tblRent WHERE What = " +
                    R["Pk"].ToString() + "AND Rentdate IS NOT NULL AND RetDate IS NULL", Con2);
                nRent = (int)Com2.ExecuteScalar();
                
                lvVideo.Items.Add(new ListViewItem(new string[] { R["Pk"].ToString(),
                    R["Name"].ToString(), R["Genre"].ToString(),  
                    string.Format("{0}/{1}",nRent,Num)}));
            }
            R.Close();

        }

        private void RefreshRent()
        {
            lvRent.Items.Clear();
            SqlCommand Com = new SqlCommand("SELECT tblRent.Pk, tblRent.Rentdate, tblMember.Name, tblVideo.Name " +
                "FROM tblMember INNER JOIN tblRent ON tblMember.Pk = Who INNER JOIN tblVideo " +
                "ON tblVideo.Pk = What WHERE Retdate IS NULL ORDER BY Rentdate", Con);
            SqlDataReader R = Com.ExecuteReader();
            while (R.Read())
            {
                lvRent.Items.Add(new ListViewItem(new string[] { R["Pk"].ToString(),
                    R[1].ToString(), R[2].ToString(), R[3].ToString()
                    }));
            }
            R.Close();

        }

        private void btnAddMem_Click(object sender, EventArgs e)
        {
            MemberForm dlg = new MemberForm();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string qry = string.Format("INSERT INTO tblMember (Name,Grade,Byear,Tel," + 
                    "Addr,Money) VALUES ('{0}',{1},{2},'{3}','{4}',{5})", 
                    dlg.Name1, dlg.Grade, dlg.BYear, dlg.Tel, dlg.Addr, dlg.Money);
                SqlCommand Com = new SqlCommand(qry, Con);
                Com.ExecuteNonQuery();
                RefreshMember();
            }
        }

        private void btnEditMem_Click(object sender, EventArgs e)
        {
            int Pk;

            if (lvMember.SelectedItems.Count == 0) 
            {
                MessageBox.Show("수정할 회원을 먼저 선택하십시오.");
                return;
            }
            Pk = Convert.ToInt32(lvMember.SelectedItems[0].SubItems[0].Text);

            MemberForm dlg = new MemberForm();
            dlg.radioButton1.Enabled = false;
            dlg.radioButton2.Enabled = false;
            dlg.radioButton3.Enabled = false;

            SqlCommand Com = new SqlCommand("SELECT Name, Byear, Money, Tel, Addr, Grade FROM " +
                "tblMember WHERE Pk = " + Pk.ToString(), Con);
            SqlDataReader R = Com.ExecuteReader();
            R.Read();
            dlg.Name1 = R["Name"].ToString();
            dlg.BYear = (int)R["BYear"];
            dlg.Money = (int)R["Money"];
            dlg.Tel = R["Tel"].ToString();
            dlg.Addr = R["Addr"].ToString();
            dlg.Grade = (int)R["Grade"];
            R.Close();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string qry = string.Format("UPDATE tblMember Set Name = '{0}', Grade = {1}, "+
					"Byear = {2}, Tel = '{3}', Addr = '{4}', Money = {5} WHERE Pk = {6}",
                    dlg.Name1, dlg.Grade, dlg.BYear, dlg.Tel, dlg.Addr, dlg.Money, Pk);
                Com = new SqlCommand(qry, Con);
                Com.ExecuteNonQuery();
                RefreshMember();
            }
        }

        private void btnDelMem_Click(object sender, EventArgs e)
        {
            int Pk;
            SqlCommand Com;

            if (lvMember.SelectedItems.Count == 0)
            {
                MessageBox.Show("탈퇴할 회원을 먼저 선택하십시오.");
                return;
            }
            Pk = Convert.ToInt32(lvMember.SelectedItems[0].SubItems[0].Text);

            Com = new SqlCommand("SELECT Money FROM tblMember WHERE Pk = " +
                Pk.ToString(), Con);
            if ((int)Com.ExecuteScalar() < 0)
            {
                MessageBox.Show("미수금이 있으므로 갚은 후 탈퇴하시오.");
                return;
            }

            Com = new SqlCommand("SELECT COUNT(*) FROM tblRent WHERE Who = " +
                Pk.ToString(), Con);
            if ((int)Com.ExecuteScalar() != 0)
            {
                MessageBox.Show("미반납 테입을 반납한 후 탈퇴하시오.");
                return;
            }

            Com = new SqlCommand("DELETE FROM tblMember WHERE Pk = " +
                Pk.ToString(), Con);
            Com.ExecuteNonQuery();
			RefreshMember();
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            VideoForm dlg = new VideoForm();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string qry = string.Format("INSERT INTO tblVideo (Name, Num, Company, Director," + 
                    "Major, Genre) VALUES ('{0}',{1},'{2}','{3}','{4}','{5}');",
                    dlg.Name1, dlg.Num, dlg.Company, dlg.Director, dlg.Major, dlg.Genre);
                SqlCommand Com = new SqlCommand(qry, Con);
                Com.ExecuteNonQuery();
                RefreshVideo();
            }
        }

        private void btnEditVideo_Click(object sender, EventArgs e)
        {
            int Pk;

            if (lvVideo.SelectedItems.Count == 0)
            {
                MessageBox.Show("수정할 비디오를 먼저 선택하십시오.");
                return;
            }
            Pk = Convert.ToInt32(lvVideo.SelectedItems[0].SubItems[0].Text);

            VideoForm dlg = new VideoForm();

            SqlCommand Com = new SqlCommand("SELECT Name, Num, Company, Director, Major, Genre FROM " +
                "tblVideo WHERE Pk = " + Pk.ToString(), Con);
            SqlDataReader R = Com.ExecuteReader();
            R.Read();
            dlg.Name1 = R["Name"].ToString();
            dlg.Num = (int)R["Num"];
            dlg.Company = R["Company"].ToString();
            dlg.Director = R["Director"].ToString();
            dlg.Major = R["Major"].ToString();
            dlg.Genre = R["Genre"].ToString();
            R.Close();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string qry = string.Format("UPDATE tblVideo Set Name = '{0}', Num = {1}, Company = '{2}', " +
                    "Director = '{3}', Major = '{4}', Genre = '{5}' WHERE Pk = {6}",
                    dlg.Name1, dlg.Num, dlg.Company, dlg.Director, dlg.Major, dlg.Genre, Pk);
                Com = new SqlCommand(qry, Con);
                Com.ExecuteNonQuery();
                RefreshVideo();
            }
        }

        private void btnDelVideo_Click(object sender, EventArgs e)
        {
            int Pk;
            SqlCommand Com;

            if (lvVideo.SelectedItems.Count == 0)
            {
                MessageBox.Show("삭제할 비디오를 먼저 선택하십시오.");
                return;
            }
            Pk = Convert.ToInt32(lvVideo.SelectedItems[0].SubItems[0].Text);

            Com = new SqlCommand("SELECT COUNT(*) FROM tblRent WHERE What = " +
                Pk.ToString() + " AND Retdate IS NULL", Con);
            if ((int)Com.ExecuteScalar() != 0)
            {
                MessageBox.Show("대여중인 비디오는 삭제할 수 없습니다.");
                return;
            }

            Com = new SqlCommand("DELETE FROM tblVideo WHERE Pk = " +
                Pk.ToString(), Con);
            Com.ExecuteNonQuery();
			RefreshVideo();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            int Who = -1, What = -1;
            SqlCommand Com;
            int Byear, Price;
            int Money, Remain;
            int Sale, Grade;
            string qry;
            string sGenre;

            if (lvMember.SelectedItems.Count != 0)
            {
                Who = Convert.ToInt32(lvMember.SelectedItems[0].SubItems[0].Text);
            }

            if (lvVideo.SelectedItems.Count != 0)
            {
                What = Convert.ToInt32(lvVideo.SelectedItems[0].SubItems[0].Text);
            }

            if (Who == -1 || What == -1)
            {
                MessageBox.Show("회원과 비디오를 먼저 선택하십시오.");
                return;
            }

            Com = new SqlCommand("SELECT (SELECT Num FROM tblVideo WHERE Pk = " +
                What.ToString() + ")- COUNT(*) FROM tblRent WHERE What = " +
                What.ToString() + "AND Retdate IS NULL" , Con);
            Remain = (int)Com.ExecuteScalar();
            if (Remain == 0) 
            {
                MessageBox.Show("선택한 비디오가 모두 대여중입니다.");
                return;
            }

            Com = new SqlCommand("SELECT Price FROM tblGenre JOIN tblVideo " +
                "ON tblGenre.Name = tblVideo.Genre WHERE tblVideo.Pk = " +
                What.ToString() , Con);
            Price = (int)Com.ExecuteScalar();
            Com = new SqlCommand("SELECT Money FROM tblMember WHERE Pk = " +
                Who.ToString() , Con);
            Money = (int)Com.ExecuteScalar();
            if (Price > Money) 
            {
                MessageBox.Show("회원님의 예치금이 부족합니다.");
                return;
            }

            Com = new SqlCommand("SELECT Genre FROM tblVideo WHERE Pk = " +
                What.ToString() , Con);
            sGenre = (string)Com.ExecuteScalar();
            sGenre = sGenre.Trim();
            Com = new SqlCommand("SELECT Byear FROM tblMember WHERE Pk = " +
                Who.ToString(), Con);
            Byear = (int)Com.ExecuteScalar();
            if (sGenre == "에로" && DateTime.Now.Year - Byear < 19)
            {
                MessageBox.Show("이 테입은 미성년자에게 대여할 수 없습니다.");
                return;
            }

            // 대여 기록
            qry = string.Format("INSERT INTO tblRent (Who, What, Rentdate) " +
                "VALUES ({0}, {1}, GETDATE())", Who, What);
            Com = new SqlCommand(qry, Con);
            Com.ExecuteNonQuery();
            
            // 예치금 감소
            qry = string.Format("UPDATE tblMember SET Money = {0} WHERE Pk = {1}",
                Money-Price, Who);
            Com = new SqlCommand(qry, Con);
            Com.ExecuteNonQuery();

            // 총 매출로부터 등급 조정
            qry = string.Format("SELECT SUM(Price) FROM tblRent JOIN tblVideo ON tblVideo.Pk = " +
                "tblRent.What JOIN tblGenre ON tblVideo.Genre = tblGenre.Name WHERE who = {0}",Who);
            Com = new SqlCommand(qry, Con);
            Sale = (int)Com.ExecuteScalar();
            qry = string.Format("SELECT Grade FROM tblMember WHERE Pk = {0}",Who);
            Com = new SqlCommand(qry, Con);
            Grade = (int)Com.ExecuteScalar();
            if (Grade == 1 && Sale > 10000)
            {
                qry = string.Format("UPDATE tblMember SET Grade = 2 WHERE Pk = {0}",Who);
                Com = new SqlCommand(qry, Con);
                Com.ExecuteNonQuery();
            }
            if (Grade == 1 && Sale > 50000)
            {
                qry = string.Format("UPDATE tblMember SET Grade = 3 WHERE Pk = {0}",Who);
                Com = new SqlCommand(qry, Con);
                Com.ExecuteNonQuery();
            }
            RefreshMember();
            RefreshVideo();
            RefreshRent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int Pk;
            SqlCommand Com;
            int Elapse, Period, Grade;
            int Who;
            string qry;

            if (lvRent.SelectedItems.Count == 0)
            {
                MessageBox.Show("반납할 항목을 먼저 선택하십시오.");
                return;
            }
            Pk = Convert.ToInt32(lvRent.SelectedItems[0].SubItems[0].Text);

            // 과징금 계산
            qry = string.Format("SELECT DATEDIFF(day, Rentdate, GETDATE()) " +
                "FROM tblRent WHERE pk = {0}",Pk);
            Com = new SqlCommand(qry, Con);
            Elapse = (int)Com.ExecuteScalar();
            qry = string.Format("SELECT tblGenre.Period FROM tblRent JOIN tblVideo ON " +
                "tblRent.What = tblVideo.Pk JOIN tblGenre ON tblVideo.Genre = tblGenre.Name " +
                "WHERE tblRent.pk = {0}",Pk);
            Com = new SqlCommand(qry, Con);
            Period = (int)Com.ExecuteScalar();
            qry = string.Format("SELECT Who FROM tblRent WHERE Pk = {0}",Pk);
            Com = new SqlCommand(qry, Con);
            Who = (int)Com.ExecuteScalar();
            qry = string.Format("SELECT Grade FROM tblMember WHERE Pk = {0}",Who);
            Com = new SqlCommand(qry, Con);
            Grade = (int)Com.ExecuteScalar();
            if (Grade != 3 && Elapse > Period)
            {
                qry = string.Format("UPDATE tblMember SET Money = Money - {0} WHERE Pk = {1}",
                    (Elapse - Period) * 500,Who);
                Com = new SqlCommand(qry, Con);
                Com.ExecuteNonQuery();
            }

            // 대여 레코드 갱신
            qry = string.Format("UPDATE tblRent SET Retdate = GETDATE() WHERE Pk = {0}",
                Pk);
            Com = new SqlCommand(qry, Con);
            Com.ExecuteNonQuery();
            RefreshMember();
            RefreshVideo();
            RefreshRent();
        }
    }
}