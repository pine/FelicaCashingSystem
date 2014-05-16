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
    public partial class RepayForm : Form
    {
        public int Money { get; private set; }
        public bool RepayPartial { get; private set; }

        public RepayForm(int money)
        {
            InitializeComponent();

            this.Money = money;
            this.RepayPartial = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RepayForm_Load(object sender, EventArgs e)
        {
            this.labelMoneySum.Text = this.Money.ToCommaString() + "円";
        }

        private void buttonRepayAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "本当に、「 " + this.Money.ToCommaStringAbs() + " 」円返済しますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
                );

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void buttonRepayPartial_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.RepayPartial = true;
            this.Close();
        }
    }
}
