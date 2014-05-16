namespace FelicaCashingSystem
{
    partial class UserListForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserListForm));
            this.dataGridViewList = new System.Windows.Forms.DataGridView();
            this.contextMenuStripList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemClubDues = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClubDues2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRepayRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMoneyAllSum = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).BeginInit();
            this.contextMenuStripList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewList
            // 
            this.dataGridViewList.AllowUserToAddRows = false;
            this.dataGridViewList.AllowUserToDeleteRows = false;
            this.dataGridViewList.AllowUserToOrderColumns = true;
            this.dataGridViewList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewList.ContextMenuStrip = this.contextMenuStripList;
            this.dataGridViewList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewList.MultiSelect = false;
            this.dataGridViewList.Name = "dataGridViewList";
            this.dataGridViewList.ReadOnly = true;
            this.dataGridViewList.RowHeadersVisible = false;
            this.dataGridViewList.RowTemplate.Height = 21;
            this.dataGridViewList.Size = new System.Drawing.Size(571, 546);
            this.dataGridViewList.TabIndex = 0;
            this.dataGridViewList.DataSourceChanged += new System.EventHandler(this.dataGridViewList_DataSourceChanged);
            this.dataGridViewList.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridViewList_CellContextMenuStripNeeded);
            this.dataGridViewList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewList_CellFormatting);
            // 
            // contextMenuStripList
            // 
            this.contextMenuStripList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClubDues,
            this.menuItemClubDues2,
            this.menuItemRepayRequest});
            this.contextMenuStripList.Name = "contextMenuStripList";
            this.contextMenuStripList.Size = new System.Drawing.Size(179, 70);
            // 
            // menuItemClubDues
            // 
            this.menuItemClubDues.Name = "menuItemClubDues";
            this.menuItemClubDues.Size = new System.Drawing.Size(178, 22);
            this.menuItemClubDues.Text = "部費徴収 (1000円)";
            this.menuItemClubDues.Click += new System.EventHandler(this.menuItemClubDues_Click);
            // 
            // menuItemClubDues2
            // 
            this.menuItemClubDues2.Name = "menuItemClubDues2";
            this.menuItemClubDues2.Size = new System.Drawing.Size(178, 22);
            this.menuItemClubDues2.Text = "部費徴収 (2000円)";
            this.menuItemClubDues2.Click += new System.EventHandler(this.menuItemClubDues2_Click);
            // 
            // menuItemRepayRequest
            // 
            this.menuItemRepayRequest.Name = "menuItemRepayRequest";
            this.menuItemRepayRequest.Size = new System.Drawing.Size(178, 22);
            this.menuItemRepayRequest.Text = "支払い要求";
            this.menuItemRepayRequest.Click += new System.EventHandler(this.menuItemRepayRequest_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(430, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(125, 41);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "閉じる";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "全合計金額:";
            // 
            // labelMoneyAllSum
            // 
            this.labelMoneyAllSum.AutoSize = true;
            this.labelMoneyAllSum.Location = new System.Drawing.Point(121, 20);
            this.labelMoneyAllSum.Name = "labelMoneyAllSum";
            this.labelMoneyAllSum.Size = new System.Drawing.Size(29, 12);
            this.labelMoneyAllSum.TabIndex = 3;
            this.labelMoneyAllSum.Text = "金額";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMoneyAllSum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 546);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 59);
            this.panel1.TabIndex = 4;
            // 
            // UserListForm
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(571, 605);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserListForm";
            this.Text = "ユーザー一覧";
            this.Load += new System.EventHandler(this.UserListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).EndInit();
            this.contextMenuStripList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripList;
        private System.Windows.Forms.ToolStripMenuItem menuItemClubDues;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMoneyAllSum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem menuItemRepayRequest;
        private System.Windows.Forms.ToolStripMenuItem menuItemClubDues2;
    }
}