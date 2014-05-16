using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FelicaCashingSystem
{
    public partial class LogForm : Form
    {
        public LogForm(List<Log> log)
        {
            InitializeComponent();

            // データソースを設定
            //log.Reverse();
            this.dataGridViewLog.DataSource = log;

            // ヘッダーを日本語に書き換える
            var headers = new Dictionary<string, string>(3);

            headers["Name"]    = "名前";
            headers["Action"]  = "操作";
            headers["Content"] = "引数";
            headers["Date"]    = "日時";
            headers["Uid"]     = "UID";

            for (int i = 0; i < this.dataGridViewLog.ColumnCount; ++i)
            {
                var column = this.dataGridViewLog.Columns[i];

                if (headers.ContainsKey(column.HeaderText))
                {
                    column.HeaderText = headers[column.HeaderText];
                }
            }
        }

        // すべてのキー入力を受け取るために、Form の KeyPreview プロパティを true にしておくこと
        private void LogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true; // 子コントロールへ制御を渡さない
                this.Close();
            }
        }
    }
}
