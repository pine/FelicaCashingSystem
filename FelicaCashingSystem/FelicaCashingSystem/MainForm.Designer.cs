namespace FelicaCashingSystem
{
    partial class MainForm
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
                this.notifyIcon.Visible = false;

                components.Dispose(); // 初期コード

                this.DisposeNonDesignerComponents(disposing);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelUid = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notify_icon_version = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notify_icon_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCashing110 = new System.Windows.Forms.Button();
            this.buttonUserList = new System.Windows.Forms.Button();
            this.buttonCashing = new System.Windows.Forms.Button();
            this.labelMoney = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLog = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonCharge = new System.Windows.Forms.Button();
            this.labelUidSub = new System.Windows.Forms.Label();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.アカウントAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemBackupConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonRepay = new System.Windows.Forms.Button();
            this.buttonChangeProfile = new System.Windows.Forms.Button();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.notifyIconMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUid
            // 
            this.labelUid.AutoSize = true;
            this.labelUid.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUid.Location = new System.Drawing.Point(12, 603);
            this.labelUid.Name = "labelUid";
            this.labelUid.Size = new System.Drawing.Size(24, 12);
            this.labelUid.TabIndex = 0;
            this.labelUid.Text = "UID";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Felica Cashing System";
            this.notifyIcon.Visible = true;
            // 
            // notifyIconMenu
            // 
            this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notify_icon_version,
            this.toolStripMenuItem1,
            this.notify_icon_exit});
            this.notifyIconMenu.Name = "notify_icon_menu";
            this.notifyIconMenu.Size = new System.Drawing.Size(161, 70);
            // 
            // notify_icon_version
            // 
            this.notify_icon_version.Name = "notify_icon_version";
            this.notify_icon_version.Size = new System.Drawing.Size(160, 22);
            this.notify_icon_version.Text = "バージョン情報";
            this.notify_icon_version.Click += new System.EventHandler(this.notify_icon_version_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "更新履歴";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // notify_icon_exit
            // 
            this.notify_icon_exit.Name = "notify_icon_exit";
            this.notify_icon_exit.Size = new System.Drawing.Size(160, 22);
            this.notify_icon_exit.Text = "終了";
            this.notify_icon_exit.Click += new System.EventHandler(this.notify_icon_exit_Click);
            // 
            // buttonCashing110
            // 
            this.buttonCashing110.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCashing110.Location = new System.Drawing.Point(16, 23);
            this.buttonCashing110.Name = "buttonCashing110";
            this.buttonCashing110.Size = new System.Drawing.Size(140, 98);
            this.buttonCashing110.TabIndex = 2;
            this.buttonCashing110.Text = "110円\r\n (Enter)";
            this.buttonCashing110.UseVisualStyleBackColor = true;
            this.buttonCashing110.Click += new System.EventHandler(this.button110Yen_Click);
            // 
            // buttonUserList
            // 
            this.buttonUserList.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUserList.Location = new System.Drawing.Point(20, 25);
            this.buttonUserList.Name = "buttonUserList";
            this.buttonUserList.Size = new System.Drawing.Size(154, 49);
            this.buttonUserList.TabIndex = 3;
            this.buttonUserList.Text = "ユーザ一覧 (&L)";
            this.buttonUserList.UseVisualStyleBackColor = true;
            this.buttonUserList.Click += new System.EventHandler(this.buttonUserList_Click);
            // 
            // buttonCashing
            // 
            this.buttonCashing.Enabled = false;
            this.buttonCashing.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCashing.Location = new System.Drawing.Point(181, 23);
            this.buttonCashing.Name = "buttonCashing";
            this.buttonCashing.Size = new System.Drawing.Size(136, 98);
            this.buttonCashing.TabIndex = 5;
            this.buttonCashing.Text = "その他 (&0)";
            this.buttonCashing.UseVisualStyleBackColor = true;
            this.buttonCashing.Click += new System.EventHandler(this.buttonCashing_Click);
            // 
            // labelMoney
            // 
            this.labelMoney.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMoney.Location = new System.Drawing.Point(371, 48);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(138, 20);
            this.labelMoney.TabIndex = 7;
            this.labelMoney.Text = "labelMoney";
            this.labelMoney.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(284, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "現在金額:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(281, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 36);
            this.label2.TabIndex = 9;
            // 
            // buttonLog
            // 
            this.buttonLog.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonLog.Location = new System.Drawing.Point(189, 82);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(154, 49);
            this.buttonLog.TabIndex = 10;
            this.buttonLog.Text = "ログ";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonClose.Location = new System.Drawing.Point(421, 475);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(178, 125);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "閉じる";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(23, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "名前:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUserName
            // 
            this.labelUserName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUserName.Location = new System.Drawing.Point(80, 48);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(168, 20);
            this.labelUserName.TabIndex = 12;
            this.labelUserName.Text = "labelUserName";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(20, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 36);
            this.label5.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCashing110);
            this.groupBox1.Controls.Add(this.buttonCashing);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(26, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 145);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "購入・借用";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCharge);
            this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(405, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 138);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "返済・チャージ";
            // 
            // buttonCharge
            // 
            this.buttonCharge.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCharge.Location = new System.Drawing.Point(16, 25);
            this.buttonCharge.Name = "buttonCharge";
            this.buttonCharge.Size = new System.Drawing.Size(161, 98);
            this.buttonCharge.TabIndex = 5;
            this.buttonCharge.Text = "チャージ";
            this.buttonCharge.UseVisualStyleBackColor = true;
            this.buttonCharge.Click += new System.EventHandler(this.buttonCharge_Click);
            // 
            // labelUidSub
            // 
            this.labelUidSub.AutoSize = true;
            this.labelUidSub.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUidSub.Location = new System.Drawing.Point(12, 588);
            this.labelUidSub.Name = "labelUidSub";
            this.labelUidSub.Size = new System.Drawing.Size(24, 12);
            this.labelUidSub.TabIndex = 18;
            this.labelUidSub.Text = "UID";
            this.labelUidSub.Visible = false;
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStatistics.Location = new System.Drawing.Point(189, 25);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(154, 49);
            this.buttonStatistics.TabIndex = 19;
            this.buttonStatistics.Text = "統計";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.アカウントAToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ヘルプToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(635, 26);
            this.menuStrip.TabIndex = 20;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClose});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.ファイルToolStripMenuItem.Text = "ファイル (&F)";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(134, 22);
            this.menuItemClose.Text = "閉じる (&X)";
            this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // アカウントAToolStripMenuItem
            // 
            this.アカウントAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemChangeName});
            this.アカウントAToolStripMenuItem.Name = "アカウントAToolStripMenuItem";
            this.アカウントAToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.アカウントAToolStripMenuItem.Text = "アカウント (&A)";
            // 
            // menuItemChangeName
            // 
            this.menuItemChangeName.Name = "menuItemChangeName";
            this.menuItemChangeName.Size = new System.Drawing.Size(124, 22);
            this.menuItemChangeName.Text = "名前変更";
            this.menuItemChangeName.Click += new System.EventHandler(this.menuItemChangeName_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemBackupConfig});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(78, 22);
            this.toolStripMenuItem2.Text = "ツール (&T)";
            // 
            // ToolStripMenuItemBackupConfig
            // 
            this.ToolStripMenuItemBackupConfig.Enabled = false;
            this.ToolStripMenuItemBackupConfig.Name = "ToolStripMenuItemBackupConfig";
            this.ToolStripMenuItemBackupConfig.Size = new System.Drawing.Size(194, 22);
            this.ToolStripMenuItemBackupConfig.Text = "バックアップ設定 (&B)";
            this.ToolStripMenuItemBackupConfig.Click += new System.EventHandler(this.ToolStripMenuItemBackupConfig_Click);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUpdate,
            this.menuItemVersion});
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(79, 22);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ (&H)";
            // 
            // menuItemUpdate
            // 
            this.menuItemUpdate.Name = "menuItemUpdate";
            this.menuItemUpdate.Size = new System.Drawing.Size(182, 22);
            this.menuItemUpdate.Text = "更新情報 (&U)";
            this.menuItemUpdate.Click += new System.EventHandler(this.menuItemUpdate_Click);
            // 
            // menuItemVersion
            // 
            this.menuItemVersion.Name = "menuItemVersion";
            this.menuItemVersion.Size = new System.Drawing.Size(182, 22);
            this.menuItemVersion.Text = "バージョン情報 (&V)";
            this.menuItemVersion.Click += new System.EventHandler(this.menuItemVersion_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonRepay);
            this.groupBox3.Controls.Add(this.buttonLog);
            this.groupBox3.Controls.Add(this.buttonStatistics);
            this.groupBox3.Controls.Add(this.buttonChangeProfile);
            this.groupBox3.Controls.Add(this.buttonUserList);
            this.groupBox3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(256, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 210);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "その他";
            // 
            // buttonRepay
            // 
            this.buttonRepay.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRepay.Location = new System.Drawing.Point(20, 137);
            this.buttonRepay.Name = "buttonRepay";
            this.buttonRepay.Size = new System.Drawing.Size(154, 49);
            this.buttonRepay.TabIndex = 20;
            this.buttonRepay.Text = "返済 (&R)";
            this.buttonRepay.UseVisualStyleBackColor = true;
            this.buttonRepay.Click += new System.EventHandler(this.buttonRepay_Click_1);
            // 
            // buttonChangeProfile
            // 
            this.buttonChangeProfile.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonChangeProfile.Location = new System.Drawing.Point(20, 82);
            this.buttonChangeProfile.Name = "buttonChangeProfile";
            this.buttonChangeProfile.Size = new System.Drawing.Size(154, 49);
            this.buttonChangeProfile.TabIndex = 3;
            this.buttonChangeProfile.Text = "プロフィール変更";
            this.buttonChangeProfile.UseVisualStyleBackColor = true;
            this.buttonChangeProfile.Click += new System.EventHandler(this.buttonChangeProfile_Click);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
            this.pictureBoxIcon.Location = new System.Drawing.Point(59, 432);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(140, 141);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 22;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.Click += new System.EventHandler(this.pictureBoxIcon_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonPrint);
            this.groupBox4.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(26, 259);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 147);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "門限超過";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPrint.Location = new System.Drawing.Point(16, 25);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(161, 98);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "印刷 (&P)";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonCashing110;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(635, 624);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelUidSub);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelUid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "Felica Cashing System";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.notifyIconMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUid;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem notify_icon_exit;
        private System.Windows.Forms.Button buttonCashing110;
        private System.Windows.Forms.Button buttonUserList;
        private System.Windows.Forms.Button buttonCashing;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem notify_icon_version;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCharge;
        private System.Windows.Forms.Label labelUidSub;
        private System.Windows.Forms.Button buttonStatistics;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuItemVersion;
        private System.Windows.Forms.ToolStripMenuItem アカウントAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemBackupConfig;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Button buttonChangeProfile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonRepay;
    }
}

