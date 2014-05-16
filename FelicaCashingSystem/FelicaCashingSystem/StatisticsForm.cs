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
    public partial class StatisticsForm : Form
    {
        private readonly DataTable[] cashingMonth;

        public StatisticsForm(DataTable[] cashing_month)
        {
            InitializeComponent();

            this.cashingMonth = cashing_month;

            foreach (var month in cashing_month)
            {
                var min = month.Compute("Min(月)", null);
                var max = month.Compute("Max(月)", null);

                this.comboBoxDate.Items.Add(min + " ～ " + max);
            }

            if (cashing_month.Length > 0)
            {
                // 最も最近の値を表示
                int lastIndex = cashing_month.Length - 1;
                this.comboBoxDate.SelectedIndex = lastIndex;
                this.chart1.DataSource = cashing_month[lastIndex];
            }
        }

        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.comboBoxDate.SelectedIndex;

            if (index >= 0 && index < this.comboBoxDate.Items.Count)
            {
                this.chart1.DataSource = this.cashingMonth[index];
                this.chart1.Invalidate(); // 再描写する (これがないと反映されない)
            }
        }

        private void StatisticsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true; // 子コントロールへ制御を渡さない
                this.Close();
            }
        }
    }
}
