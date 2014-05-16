namespace RobotClub.DormitoryReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axAcroPDF = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelReturnDateEnd = new System.Windows.Forms.Panel();
            this.textBoxReturnDateEndMinutes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxReturnDateEndMonth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReturnDateEndDate = new System.Windows.Forms.TextBox();
            this.textBoxReturnDateEndHour = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxPrintDialog = new System.Windows.Forms.CheckBox();
            this.checkBoxReturnDateEndOther = new System.Windows.Forms.CheckBox();
            this.checkBoxReturnDateEndTomorrow = new System.Windows.Forms.CheckBox();
            this.checkBoxReturnDateEndToday = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxReturnDateBeginToday = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDate = new System.Windows.Forms.CheckBox();
            this.textBoxRoomNo = new System.Windows.Forms.TextBox();
            this.checkBoxRoomNo = new System.Windows.Forms.CheckBox();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.checkBoxReason = new System.Windows.Forms.CheckBox();
            this.textBoxLeaderPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxLeaderName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.checkBoxPhoneNumber = new System.Windows.Forms.CheckBox();
            this.checkBoxLeaderPhoneNumber = new System.Windows.Forms.CheckBox();
            this.checkBoxLeaderName = new System.Windows.Forms.CheckBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelReturnDateEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // axAcroPDF
            // 
            this.axAcroPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axAcroPDF.Enabled = true;
            this.axAcroPDF.Location = new System.Drawing.Point(12, 162);
            this.axAcroPDF.Name = "axAcroPDF";
            this.axAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF.OcxState")));
            this.axAcroPDF.Size = new System.Drawing.Size(748, 497);
            this.axAcroPDF.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panelReturnDateEnd);
            this.panel1.Controls.Add(this.checkBoxPrintDialog);
            this.panel1.Controls.Add(this.checkBoxReturnDateEndOther);
            this.panel1.Controls.Add(this.checkBoxReturnDateEndTomorrow);
            this.panel1.Controls.Add(this.checkBoxReturnDateEndToday);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBoxReturnDateBeginToday);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxDate);
            this.panel1.Controls.Add(this.textBoxRoomNo);
            this.panel1.Controls.Add(this.checkBoxRoomNo);
            this.panel1.Controls.Add(this.textBoxReason);
            this.panel1.Controls.Add(this.checkBoxReason);
            this.panel1.Controls.Add(this.textBoxLeaderPhoneNumber);
            this.panel1.Controls.Add(this.textBoxPhoneNumber);
            this.panel1.Controls.Add(this.textBoxLeaderName);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.checkBoxPhoneNumber);
            this.panel1.Controls.Add(this.checkBoxLeaderPhoneNumber);
            this.panel1.Controls.Add(this.checkBoxLeaderName);
            this.panel1.Controls.Add(this.checkBoxName);
            this.panel1.Controls.Add(this.buttonUpdate);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonPrint);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 135);
            this.panel1.TabIndex = 1;
            // 
            // panelReturnDateEnd
            // 
            this.panelReturnDateEnd.Controls.Add(this.textBoxReturnDateEndMinutes);
            this.panelReturnDateEnd.Controls.Add(this.label6);
            this.panelReturnDateEnd.Controls.Add(this.textBoxReturnDateEndMonth);
            this.panelReturnDateEnd.Controls.Add(this.label3);
            this.panelReturnDateEnd.Controls.Add(this.label5);
            this.panelReturnDateEnd.Controls.Add(this.textBoxReturnDateEndDate);
            this.panelReturnDateEnd.Controls.Add(this.textBoxReturnDateEndHour);
            this.panelReturnDateEnd.Controls.Add(this.label4);
            this.panelReturnDateEnd.Location = new System.Drawing.Point(326, 97);
            this.panelReturnDateEnd.Name = "panelReturnDateEnd";
            this.panelReturnDateEnd.Size = new System.Drawing.Size(234, 25);
            this.panelReturnDateEnd.TabIndex = 32;
            // 
            // textBoxReturnDateEndMinutes
            // 
            this.textBoxReturnDateEndMinutes.Location = new System.Drawing.Point(174, 5);
            this.textBoxReturnDateEndMinutes.Name = "textBoxReturnDateEndMinutes";
            this.textBoxReturnDateEndMinutes.Size = new System.Drawing.Size(31, 19);
            this.textBoxReturnDateEndMinutes.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "分";
            // 
            // textBoxReturnDateEndMonth
            // 
            this.textBoxReturnDateEndMonth.Location = new System.Drawing.Point(2, 5);
            this.textBoxReturnDateEndMonth.Name = "textBoxReturnDateEndMonth";
            this.textBoxReturnDateEndMonth.Size = new System.Drawing.Size(31, 19);
            this.textBoxReturnDateEndMonth.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "月";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "時";
            // 
            // textBoxReturnDateEndDate
            // 
            this.textBoxReturnDateEndDate.Location = new System.Drawing.Point(60, 5);
            this.textBoxReturnDateEndDate.Name = "textBoxReturnDateEndDate";
            this.textBoxReturnDateEndDate.Size = new System.Drawing.Size(31, 19);
            this.textBoxReturnDateEndDate.TabIndex = 26;
            // 
            // textBoxReturnDateEndHour
            // 
            this.textBoxReturnDateEndHour.Location = new System.Drawing.Point(118, 5);
            this.textBoxReturnDateEndHour.Name = "textBoxReturnDateEndHour";
            this.textBoxReturnDateEndHour.Size = new System.Drawing.Size(31, 19);
            this.textBoxReturnDateEndHour.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "日";
            // 
            // checkBoxPrintDialog
            // 
            this.checkBoxPrintDialog.AutoSize = true;
            this.checkBoxPrintDialog.Location = new System.Drawing.Point(651, 70);
            this.checkBoxPrintDialog.Name = "checkBoxPrintDialog";
            this.checkBoxPrintDialog.Size = new System.Drawing.Size(93, 16);
            this.checkBoxPrintDialog.TabIndex = 23;
            this.checkBoxPrintDialog.Text = "印刷ダイアログ";
            this.checkBoxPrintDialog.UseVisualStyleBackColor = true;
            // 
            // checkBoxReturnDateEndOther
            // 
            this.checkBoxReturnDateEndOther.AutoSize = true;
            this.checkBoxReturnDateEndOther.Location = new System.Drawing.Point(265, 104);
            this.checkBoxReturnDateEndOther.Name = "checkBoxReturnDateEndOther";
            this.checkBoxReturnDateEndOther.Size = new System.Drawing.Size(55, 16);
            this.checkBoxReturnDateEndOther.TabIndex = 22;
            this.checkBoxReturnDateEndOther.Text = "その他";
            this.checkBoxReturnDateEndOther.UseVisualStyleBackColor = true;
            this.checkBoxReturnDateEndOther.CheckedChanged += new System.EventHandler(this.checkBoxReturnDateEnd_CheckedChanged);
            // 
            // checkBoxReturnDateEndTomorrow
            // 
            this.checkBoxReturnDateEndTomorrow.AutoSize = true;
            this.checkBoxReturnDateEndTomorrow.Checked = true;
            this.checkBoxReturnDateEndTomorrow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReturnDateEndTomorrow.Location = new System.Drawing.Point(211, 104);
            this.checkBoxReturnDateEndTomorrow.Name = "checkBoxReturnDateEndTomorrow";
            this.checkBoxReturnDateEndTomorrow.Size = new System.Drawing.Size(48, 16);
            this.checkBoxReturnDateEndTomorrow.TabIndex = 21;
            this.checkBoxReturnDateEndTomorrow.Text = "明日";
            this.checkBoxReturnDateEndTomorrow.UseVisualStyleBackColor = true;
            this.checkBoxReturnDateEndTomorrow.CheckedChanged += new System.EventHandler(this.checkBoxReturnDateEnd_CheckedChanged);
            // 
            // checkBoxReturnDateEndToday
            // 
            this.checkBoxReturnDateEndToday.AutoSize = true;
            this.checkBoxReturnDateEndToday.Location = new System.Drawing.Point(156, 104);
            this.checkBoxReturnDateEndToday.Name = "checkBoxReturnDateEndToday";
            this.checkBoxReturnDateEndToday.Size = new System.Drawing.Size(48, 16);
            this.checkBoxReturnDateEndToday.TabIndex = 20;
            this.checkBoxReturnDateEndToday.Text = "本日";
            this.checkBoxReturnDateEndToday.UseVisualStyleBackColor = true;
            this.checkBoxReturnDateEndToday.CheckedChanged += new System.EventHandler(this.checkBoxReturnDateEnd_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "から";
            // 
            // checkBoxReturnDateBeginToday
            // 
            this.checkBoxReturnDateBeginToday.AutoSize = true;
            this.checkBoxReturnDateBeginToday.Checked = true;
            this.checkBoxReturnDateBeginToday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReturnDateBeginToday.Location = new System.Drawing.Point(76, 104);
            this.checkBoxReturnDateBeginToday.Name = "checkBoxReturnDateBeginToday";
            this.checkBoxReturnDateBeginToday.Size = new System.Drawing.Size(48, 16);
            this.checkBoxReturnDateBeginToday.TabIndex = 18;
            this.checkBoxReturnDateBeginToday.Text = "本日";
            this.checkBoxReturnDateBeginToday.UseVisualStyleBackColor = true;
            this.checkBoxReturnDateBeginToday.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "帰寮日時";
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Checked = true;
            this.checkBoxDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDate.Location = new System.Drawing.Point(637, 6);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(48, 16);
            this.checkBoxDate.TabIndex = 16;
            this.checkBoxDate.Text = "日付";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            this.checkBoxDate.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBoxRoomNo
            // 
            this.textBoxRoomNo.Location = new System.Drawing.Point(270, 3);
            this.textBoxRoomNo.Name = "textBoxRoomNo";
            this.textBoxRoomNo.ReadOnly = true;
            this.textBoxRoomNo.Size = new System.Drawing.Size(76, 19);
            this.textBoxRoomNo.TabIndex = 15;
            // 
            // checkBoxRoomNo
            // 
            this.checkBoxRoomNo.AutoSize = true;
            this.checkBoxRoomNo.Checked = true;
            this.checkBoxRoomNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRoomNo.Location = new System.Drawing.Point(194, 5);
            this.checkBoxRoomNo.Name = "checkBoxRoomNo";
            this.checkBoxRoomNo.Size = new System.Drawing.Size(72, 16);
            this.checkBoxRoomNo.TabIndex = 14;
            this.checkBoxRoomNo.Text = "部屋番号";
            this.checkBoxRoomNo.UseVisualStyleBackColor = true;
            this.checkBoxRoomNo.CheckStateChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBoxReason
            // 
            this.textBoxReason.Location = new System.Drawing.Point(57, 68);
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(395, 19);
            this.textBoxReason.TabIndex = 13;
            // 
            // checkBoxReason
            // 
            this.checkBoxReason.AutoSize = true;
            this.checkBoxReason.Checked = true;
            this.checkBoxReason.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReason.Location = new System.Drawing.Point(3, 70);
            this.checkBoxReason.Name = "checkBoxReason";
            this.checkBoxReason.Size = new System.Drawing.Size(48, 16);
            this.checkBoxReason.TabIndex = 12;
            this.checkBoxReason.Text = "理由";
            this.checkBoxReason.UseVisualStyleBackColor = true;
            this.checkBoxReason.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBoxLeaderPhoneNumber
            // 
            this.textBoxLeaderPhoneNumber.Location = new System.Drawing.Point(336, 34);
            this.textBoxLeaderPhoneNumber.Name = "textBoxLeaderPhoneNumber";
            this.textBoxLeaderPhoneNumber.ReadOnly = true;
            this.textBoxLeaderPhoneNumber.Size = new System.Drawing.Size(116, 19);
            this.textBoxLeaderPhoneNumber.TabIndex = 11;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(452, 3);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.ReadOnly = true;
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(146, 19);
            this.textBoxPhoneNumber.TabIndex = 10;
            // 
            // textBoxLeaderName
            // 
            this.textBoxLeaderName.Location = new System.Drawing.Point(82, 34);
            this.textBoxLeaderName.Name = "textBoxLeaderName";
            this.textBoxLeaderName.ReadOnly = true;
            this.textBoxLeaderName.Size = new System.Drawing.Size(102, 19);
            this.textBoxLeaderName.TabIndex = 10;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(58, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(102, 19);
            this.textBoxName.TabIndex = 9;
            // 
            // checkBoxPhoneNumber
            // 
            this.checkBoxPhoneNumber.AutoSize = true;
            this.checkBoxPhoneNumber.Checked = true;
            this.checkBoxPhoneNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPhoneNumber.Location = new System.Drawing.Point(382, 5);
            this.checkBoxPhoneNumber.Name = "checkBoxPhoneNumber";
            this.checkBoxPhoneNumber.Size = new System.Drawing.Size(60, 16);
            this.checkBoxPhoneNumber.TabIndex = 5;
            this.checkBoxPhoneNumber.Text = "連絡先";
            this.checkBoxPhoneNumber.UseVisualStyleBackColor = true;
            this.checkBoxPhoneNumber.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxLeaderPhoneNumber
            // 
            this.checkBoxLeaderPhoneNumber.AutoSize = true;
            this.checkBoxLeaderPhoneNumber.Checked = true;
            this.checkBoxLeaderPhoneNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLeaderPhoneNumber.Location = new System.Drawing.Point(228, 37);
            this.checkBoxLeaderPhoneNumber.Name = "checkBoxLeaderPhoneNumber";
            this.checkBoxLeaderPhoneNumber.Size = new System.Drawing.Size(96, 16);
            this.checkBoxLeaderPhoneNumber.TabIndex = 7;
            this.checkBoxLeaderPhoneNumber.Text = "代表者連絡先";
            this.checkBoxLeaderPhoneNumber.UseVisualStyleBackColor = true;
            this.checkBoxLeaderPhoneNumber.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxLeaderName
            // 
            this.checkBoxLeaderName.AutoSize = true;
            this.checkBoxLeaderName.Checked = true;
            this.checkBoxLeaderName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLeaderName.Location = new System.Drawing.Point(2, 36);
            this.checkBoxLeaderName.Name = "checkBoxLeaderName";
            this.checkBoxLeaderName.Size = new System.Drawing.Size(72, 16);
            this.checkBoxLeaderName.TabIndex = 5;
            this.checkBoxLeaderName.Text = "代表者名";
            this.checkBoxLeaderName.UseVisualStyleBackColor = true;
            this.checkBoxLeaderName.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxName
            // 
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Checked = true;
            this.checkBoxName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxName.Location = new System.Drawing.Point(3, 7);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(48, 16);
            this.checkBoxName.TabIndex = 3;
            this.checkBoxName.Text = "名前";
            this.checkBoxName.UseVisualStyleBackColor = true;
            this.checkBoxName.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Location = new System.Drawing.Point(566, 77);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(68, 26);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "更新 (&U)";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(566, 109);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(70, 26);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "保存 (&S)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.Location = new System.Drawing.Point(649, 101);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(99, 34);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "印刷 (&P)";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 671);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axAcroPDF);
            this.Name = "MainForm";
            this.Text = "ドミトリー 門限超過届 発行システム";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelReturnDateEnd.ResumeLayout(false);
            this.panelReturnDateEnd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.CheckBox checkBoxLeaderName;
        private System.Windows.Forms.CheckBox checkBoxLeaderPhoneNumber;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLeaderName;
        private System.Windows.Forms.TextBox textBoxLeaderPhoneNumber;
        private System.Windows.Forms.CheckBox checkBoxReason;
        private System.Windows.Forms.TextBox textBoxRoomNo;
        private System.Windows.Forms.CheckBox checkBoxRoomNo;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.CheckBox checkBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxReason;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.CheckBox checkBoxDate;
        private System.Windows.Forms.CheckBox checkBoxPrintDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxReturnDateBeginToday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxReturnDateEndMonth;
        private System.Windows.Forms.CheckBox checkBoxReturnDateEndOther;
        private System.Windows.Forms.CheckBox checkBoxReturnDateEndTomorrow;
        private System.Windows.Forms.CheckBox checkBoxReturnDateEndToday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxReturnDateEndMinutes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxReturnDateEndHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxReturnDateEndDate;
        private System.Windows.Forms.Panel panelReturnDateEnd;

    }
}

