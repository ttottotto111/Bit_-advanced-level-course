namespace ExtDataSet
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tblPeopleBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
			this.tblPeopleBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
			this.tblPeopleDataGridView = new System.Windows.Forms.DataGridView();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnMerong = new System.Windows.Forms.Button();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.tblPeopleBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.aDOTestDataSet = new ExtDataSet.ADOTestDataSet();
			this.tblPeopleTableAdapter = new ExtDataSet.ADOTestDataSetTableAdapters.tblPeopleTableAdapter();
			this.tableAdapterManager = new ExtDataSet.ADOTestDataSetTableAdapters.TableAdapterManager();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingNavigator)).BeginInit();
			this.tblPeopleBindingNavigator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.aDOTestDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// tblPeopleBindingNavigator
			// 
			this.tblPeopleBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
			this.tblPeopleBindingNavigator.BindingSource = this.tblPeopleBindingSource;
			this.tblPeopleBindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this.tblPeopleBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
			this.tblPeopleBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tblPeopleBindingNavigatorSaveItem});
			this.tblPeopleBindingNavigator.Location = new System.Drawing.Point(0, 0);
			this.tblPeopleBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.tblPeopleBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.tblPeopleBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.tblPeopleBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.tblPeopleBindingNavigator.Name = "tblPeopleBindingNavigator";
			this.tblPeopleBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this.tblPeopleBindingNavigator.Size = new System.Drawing.Size(427, 25);
			this.tblPeopleBindingNavigator.TabIndex = 0;
			this.tblPeopleBindingNavigator.Text = "bindingNavigator1";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "처음으로 이동";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "이전으로 이동";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "위치";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "현재 위치";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
			this.bindingNavigatorCountItem.Text = "/{0}";
			this.bindingNavigatorCountItem.ToolTipText = "전체 항목 수";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "다음으로 이동";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "마지막으로 이동";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorAddNewItem.Text = "새로 추가";
			// 
			// bindingNavigatorDeleteItem
			// 
			this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
			this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
			this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorDeleteItem.Text = "삭제";
			// 
			// tblPeopleBindingNavigatorSaveItem
			// 
			this.tblPeopleBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tblPeopleBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tblPeopleBindingNavigatorSaveItem.Image")));
			this.tblPeopleBindingNavigatorSaveItem.Name = "tblPeopleBindingNavigatorSaveItem";
			this.tblPeopleBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
			this.tblPeopleBindingNavigatorSaveItem.Text = "데이터 저장";
			this.tblPeopleBindingNavigatorSaveItem.Click += new System.EventHandler(this.tblPeopleBindingNavigatorSaveItem_Click);
			// 
			// tblPeopleDataGridView
			// 
			this.tblPeopleDataGridView.AutoGenerateColumns = false;
			this.tblPeopleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tblPeopleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn1});
			this.tblPeopleDataGridView.DataSource = this.tblPeopleBindingSource;
			this.tblPeopleDataGridView.Location = new System.Drawing.Point(12, 28);
			this.tblPeopleDataGridView.Name = "tblPeopleDataGridView";
			this.tblPeopleDataGridView.RowTemplate.Height = 23;
			this.tblPeopleDataGridView.Size = new System.Drawing.Size(395, 194);
			this.tblPeopleDataGridView.TabIndex = 1;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(76, 244);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnMerong
			// 
			this.btnMerong.Location = new System.Drawing.Point(230, 244);
			this.btnMerong.Name = "btnMerong";
			this.btnMerong.Size = new System.Drawing.Size(75, 23);
			this.btnMerong.TabIndex = 3;
			this.btnMerong.Text = "Merong";
			this.btnMerong.UseVisualStyleBackColor = true;
			this.btnMerong.Click += new System.EventHandler(this.btnMerong_Click);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn1.HeaderText = "Name";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Age";
			this.dataGridViewTextBoxColumn2.HeaderText = "Age";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "Male";
			this.dataGridViewCheckBoxColumn1.HeaderText = "Male";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			// 
			// tblPeopleBindingSource
			// 
			this.tblPeopleBindingSource.DataMember = "tblPeople";
			this.tblPeopleBindingSource.DataSource = this.aDOTestDataSet;
			// 
			// aDOTestDataSet
			// 
			this.aDOTestDataSet.DataSetName = "ADOTestDataSet";
			this.aDOTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tblPeopleTableAdapter
			// 
			this.tblPeopleTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.tblPeopleTableAdapter = this.tblPeopleTableAdapter;
			this.tableAdapterManager.UpdateOrder = ExtDataSet.ADOTestDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(427, 279);
			this.Controls.Add(this.btnMerong);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.tblPeopleDataGridView);
			this.Controls.Add(this.tblPeopleBindingNavigator);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingNavigator)).EndInit();
			this.tblPeopleBindingNavigator.ResumeLayout(false);
			this.tblPeopleBindingNavigator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.aDOTestDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ADOTestDataSet aDOTestDataSet;
		private System.Windows.Forms.BindingSource tblPeopleBindingSource;
		private ExtDataSet.ADOTestDataSetTableAdapters.tblPeopleTableAdapter tblPeopleTableAdapter;
		private ExtDataSet.ADOTestDataSetTableAdapters.TableAdapterManager tableAdapterManager;
		private System.Windows.Forms.BindingNavigator tblPeopleBindingNavigator;
		private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.ToolStripButton tblPeopleBindingNavigatorSaveItem;
		private System.Windows.Forms.DataGridView tblPeopleDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnMerong;
	}
}

