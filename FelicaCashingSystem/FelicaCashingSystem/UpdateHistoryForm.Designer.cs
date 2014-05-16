namespace FelicaCashingSystem
{
    partial class UpdateHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateHistoryForm));
            this.textBoxUpdateHistory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxUpdateHistory
            // 
            this.textBoxUpdateHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUpdateHistory.Location = new System.Drawing.Point(0, 0);
            this.textBoxUpdateHistory.Multiline = true;
            this.textBoxUpdateHistory.Name = "textBoxUpdateHistory";
            this.textBoxUpdateHistory.ReadOnly = true;
            this.textBoxUpdateHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxUpdateHistory.Size = new System.Drawing.Size(448, 416);
            this.textBoxUpdateHistory.TabIndex = 0;
            // 
            // UpdateHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 416);
            this.Controls.Add(this.textBoxUpdateHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateHistoryForm";
            this.Text = "更新履歴";
            this.Load += new System.EventHandler(this.UpdateHistoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUpdateHistory;
    }
}