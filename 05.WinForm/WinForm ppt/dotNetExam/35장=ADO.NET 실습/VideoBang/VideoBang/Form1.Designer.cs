namespace VideoBang
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
            this.lvMember = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.lvVideo = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.lvRent = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.btnAddMem = new System.Windows.Forms.Button();
            this.btnEditMem = new System.Windows.Forms.Button();
            this.btnDelMem = new System.Windows.Forms.Button();
            this.btnAddVideo = new System.Windows.Forms.Button();
            this.btnEditVideo = new System.Windows.Forms.Button();
            this.btnDelVideo = new System.Windows.Forms.Button();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMember
            // 
            this.lvMember.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvMember.FullRowSelect = true;
            this.lvMember.HideSelection = false;
            this.lvMember.Location = new System.Drawing.Point(14, 31);
            this.lvMember.Name = "lvMember";
            this.lvMember.Size = new System.Drawing.Size(260, 164);
            this.lvMember.TabIndex = 1;
            this.lvMember.UseCompatibleStateImageBehavior = false;
            this.lvMember.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "회원 목록";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "번호";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "이름";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "등급";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "예치금";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "대여";
            this.columnHeader5.Width = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "비디오 목록";
            // 
            // lvVideo
            // 
            this.lvVideo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvVideo.FullRowSelect = true;
            this.lvVideo.HideSelection = false;
            this.lvVideo.Location = new System.Drawing.Point(14, 259);
            this.lvVideo.Name = "lvVideo";
            this.lvVideo.Size = new System.Drawing.Size(260, 208);
            this.lvVideo.TabIndex = 6;
            this.lvVideo.UseCompatibleStateImageBehavior = false;
            this.lvVideo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "번호";
            this.columnHeader6.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "제목";
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "유형";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "개수";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "대여 목록";
            // 
            // lvRent
            // 
            this.lvRent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lvRent.FullRowSelect = true;
            this.lvRent.HideSelection = false;
            this.lvRent.Location = new System.Drawing.Point(299, 31);
            this.lvRent.Name = "lvRent";
            this.lvRent.Size = new System.Drawing.Size(291, 436);
            this.lvRent.TabIndex = 11;
            this.lvRent.UseCompatibleStateImageBehavior = false;
            this.lvRent.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "번호";
            this.columnHeader10.Width = 40;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "날짜";
            this.columnHeader11.Width = 85;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "회원";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "비디오";
            this.columnHeader13.Width = 90;
            // 
            // btnAddMem
            // 
            this.btnAddMem.Location = new System.Drawing.Point(14, 201);
            this.btnAddMem.Name = "btnAddMem";
            this.btnAddMem.Size = new System.Drawing.Size(75, 23);
            this.btnAddMem.TabIndex = 2;
            this.btnAddMem.Text = "새회원";
            this.btnAddMem.UseVisualStyleBackColor = true;
            this.btnAddMem.Click += new System.EventHandler(this.btnAddMem_Click);
            // 
            // btnEditMem
            // 
            this.btnEditMem.Location = new System.Drawing.Point(108, 201);
            this.btnEditMem.Name = "btnEditMem";
            this.btnEditMem.Size = new System.Drawing.Size(75, 23);
            this.btnEditMem.TabIndex = 3;
            this.btnEditMem.Text = "정보 수정";
            this.btnEditMem.UseVisualStyleBackColor = true;
            this.btnEditMem.Click += new System.EventHandler(this.btnEditMem_Click);
            // 
            // btnDelMem
            // 
            this.btnDelMem.Location = new System.Drawing.Point(199, 201);
            this.btnDelMem.Name = "btnDelMem";
            this.btnDelMem.Size = new System.Drawing.Size(75, 23);
            this.btnDelMem.TabIndex = 4;
            this.btnDelMem.Text = "탈퇴";
            this.btnDelMem.UseVisualStyleBackColor = true;
            this.btnDelMem.Click += new System.EventHandler(this.btnDelMem_Click);
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.Location = new System.Drawing.Point(12, 473);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(75, 23);
            this.btnAddVideo.TabIndex = 7;
            this.btnAddVideo.Text = "새비디오";
            this.btnAddVideo.UseVisualStyleBackColor = true;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // btnEditVideo
            // 
            this.btnEditVideo.Location = new System.Drawing.Point(106, 473);
            this.btnEditVideo.Name = "btnEditVideo";
            this.btnEditVideo.Size = new System.Drawing.Size(75, 23);
            this.btnEditVideo.TabIndex = 8;
            this.btnEditVideo.Text = "정보 수정";
            this.btnEditVideo.UseVisualStyleBackColor = true;
            this.btnEditVideo.Click += new System.EventHandler(this.btnEditVideo_Click);
            // 
            // btnDelVideo
            // 
            this.btnDelVideo.Location = new System.Drawing.Point(197, 473);
            this.btnDelVideo.Name = "btnDelVideo";
            this.btnDelVideo.Size = new System.Drawing.Size(75, 23);
            this.btnDelVideo.TabIndex = 9;
            this.btnDelVideo.Text = "삭제";
            this.btnDelVideo.UseVisualStyleBackColor = true;
            this.btnDelVideo.Click += new System.EventHandler(this.btnDelVideo_Click);
            // 
            // btnRent
            // 
            this.btnRent.Location = new System.Drawing.Point(299, 473);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(75, 23);
            this.btnRent.TabIndex = 12;
            this.btnRent.Text = "대여";
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(380, 473);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 13;
            this.btnReturn.Text = "반납";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 505);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.btnDelVideo);
            this.Controls.Add(this.btnDelMem);
            this.Controls.Add(this.btnEditVideo);
            this.Controls.Add(this.btnEditMem);
            this.Controls.Add(this.btnAddVideo);
            this.Controls.Add(this.btnAddMem);
            this.Controls.Add(this.lvRent);
            this.Controls.Add(this.lvVideo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvMember);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvVideo;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvRent;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Button btnAddMem;
        private System.Windows.Forms.Button btnEditMem;
        private System.Windows.Forms.Button btnDelMem;
        private System.Windows.Forms.Button btnAddVideo;
        private System.Windows.Forms.Button btnEditVideo;
        private System.Windows.Forms.Button btnDelVideo;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnReturn;
    }
}

