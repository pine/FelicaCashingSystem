using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FelicaCashingSystem
{
    public partial class SelectCashingMoneyForm : Form
    {
        public int Money { get; private set; }

        public SelectCashingMoneyForm()
        {
            InitializeComponent();

            this.Money = 0;

            this.AddButton(this);
        }

        private void AddButton(Control parent)
        {
            foreach (var control in parent.Controls)
            {
                if ((control as Button) != null && control != this.buttonCancel)
                {
                    ((Button)control).Click += new EventHandler(this.MoneyButton_Clicked);
                }

                if ((control as GroupBox) != null)
                {
                    this.AddButton((GroupBox)control);
                }
            }
        }

        // ボタンの Text を見て、値を求める (XX円)
        private void MoneyButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
               int money = button.ToInt();

               if (money > 0)
               {
                   this.Money = money;
                   this.Close();
               }
            }        
        }
    }
}
