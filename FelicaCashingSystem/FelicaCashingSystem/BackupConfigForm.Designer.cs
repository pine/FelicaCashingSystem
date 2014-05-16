namespace FelicaCashingSystem
{
    partial class BackupConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupConfigForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBackupInterval = new System.Windows.Forms.TextBox();
            this.textBoxBackupFolderPath = new System.Windows.Forms.TextBox();
            this.buttonSelectBackupFolderPath = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "バックアップ間隔 (分)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "バックアップ先フォルダ";
            // 
            // textBoxBackupInterval
            // 
            this.textBoxBackupInterval.Location = new System.Drawing.Point(145, 21);
            this.textBoxBackupInterval.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBackupInterval.Name = "textBoxBackupInterval";
            this.textBoxBackupInterval.Size = new System.Drawing.Size(72, 19);
            this.textBoxBackupInterval.TabIndex = 2;
            // 
            // textBoxBackupFolderPath
            // 
            this.textBoxBackupFolderPath.Location = new System.Drawing.Point(145, 56);
            this.textBoxBackupFolderPath.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBackupFolderPath.Name = "textBoxBackupFolderPath";
            this.textBoxBackupFolderPath.Size = new System.Drawing.Size(252, 19);
            this.textBoxBackupFolderPath.TabIndex = 3;
            // 
            // buttonSelectBackupFolderPath
            // 
            this.buttonSelectBackupFolderPath.Location = new System.Drawing.Point(401, 54);
            this.buttonSelectBackupFolderPath.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectBackupFolderPath.Name = "buttonSelectBackupFolderPath";
            this.buttonSelectBackupFolderPath.Size = new System.Drawing.Size(45, 23);
            this.buttonSelectBackupFolderPath.TabIndex = 4;
            this.buttonSelectBackupFolderPath.Text = "選択";
            this.buttonSelectBackupFolderPath.UseVisualStyleBackColor = true;
            this.buttonSelectBackupFolderPath.Click += new System.EventHandler(this.buttonSelectBackupFolderPath_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(258, 116);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(87, 21);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(349, 117);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 20);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // BackupConfigForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(466, 153);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonSelectBackupFolderPath);
            this.Controls.Add(this.textBoxBackupFolderPath);
            this.Controls.Add(this.textBoxBackupInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BackupConfigForm";
            this.Text = "バックアップ設定";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BackupConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.BackupConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBackupInterval;
        private System.Windows.Forms.TextBox textBoxBackupFolderPath;
        private System.Windows.Forms.Button buttonSelectBackupFolderPath;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}