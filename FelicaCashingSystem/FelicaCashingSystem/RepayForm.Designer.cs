namespace FelicaCashingSystem
{
    partial class RepayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepayForm));
            this.buttonRepayAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMoneySum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRepayPartial = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRepayAll
            // 
            this.buttonRepayAll.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRepayAll.Location = new System.Drawing.Point(15, 101);
            this.buttonRepayAll.Name = "buttonRepayAll";
            this.buttonRepayAll.Size = new System.Drawing.Size(113, 41);
            this.buttonRepayAll.TabIndex = 0;
            this.buttonRepayAll.Text = "全額返済";
            this.buttonRepayAll.UseVisualStyleBackColor = true;
            this.buttonRepayAll.Click += new System.EventHandler(this.buttonRepayAll_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "現在金額:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMoneySum
            // 
            this.labelMoneySum.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMoneySum.ForeColor = System.Drawing.Color.Red;
            this.labelMoneySum.Location = new System.Drawing.Point(125, 48);
            this.labelMoneySum.Name = "labelMoneySum";
            this.labelMoneySum.Size = new System.Drawing.Size(247, 23);
            this.labelMoneySum.TabIndex = 11;
            this.labelMoneySum.Text = "MoneySum";
            this.labelMoneySum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 39);
            this.label3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "返済方法を選択してください。";
            // 
            // buttonRepayPartial
            // 
            this.buttonRepayPartial.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRepayPartial.Location = new System.Drawing.Point(147, 101);
            this.buttonRepayPartial.Name = "buttonRepayPartial";
            this.buttonRepayPartial.Size = new System.Drawing.Size(113, 41);
            this.buttonRepayPartial.TabIndex = 15;
            this.buttonRepayPartial.Text = "部分返済";
            this.buttonRepayPartial.UseVisualStyleBackColor = true;
            this.buttonRepayPartial.Click += new System.EventHandler(this.buttonRepayPartial_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonCancel.Location = new System.Drawing.Point(278, 101);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(113, 41);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // RepayForm
            // 
            this.AcceptButton = this.buttonRepayAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 157);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRepayPartial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMoneySum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRepayAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RepayForm";
            this.Text = "返済";
            this.Load += new System.EventHandler(this.RepayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRepayAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMoneySum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRepayPartial;
        private System.Windows.Forms.Button buttonCancel;
    }
}