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
    public partial class AssociationCheckForm : Form
    {
        private readonly int moneySum;
        private readonly string userName;

        public AssociationCheckForm(int moneySum, string userName)
        {
            InitializeComponent();

            this.moneySum = moneySum;
            this.userName = userName;
        }

        private void AssociationCheckForm_Load(object sender, EventArgs e)
        {
            this.labelMoneySum.Text = this.moneySum.ToCommaString() + "円";
            this.labelUserName.Text = this.userName;
            this.labelMoneySum.ForeColor = this.moneySum.GetMoneyColor();
        }
    }
}
