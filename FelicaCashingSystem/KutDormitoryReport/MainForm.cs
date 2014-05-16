using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RobotClub.DormitoryReport
{
    public partial class MainForm : Form
    {
        private DomitoryReport Report { get; set; }
        private DomitoryReportDataStatus DataStatus { get; set; }
        private string PdfFileName { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        public void Show(DomitoryReportData data)
        {
            this.Report = new DomitoryReport(data);
            this.DataStatus = new DomitoryReportDataStatus();
            this.PdfFileName = null;

            if (DomitoryReportData.Empty != data)
            {
                // 再度表示する処理
                this.InitializeUI();
                this.UpdateUI();
            }
        }

        /// <summary>
        /// UI をの初期化
        /// </summary>
        private void InitializeUI()
        {
            this.checkBoxPrintDialog.Checked = Properties.Settings.Default.PrintDialog;

            var tomorrow = DateTime.Now.AddDays(1);
            this.textBoxReturnDateEndMonth.Text = tomorrow.Month.ToString();
            this.textBoxReturnDateEndDate.Text = tomorrow.Day.ToString();
            this.textBoxReturnDateEndHour.Text = Properties.Settings.Default.ReturnDateEndHour.ToString();
            this.textBoxReturnDateEndMinutes.Text = Properties.Settings.Default.ReturnDateEndMinutes.ToString();
            this.textBoxReason.Text = this.Report.Data.Reason;
            
            // チェックボックスの初期状態
            this.checkBoxName.Checked = true;
            this.checkBoxRoomNo.Checked = true;
            this.checkBoxPhoneNumber.Checked = true;
            this.checkBoxLeaderName.Checked = true;
            this.checkBoxLeaderPhoneNumber.Checked = true;
            this.checkBoxReason.Checked = true;
            this.checkBoxReturnDateBeginToday.Checked = true;
            this.checkBoxReturnDateEndTomorrow.Checked = true;

            this.UpdateData();
        }

        /// <summary>
        /// UI を更新
        /// </summary>
        private void UpdateUI()
        {
            // 情報を表示
            this.textBoxName.Text = this.Report.Data.Name;
            this.textBoxRoomNo.Text = this.Report.Data.RoomNo;
            this.textBoxPhoneNumber.Text = this.Report.Data.PhoneNumber;
            this.textBoxLeaderName.Text = this.Report.Data.LeaderName;
            this.textBoxLeaderPhoneNumber.Text = this.Report.Data.LeaderPhoneNumber;
            this.textBoxReason.Text = this.Report.Data.Reason;

            // 選択状態を反映
            this.DataStatus.IsNameEnabled = this.checkBoxName.Checked;
            this.DataStatus.IsRoomNoEnabled = this.checkBoxRoomNo.Checked;
            this.DataStatus.IsPhoneNumberEnabled = this.checkBoxPhoneNumber.Checked;
            this.DataStatus.IsLeaderNameEnabled = this.checkBoxLeaderName.Checked;
            this.DataStatus.IsLeaderPhoneNumberEnabled = this.checkBoxLeaderPhoneNumber.Checked;
            this.DataStatus.IsReasonEnabled = this.checkBoxReason.Checked;
            this.DataStatus.IsDateEnabled = this.checkBoxDate.Checked;
            this.DataStatus.IsReturnDateBeginEnabled = this.checkBoxReturnDateBeginToday.Checked;
            this.DataStatus.IsReturnDateEndEnabled =
                this.checkBoxReturnDateEndToday.Checked ||
                this.checkBoxReturnDateEndTomorrow.Checked ||
                this.checkBoxReturnDateEndOther.Checked;
            
            // データの有無で有効・無効を変更
            this.CheckDataNuthing(this.Report.Data.Name, this.checkBoxName);
            this.CheckDataNuthing(this.Report.Data.RoomNo, this.checkBoxRoomNo);
            this.CheckDataNuthing(this.Report.Data.PhoneNumber, this.checkBoxPhoneNumber);
            this.CheckDataNuthing(this.Report.Data.LeaderName, this.checkBoxLeaderName);
            this.CheckDataNuthing(this.Report.Data.LeaderPhoneNumber, this.checkBoxLeaderPhoneNumber);
            this.CheckDataNuthing(this.Report.Data.Reason, this.checkBoxReason);

            // 帰寮日 終了日 その他
            this.panelReturnDateEnd.Enabled = this.checkBoxReturnDateEndOther.Checked;

            // PDF を表示
            this.PdfFileName = this.Report.Write(this.DataStatus);
            this.axAcroPDF.LoadFile(this.PdfFileName);
        }

        /// <summary>
        /// 現状のフォーム値にもとづきデータを変更する
        /// </summary>
        private void UpdateData()
        {
            // データを更新
            this.Report.Data.Reason = this.textBoxReason.Text;

            // 帰寮日 終了日 データを更新
            if (this.checkBoxReturnDateEndToday.Checked)
            {
                this.Report.Data.ReturnDateEndToday();
            }

            if (this.checkBoxReturnDateEndTomorrow.Checked)
            {
                this.Report.Data.ReturnDateEndTomorrow();
            }

            if (this.checkBoxReturnDateEndOther.Checked)
            {
                this.Report.Data.ReturnDateEndOther(
                    int.Parse(this.textBoxReturnDateEndMonth.Text),
                    int.Parse(this.textBoxReturnDateEndDate.Text),
                    int.Parse(this.textBoxReturnDateEndHour.Text),
                    int.Parse(this.textBoxReturnDateEndMinutes.Text)
                    );
            }
        }

        /// <summary>
        /// 現状のフォーム値にもとづきデータを変更後、UI を更新する
        /// </summary>
        private void UpdateDataAndUI()
        {
            this.UpdateData();
            this.UpdateUI();
        }

        /// <summary>
        /// 印刷する
        /// </summary>
        private void Print()
        {
            if (this.checkBoxPrintDialog.Checked)
            {
                this.axAcroPDF.printWithDialog();
            }
            else
            {
                this.axAcroPDF.printAll();
            }
        }

        /// <summary>
        /// 保存する
        /// </summary>
        private void Save()
        {
            if (this.PdfFileName == null) { return; }

            var sfd = new SaveFileDialog();

            if (string.IsNullOrEmpty(this.Report.Data.Name))
            {
                sfd.FileName = "*.pdf";
            }
            else
            {
                sfd.FileName = Properties.Settings.Default.FileNamePrefix + this.Report.Data.Name + ".pdf";
            }

            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            sfd.DefaultExt = "pdf";
            sfd.Filter = "PDF (*.pdf)|*.pdf|すべて(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.Title = "名前をつけて保存";

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    File.Copy(this.PdfFileName, sfd.FileName, true);
                    MessageBox.Show("正常に保存が行われました。", "保存に成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception) {
                    MessageBox.Show("正常に保存が行われませんでした。", "保存に失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void CheckDataNuthing(string data, CheckBox checkbox)
        {
            if (string.IsNullOrEmpty(data))
            {
                checkbox.Checked = false; // 無効の場合はチェックを外す
                checkbox.Enabled = false;
            }
            else
            {
                checkbox.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.InitializeUI();
            this.UpdateUI();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateDataAndUI();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void checkBoxReturnDateEnd_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;

            if (checkbox.Checked)
            {
                this.checkBoxReturnDateEndToday.Checked = this.checkBoxReturnDateEndToday == checkbox;
                this.checkBoxReturnDateEndTomorrow.Checked = this.checkBoxReturnDateEndTomorrow == checkbox;
                this.checkBoxReturnDateEndOther.Checked = this.checkBoxReturnDateEndOther == checkbox;
            }

            this.UpdateDataAndUI();
        }
    }
}
