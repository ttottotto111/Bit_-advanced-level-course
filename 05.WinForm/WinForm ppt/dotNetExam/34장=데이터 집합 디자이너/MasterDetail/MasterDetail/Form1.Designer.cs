namespace MasterDetail
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
			System.Windows.Forms.Label nameLabel;
			System.Windows.Forms.Label ageLabel;
			System.Windows.Forms.Label maleLabel;
			this.aDOTestDataSet = new MasterDetail.ADOTestDataSet();
			this.tblPeopleBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tblPeopleTableAdapter = new MasterDetail.ADOTestDataSetTableAdapters.tblPeopleTableAdapter();
			this.tableAdapterManager = new MasterDetail.ADOTestDataSetTableAdapters.TableAdapterManager();
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
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.ageTextBox = new System.Windows.Forms.TextBox();
			this.maleCheckBox = new System.Windows.Forms.CheckBox();
			this.tblSaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tblSaleTableAdapter = new MasterDetail.ADOTestDataSetTableAdapters.tblSaleTableAdapter();
			this.tblSaleDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			nameLabel = new System.Windows.Forms.Label();
			ageLabel = new System.Windows.Forms.Label();
			maleLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.aDOTestDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingNavigator)).BeginInit();
			this.tblPeopleBindingNavigator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tblSaleBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tblSaleDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// aDOTestDataSet
			// 
			this.aDOTestDataSet.DataSetName = "ADOTestDataSet";
			this.aDOTestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tblPeopleBindingSource
			// 
			this.tblPeopleBindingSource.DataMember = "tblPeople";
			this.tblPeopleBindingSource.DataSource = this.aDOTestDataSet;
			// 
			// tblPeopleTableAdapter
			// 
			this.tblPeopleTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.tblPeopleTableAdapter = this.tblPeopleTableAdapter;
			this.tableAdapterManager.tblSaleTableAdapter = this.tblSaleTableAdapter;
			this.tableAdapterManager.UpdateOrder = MasterDetail.ADOTestDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
			this.tblPeopleBindingNavigator.Size = new System.Drawing.Size(552, 25);
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
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 15);
			this.bindingNavigatorCountItem.Text = "/{0}";
			this.bindingNavigatorCountItem.ToolTipText = "전체 항목 수";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
			this.bindingNavigatorMoveNextItem.Text = "다음으로 이동";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
			this.bindingNavigatorMoveLastItem.Text = "마지막으로 이동";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
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
			this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
			this.bindingNavigatorDeleteItem.Text = "삭제";
			// 
			// tblPeopleBindingNavigatorSaveItem
			// 
			this.tblPeopleBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tblPeopleBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tblPeopleBindingNavigatorSaveItem.Image")));
			this.tblPeopleBindingNavigatorSaveItem.Name = "tblPeopleBindingNavigatorSaveItem";
			this.tblPeopleBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
			this.tblPeopleBindingNavigatorSaveItem.Text = "데이터 저장";
			this.tblPeopleBindingNavigatorSaveItem.Click += new System.EventHandler(this.tblPeopleBindingNavigatorSaveItem_Click);
			// 
			// nameLabel
			// 
			nameLabel.AutoSize = true;
			nameLabel.Location = new System.Drawing.Point(25, 60);
			nameLabel.Name = "nameLabel";
			nameLabel.Size = new System.Drawing.Size(43, 12);
			nameLabel.TabIndex = 1;
			nameLabel.Text = "Name:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblPeopleBindingSource, "Name", true));
			this.nameTextBox.Location = new System.Drawing.Point(74, 57);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(104, 21);
			this.nameTextBox.TabIndex = 2;
			// 
			// ageLabel
			// 
			ageLabel.AutoSize = true;
			ageLabel.Location = new System.Drawing.Point(25, 87);
			ageLabel.Name = "ageLabel";
			ageLabel.Size = new System.Drawing.Size(31, 12);
			ageLabel.TabIndex = 3;
			ageLabel.Text = "Age:";
			// 
			// ageTextBox
			// 
			this.ageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblPeopleBindingSource, "Age", true));
			this.ageTextBox.Location = new System.Drawing.Point(74, 84);
			this.ageTextBox.Name = "ageTextBox";
			this.ageTextBox.Size = new System.Drawing.Size(104, 21);
			this.ageTextBox.TabIndex = 4;
			// 
			// maleLabel
			// 
			maleLabel.AutoSize = true;
			maleLabel.Location = new System.Drawing.Point(25, 116);
			maleLabel.Name = "maleLabel";
			maleLabel.Size = new System.Drawing.Size(37, 12);
			maleLabel.TabIndex = 5;
			maleLabel.Text = "Male:";
			// 
			// maleCheckBox
			// 
			this.maleCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tblPeopleBindingSource, "Male", true));
			this.maleCheckBox.Location = new System.Drawing.Point(74, 111);
			this.maleCheckBox.Name = "maleCheckBox";
			this.maleCheckBox.Size = new System.Drawing.Size(104, 24);
			this.maleCheckBox.TabIndex = 6;
			this.maleCheckBox.Text = "checkBox1";
			this.maleCheckBox.UseVisualStyleBackColor = true;
			// 
			// tblSaleBindingSource
			// 
			this.tblSaleBindingSource.DataMember = "FK__tblSale__Custome__1A14E395";
			this.tblSaleBindingSource.DataSource = this.tblPeopleBindingSource;
			// 
			// tblSaleTableAdapter
			// 
			this.tblSaleTableAdapter.ClearBeforeFill = true;
			// 
			// tblSaleDataGridView
			// 
			this.tblSaleDataGridView.AutoGenerateColumns = false;
			this.tblSaleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tblSaleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
			this.tblSaleDataGridView.DataSource = this.tblSaleBindingSource;
			this.tblSaleDataGridView.Location = new System.Drawing.Point(214, 57);
			this.tblSaleDataGridView.Name = "tblSaleDataGridView";
			this.tblSaleDataGridView.RowTemplate.Height = 23;
			this.tblSaleDataGridView.Size = new System.Drawing.Size(300, 220);
			this.tblSaleDataGridView.TabIndex = 7;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderNo";
			this.dataGridViewTextBoxColumn1.HeaderText = "OrderNo";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Customer";
			this.dataGridViewTextBoxColumn2.HeaderText = "Customer";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Item";
			this.dataGridViewTextBoxColumn3.HeaderText = "Item";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "ODate";
			this.dataGridViewTextBoxColumn4.HeaderText = "ODate";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 295);
			this.Controls.Add(this.tblSaleDataGridView);
			this.Controls.Add(nameLabel);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(ageLabel);
			this.Controls.Add(this.ageTextBox);
			this.Controls.Add(maleLabel);
			this.Controls.Add(this.maleCheckBox);
			this.Controls.Add(this.tblPeopleBindingNavigator);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.aDOTestDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tblPeopleBindingNavigator)).EndInit();
			this.tblPeopleBindingNavigator.ResumeLayout(false);
			this.tblPeopleBindingNavigator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tblSaleBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tblSaleDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ADOTestDataSet aDOTestDataSet;
		private System.Windows.Forms.BindingSource tblPeopleBindingSource;
		private MasterDetail.ADOTestDataSetTableAdapters.tblPeopleTableAdapter tblPeopleTableAdapter;
		private MasterDetail.ADOTestDataSetTableAdapters.TableAdapterManager tableAdapterManager;
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
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.TextBox ageTextBox;
		private System.Windows.Forms.CheckBox maleCheckBox;
		private MasterDetail.ADOTestDataSetTableAdapters.tblSaleTableAdapter tblSaleTableAdapter;
		private System.Windows.Forms.BindingSource tblSaleBindingSource;
		private System.Windows.Forms.DataGridView tblSaleDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
	}
}

