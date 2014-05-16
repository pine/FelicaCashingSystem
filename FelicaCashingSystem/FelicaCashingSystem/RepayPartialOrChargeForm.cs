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
    public partial class RepayPartialOrChargeForm : Form
    {
       
        public int    Money      { get; private set; }
        public int    RepayMoney { get; private set; }
        public string Purpose    { get; private set; }

        public RepayPartialOrChargeForm() : this(0, true)
        {
        }

        public RepayPartialOrChargeForm(int money, bool charge = false)
        {
            InitializeComponent();

            this.Purpose = charge ? "チャージ" : "返済";
            this.Money = money;
            this.RepayMoney = 0;

            foreach (var control in this.Controls)
            {
                if ((control as Button) != null && control != this.buttonCancel)
                {
                    var button = (Button)control;

                    if (button.ToInt() > Math.Abs(this.Money) && !charge)
                    {
                        button.Enabled = false;
                    }

                    else
                    {
                        button.Click += new EventHandler(this.MoneyButton_Clicked);
                    }
                }
            }
        }

        // フォームのタイトルを設定
        private void RepayPartialOrChargeForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Purpose;
            this.labelDescription.Text = this.Purpose + this.labelDescription.Text;
        }

        // ボタンの Text を見て、値を求める (XX円)
        private void MoneyButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                var money = button.ToInt();

                // 有効な金額ボタンな場合
                if (money > 0)
                {
                    this.RepayMoney = money;
                       
                    var result = MessageBox.Show(
                        "本当に、「 " + money.ToCommaStringAbs() + " 」円" + this.Purpose + "しますか？",
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
            }

            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        


    }


}
