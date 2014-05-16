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
    public partial class BuyOrCashingForm : Form
    {
        private readonly int moneySumOld;
        private readonly int moneySumNew;
        private readonly int moneyAdd;
        
        public BuyOrCashingForm(int moneySumOld, int moneyAdd)
        {
            InitializeComponent();

            this.moneySumOld = moneySumOld;
            this.moneySumNew = moneySumOld - moneyAdd;
            this.moneyAdd    = moneyAdd;
        }

        private void CashingForm_Load(object sender, EventArgs e)
        {
            this.labelMoneySumOld.Text = this.moneySumOld.ToCommaString() + " 円";
            this.labelMoneySumNew.Text = this.moneySumNew.ToCommaString() + " 円";
            this.labelMoneyAdd.Text    = this.moneyAdd.ToCommaStringAbs() + " 円";

            this.labelMoneySumOld.ForeColor = this.moneySumOld.GetMoneyColor();
            this.labelMoneySumNew.ForeColor = this.moneySumNew.GetMoneyColor();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    }
}
