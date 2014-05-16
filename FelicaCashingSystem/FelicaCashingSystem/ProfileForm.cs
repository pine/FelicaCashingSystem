using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FelicaCashingSystem
{
    public partial class ProfileForm : Form
    {
        
        public ProfileForm(User user)
        {
            InitializeComponent();

            this.User = user;
            this.textBoxName.Text = this.User.Name;
            this.textBoxMail.Text = Utility.ToString(this.User.Mail);
            this.checkBoxIsDormitory.Checked = this.User.IsDormitory;
            this.panelDormitory.Enabled = this.User.IsDormitory;
            this.textBoxRoomNo.Text = Utility.ToString(this.User.RoomNo);
            this.textBoxPhoneNumber.Text = Utility.ToString(this.User.PhoneNumber);
        }

        public User User
        {
            get;
            private set;
        }

        private void checkBoxIsDormitory_CheckedChanged(object sender, EventArgs e)
        {
            this.panelDormitory.Enabled = this.checkBoxIsDormitory.Checked;
            this.User.IsDormitory = this.checkBoxIsDormitory.Checked;
        }

        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.User.Mail = this.textBoxMail.Text;
            this.User.IsDormitory = this.checkBoxIsDormitory.Checked;
            this.User.RoomNo = this.textBoxRoomNo.Text;
            this.User.PhoneNumber = this.textBoxPhoneNumber.Text;
        }
    }
}
