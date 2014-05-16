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
    public partial class RenameForm : Form
    {
        private readonly Database db;
        private readonly string   oldName;

        public RenameForm(Database db, string oldName)
        {
            InitializeComponent();

            this.labelDesc.Text =
                "現在の名前は「 " + oldName + " 」です。\n" +
                "新しい名前を入力してください。";

            this.db      = db;
            this.oldName = oldName;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            var name = this.textBoxUserName.Text;

            if (name.Length == 0)
            {
                MessageBox.Show("名前が入力されていません。");
                return;
            }

            if (this.oldName == name)
            {
                MessageBox.Show("入力された名前は現在の名前と同じです。");
                return;
            }

            if (!this.db.IsUserNameUnique(name))
            {
                MessageBox.Show("入力された名前は既に使用されています。");
                return;
            }

            this.UserName = name;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        internal string UserName { get; private set; }
    }
}
