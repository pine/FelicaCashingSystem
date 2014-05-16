using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FelicaCashingSystem
{
    public partial class UpdateHistoryForm : Form
    {
        public UpdateHistoryForm(string filename)
        {
            InitializeComponent();

            try
            {
                this.textBoxUpdateHistory.Text = File.ReadAllText(filename);
            }

            catch (IOException)
            {
                MessageBox.Show(
                    "更新履歴の取得に失敗しました。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );

                this.Opacity = 0;
            }
        }

        private void UpdateHistoryForm_Load(object sender, EventArgs e)
        {
            // 更新履歴が取得できない場合は、フォームを閉じる
            if (this.Opacity == 0)
            {
                this.Close();
            }

            // 初期全選択を解除する
            this.textBoxUpdateHistory.SelectionStart =
                this.textBoxUpdateHistory.SelectionLength;
        }
    }
}
