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
    public partial class RegisterForm : Form
    {
        private readonly Database db;
        private readonly string uid;

        public string UserName { get; private set; }
        public string Mail { get; private set; }

        public RegisterForm(Database db, string uid)
        {
            InitializeComponent();
            this.db = db;
            this.uid = uid;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string name = this.textBoxUserName.Text;
            string mail = this.textBoxMail.Text;

            if (name.Length == 0)
            {
                MessageBox.Show(
                    "名前が入力されていません。",
                    "登録エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                return;
            }

            if (!this.db.IsUserNameUnique(name))
            {
                MessageBox.Show(
                    "入力された名前は既に使用されています。",
                    "登録エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                return;
            }

            if (!FelicaCashingSystem.Mail.IsValidEmail(mail))
            {
                MessageBox.Show(
                    "メールアドレスが正しい形式ではありません。",
                    "登録エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                
                return;
            }

            this.UserName = name;
            this.Mail = mail;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void buttonAssociation_Click(object sender, EventArgs e)
        {
            ((MainForm)this.Owner).SetAssociation(this.uid);

            using (var form = new AssociationWaitForm())
            {
                var result = ((MainForm)this.Owner).ShowMultiThreadDialog(form, this);

                if (result != DialogResult.Cancel)
                {
                    ((MainForm)this.Owner).SetAssociation(null);
                }
            }
        }
    }
}
