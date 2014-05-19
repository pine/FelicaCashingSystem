using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Diagnostics;
using RobotClub;

namespace FelicaCashingSystem
{
    public partial class MainForm : Form
    {
        private Felica felica = null;
        private Database db = new Database();
        private User user = null;
        private IAsyncResult cardSetAsync = null;
        private List<Form> modalDialog = new List<Form>();
        private string associationUid = null;
        private Backup backup = null;
        private BackupConfig backupConfig = null;
        private RobotClub.DormitoryReport.MainForm dormitoryForm =
            RobotClub.DormitoryReport.DomitoryReport.CreateWindow();

        public MainForm()
        {
            InitializeComponent();

            this.felica = new Felica();

            if (!this.felica.ConnectReader())
            {
                MessageBox.Show(
                    "リーダーが接続されていません。プログラムを終了します。",
                    "起動エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                Program.Exit();
            }

            this.felica.SetCallback(new FelicaGetUidDelegate(this.PollingCallback));
            this.felica.BeginPolling();

            // バックアップ
            this.backupConfig = new BackupConfig();
            this.backupConfig.Load();

            //this.backupConfig.Interval = 10 * 60 * 1000;
            //this.backupConfig.Save();

            this.backup = new Backup(this.backupConfig, this.db);
            this.backup.StartBackup();

            this.dormitoryForm.Show(RobotClub.DormitoryReport.DomitoryReportData.Empty);
            this.dormitoryForm.Show();
            this.dormitoryForm.Visible = false;
        }

        // デザイナーに含まれないリソースの解放処理
        private bool disposedNonDesignerComponents = false;

        private void DisposeNonDesignerComponents(bool disposing)
        {
            // 2 回呼ばれる可能性がある (2 回呼ばれる事態が発生)
            if (disposedNonDesignerComponents) { return; }

            if (disposing)
            {
                // マネージリソースの解放処理
                this.backup.StopBackup();
                this.backup.Dispose();
            }

            // アンマネージリソースの解放処理
            this.felica.Dispose();

            this.disposedNonDesignerComponents = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void notify_icon_exit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "本当に終了しますか？\nこれ以降のカードは読み取れません。",
                "警告",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2
                );

            if (result == DialogResult.Yes)
            {
                Program.Exit();
            }
        }
        
        private void PollingCallback(string uid)
        {
            if (this.cardSetAsync != null)
            {
                // モーダルダイアログが開かれている場合
                if (this.modalDialog != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        foreach(var form in this.modalDialog){
                            form.Close();
                        }

                        this.modalDialog.Clear();
                    });

                    Utility.CloseMessageBox();
                }

                this.EndInvoke(this.cardSetAsync);
            }

            this.CardSet(uid);
        }

        private void CardSet(string uid)
        {
            if (InvokeRequired)
            {
                this.cardSetAsync = this.BeginInvoke((MethodInvoker)delegate()
                {
                    this.CardSet(uid);
                });

                return;
            }

            // ユーザーが登録されているか調べる
            this.user = this.db.GetUser(uid);
            this.UpdateGUI(uid);
            this.ShowMainForm();

            // 関連付けを行う
            if (this.associationUid != null && this.user != null)
            {
                
                // 関連付けの確認を行う
                using (var form = new AssociationCheckForm(this.user.Money, this.user.Name))
                {
                    this.ShowMultiThreadDialog(form);

                    if (form.DialogResult == DialogResult.Yes)
                    {
                        

                        if (this.db.AssociationAdd(this.user.Uid, this.associationUid))
                        {
                            MessageBox.Show("関連付けに成功しました。");

                            this.user = this.db.GetUser(this.associationUid);
                            this.UpdateGUI();
                        }
                        else
                        {
                            MessageBox.Show("関連付けに失敗しました。");
                        }
                    }
                }

                // 関連付けに保持している情報を開放
                this.associationUid = null;
            }

            if (this.user == null)
            {
                this.associationUid = null;

                var register      = new RegisterForm(this.db, uid);
//                this.modalDialog = register;
                var dialog_result = this.ShowMultiThreadDialog(register);

                if (dialog_result != DialogResult.OK)
                {
                    return;
                }

                // ユーザー登録
                if (this.db.AddUser(uid, register.UserName, register.Mail))
                {
                    // 登録完了メールを送信
                    ThreadPool.QueueUserWorkItem((WaitCallback)delegate(object o)
                    {
                        Mail.RegisterComplete(register.Mail, register.UserName);
                    });
                }

                // ユーザー登録失敗
                else
                {
                    MessageBox.Show("ユーザーの登録に失敗しました。");
                    return;
                }

                this.user = this.db.GetUser(uid);
                this.UpdateGUI();
            }


        }

        public void SetAssociation(string association)
        {
            this.associationUid = association;
        }

        private void UpdateGUI(string uid = null)
        {

            if (this.user == null)
            {
                this.labelUserName.Text = "未登録";
                this.labelMoney.Text = "0 円";

                if (uid == null)
                {
                    this.labelUid.Text = "UID: 未取得";
                }

                else
                {
                    this.labelUid.Text = "UID: " + uid;
                }

                this.labelMoney.ForeColor = SystemColors.ControlText;
                this.buttonCashing110.Enabled = false;
                this.buttonRepay.Enabled = false;
                this.buttonCashing.Enabled = false;
                this.buttonLog.Enabled = false;
                this.buttonUserList.Enabled = false;
                this.labelUidSub.Visible = false;
                this.ToolStripMenuItemBackupConfig.Enabled = false;
                this.buttonCharge.Enabled = false;
                this.buttonStatistics.Enabled = false;
                this.menuItemChangeName.Enabled = false;
                this.buttonChangeProfile.Enabled = false;
                this.buttonPrint.Enabled = false;
            }

            else
            {

                // 関連付けが行われている場合
                if (user.Uid != user.RealUid)
                {
                    this.labelUidSub.Text = "UID: " + user.RealUid;
                    this.labelUid.Text = "UID: " + user.Uid + " (関連付け中)";
                    this.labelUidSub.Visible = true;
                }

                else
                {
                    this.labelUid.Text = "UID: " + user.Uid;
                    this.labelUidSub.Visible = false;
                }

                
                this.labelUserName.Text = this.user.Name;
                this.labelMoney.Text = this.user.Money.ToCommaString() + "円";
                this.labelMoney.ForeColor = this.user.Money.GetMoneyColor();

                this.buttonCashing110.Enabled = true;
                this.buttonCashing.Enabled = true;
                this.buttonLog.Enabled = true;
                this.buttonUserList.Enabled = true;
                this.buttonCharge.Enabled = true;
                this.buttonStatistics.Enabled = true;
                this.menuItemChangeName.Enabled = true;
                this.buttonChangeProfile.Enabled = true;
                this.buttonPrint.Enabled = true;
                this.buttonRepay.Enabled = true;

#if DEBUG
                this.ToolStripMenuItemBackupConfig.Enabled = true;
#else
                this.ToolStripMenuItemBackupConfig.Enabled = this.user.Admin;
#endif
            }
        
        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }

        public string ShowChangeNameForm()
        {
            var rename = new RenameForm(this.db, this.user.Name);
            var dialog_result = this.ShowMultiThreadDialog(rename);

            if (dialog_result != DialogResult.OK)
            {
                return null;
            }

            if (this.db.Rename(this.user.Uid, rename.UserName))
            {
                MessageBox.Show("名前の変更に成功しました。");

                this.user.Name = rename.UserName;
                this.UpdateGUI();

                return rename.UserName;
            }

            else
            {
                MessageBox.Show("名前の変更に失敗しました。");

                return null;
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            this.ShowChangeNameForm();
        }

        private void ShowMainForm()
        {
            if (this.Visible)
            {
                this.Close();
            }

            this.Visible = true;
            this.Opacity = 1;
            
            this.Activate();
            this.buttonCashing110.Focus();

            // 乱数で工場長にする
            if (this.IsKojocho)
            {
                this.pictureBoxIcon.ImageLocation = "Kojocho.png";
            }
            else
            {
                // 初期イメージ
                this.pictureBoxIcon.ImageLocation = "FelicaIconTatsuya.png";
            }
        }

        // 購入・借用フォームを表示
        private void ShowBuyOrCashingForm(int buyOrCashingMoney)
        {
            // 引数の値をチェックする
            if (buyOrCashingMoney <= 0)
            {
                throw new ArgumentException(
                    "購入・借用金額がゼロ以下です。",
                    "buyOrCashingMoney"
                    );
            }

            // フォームを表示
            using (var form = new BuyOrCashingForm(this.user.Money, buyOrCashingMoney))
            {
                var result = this.ShowMultiThreadDialog(form);

                // 決済完了
                if (result == DialogResult.Yes)
                {
                    if (this.db.BuyOrCashing(this.user.Uid, buyOrCashingMoney))
                    {
                        this.user.Money -= buyOrCashingMoney;
                        this.UpdateGUI();
                    }
                    else
                    {
                        MessageBox.Show("借用に失敗しました。");
                    }
                }
            }
        }

        // ユーザー一覧を表示
        private void ShowUserListForm()
        {
            var users = this.db.GetUserList(this.user.Uid);

            if (users != null)
            {
                using (var form = new UserListForm(this.user, users, this.db))
                {
                    this.ShowMultiThreadDialog(form);
                }
            }

            else
            {
                MessageBox.Show("ユーザー一覧の取得に失敗しました。");
            }
        }

        private void ShowLogForm()
        {
            var log = this.db.GetLog(this.user.Uid);

            if (log == null)
            {
                MessageBox.Show(
                    "ログの取得に失敗しました",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                return;
            }

            using (var form = new LogForm(log))
            {
                this.ShowMultiThreadDialog(form);
            }
        }

        private void ShowRepayForm()
        {
            var repayForm = new RepayForm(this.user.Money);
            var result    = this.ShowMultiThreadDialog(repayForm);

            if (result == DialogResult.OK)
            {
                // 部分返済
                if (repayForm.RepayPartial)
                {
                    var repayPartialForm = new RepayPartialOrChargeForm(this.user.Money);
                    result = this.ShowMultiThreadDialog(repayPartialForm);

                    if (result == DialogResult.OK)
                    {
                        if (this.db.RepayOrChargeMoney(this.user.Uid, repayPartialForm.RepayMoney))
                        {
                            this.user.Money += repayPartialForm.RepayMoney;
                            this.UpdateGUI();
                        }

                        else
                        {
                            MessageBox.Show("返済に失敗しました。");
                        }
                    }
                }

                // 全額返済
                else
                {
                    if (this.db.RepayOrChargeMoney(this.user.Uid, Math.Abs(this.user.Money)))
                    {
                        this.user.Money = 0;
                        this.UpdateGUI();
                    }

                    else
                    {
                        MessageBox.Show("返済に失敗しました。");
                    }
                }
            }
        }

        private void ShowChargeForm()
        {
            // チャージ
            var repayPartialForm = new RepayPartialOrChargeForm();
            var result = this.ShowMultiThreadDialog(repayPartialForm);

            if (result == DialogResult.OK)
            {
                if (this.db.RepayOrChargeMoney(this.user.Uid, repayPartialForm.RepayMoney))
                {
                    this.user.Money += repayPartialForm.RepayMoney;
                    this.UpdateGUI();
                }

                else
                {
                    MessageBox.Show("チャージに失敗しました。");
                }
            }
        }

        private void button100Yen_Click(object sender, EventArgs e)
        {
            this.ShowBuyOrCashingForm(100);
        }

        private void buttonUserList_Click(object sender, EventArgs e)
        {
            this.ShowUserListForm();
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            this.ShowLogForm();
        }

        private void buttonRepay_Click(object sender, EventArgs e)
        {
            this.ShowRepayForm(); 
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowSelectCashingMoneyForm()
        {
            using (var form = new SelectCashingMoneyForm())
            {
                this.ShowMultiThreadDialog(form);

                if (form.Money > 0)
                {
                    this.ShowBuyOrCashingForm(form.Money);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Visible = false;
            
        }

        // マルチスレッド環境で閉じることができるモーダルダイアログを表示する
        // Felica の Polling の割り込みで、閉じる処理を行う
        public DialogResult ShowMultiThreadDialog(Form form, Form owner = null)
        {
            this.modalDialog.Add(form);

            var result = form.ShowDialog(owner ?? this);
            
            this.modalDialog.Remove(form);
            this.ActiveControl = this.buttonCashing110;

            return result;
        }

        private void buttonCashing_Click(object sender, EventArgs e)
        {
            this.ShowSelectCashingMoneyForm();
        }



        private void ShowUpdateHistory()
        {
            var form = new UpdateHistoryForm("UpdateHistory.txt");
            this.ShowMultiThreadDialog(form);
        }

        private void ShowVersionForm()
        {
            MessageBox.Show(
                Application.ProductName + " " + Application.ProductVersion,
                "バージョン情報",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }

        /// <summary>
        /// バックアップ設定ウィンドウを表示するメソッドです。
        /// </summary>
        private void ShowBackupConfigForm()
        {
            using (var dialog = new BackupConfigForm(backupConfig))
            {
                this.ShowMultiThreadDialog(dialog);
                this.backup.Config = backupConfig;
            }
        }

        /// <summary>
        /// ドミトリーフォームを表示
        /// </summary>
        private void ShowDomitoryForm()
        {
            var data = new RobotClub.DormitoryReport.DomitoryReportData();

            data.Name = this.user.Name;
            data.PhoneNumber = this.user.PhoneNumber;
            data.RoomNo = this.user.RoomNo;

            data.LeaderName = Properties.Settings.Default.LeaderName;
            data.LeaderPhoneNumber = Properties.Settings.Default.LeaderPhoneNumber;
            data.Reason = "ロボット倶楽部の活動のため";

            this.dormitoryForm.Show(data);
            this.ShowMultiThreadDialog(this.dormitoryForm);
        }

        // バージョン情報を表示
        private void notify_icon_version_Click(object sender, EventArgs e)
        {
            this.ShowVersionForm();
        }

        // 統計情報を表示
        private void ShowStatisticsForm()
        {
            var dict = this.db.GetStatisticsCashing(this.user.Uid);

            using (var form = new StatisticsForm(dict))
            {
                this.ShowMultiThreadDialog(form);
            }
        }

        private void ShowUserProfile()
        {
            if (this.user == null) { return; }

            using (var form = new ProfileForm(this.user))
            {
                var result = this.ShowMultiThreadDialog(form);

                if (result == DialogResult.OK)
                {
                    this.user = form.User;
                    this.db.UpdateUser(this.user);
                }
            }
        }

        // 更新履歴を表示
        private void buttonShowUpdateHistory_Click(object sender, EventArgs e)
        {
            this.ShowUpdateHistory();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ShowUpdateHistory();
        }

        private void buttonCharge_Click(object sender, EventArgs e)
        {
            this.ShowChargeForm();
        }

        // 統計を表示
        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            this.ShowStatisticsForm();
        }

        // 閉じる
        private void menuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 更新情報のメニュー
        private void menuItemUpdate_Click(object sender, EventArgs e)
        {
            this.ShowUpdateHistory();
        }

        // バージョン情報のメニュー
        private void menuItemVersion_Click(object sender, EventArgs e)
        {
            this.ShowVersionForm();
        }

        private void buttonCashing30_Click(object sender, EventArgs e)
        {
            this.ShowBuyOrCashingForm(30);
        }

        private void menuItemChangeName_Click(object sender, EventArgs e)
        {
            this.ShowChangeNameForm();
        }

        /// <summary>
        /// バックアップ設定ウィンドウを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemBackupConfig_Click(object sender, EventArgs e)
        {
            this.ShowBackupConfigForm();
        }

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            if (this.user != null && this.user.Name.IndexOf("プロデューサー") >= 0)
            {
                System.Diagnostics.Process.Start("http://www.microsoft.com/ja-jp/default.aspx");
            }

            else
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.FelicaLogoUrl);
            }
        }

        private int KojochoProbability = 100;

        /// <summary>
        /// 工場長にするかどうかを返す
        /// </summary>
        /// <returns></returns>
        private bool IsKojocho
        {
            get {
                var r = new Random();
                return r.Next(KojochoProbability) == 0;
            }
        }

        private void buttonChangeProfile_Click(object sender, EventArgs e)
        {
            this.ShowUserProfile();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            this.ShowDomitoryForm();
        }

        private void buttonRepay_Click_1(object sender, EventArgs e)
        {
            this.ShowRepayForm();
        }

        private void button110Yen_Click(object sender, EventArgs e)
        {
            this.ShowBuyOrCashingForm(110);
        }

    }
}
