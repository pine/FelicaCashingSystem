using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace FelicaCashingSystem
{
    public partial class UserListForm : Form
    {
        private readonly User user;
        private readonly Database db;
        private string selectedUid = null;

        public UserListForm(User user, DataTable users, Database db)
        {
            InitializeComponent();

            this.user = user;
            this.db = db;
            this.dataGridViewList.DataSource = users;
        }

        private void UserListForm_Load(object sender, EventArgs e)
        {
            this.Sort();

            // 管理者である場合、部費徴収を有効にする
#if DEBUG
            this.contextMenuStripList.Enabled = true;
#else
            this.contextMenuStripList.Enabled = this.user.Admin;
#endif
            }

        private void dataGridViewList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value is int)
            {
                e.CellStyle.ForeColor = ((int)e.Value).GetMoneyColor();
            }
        }


        // 右クリックメニューが表示される前に実行されるイベント
        private void dataGridViewList_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            // ヘッダセル以外の場合
            if(e.ColumnIndex >= 0 && e.RowIndex >= 0){
                var dgv = (DataGridView)sender;

                // 右クリックされたセルを取得
                DataGridViewCell cell = dgv[e.ColumnIndex, e.RowIndex];
                
                // セルを選択状態にする
                cell.Selected = true;

                var uid = dgv.Rows[e.RowIndex].Cells["UID"].Value.ToString();

                this.selectedUid = uid;
            }
        }

        private void Sort()
        {
            this.dataGridViewList.Sort(
                this.dataGridViewList.Columns[2],
                ListSortDirection.Ascending
                );
        }

        // データソースが変更になった場合
        private void dataGridViewList_DataSourceChanged(object sender, EventArgs e)
        {
            // 合計を計算する
            var data = (DataTable)this.dataGridViewList.DataSource;

            // 合計
            int sum = 0;

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                sum += int.Parse(data.Rows[i]["金額"].ToString());
            }

            // 合計金額を表示
            this.labelMoneyAllSum.Text = sum.ToCommaString();
            this.labelMoneyAllSum.ForeColor = sum.GetMoneyColor();
        }


        // 部費徴収メニューがクリックされた場合
        private void menuItemClubDues_Click(object sender, EventArgs e)
        {
            CollectionClubDues(Properties.Settings.Default.ClubDues);
        }


        private void menuItemClubDues2_Click(object sender, EventArgs e)
        {
            CollectionClubDues(Properties.Settings.Default.ClubDues2);
        }

        private void CollectionClubDues(int clubDues)
        {
            

            // 項目が選択状態
            if (this.selectedUid != null)
            {
                var selectedUser = this.db.GetUser(this.selectedUid);

                // ユーザーが存在する場合
                if (selectedUser != null)
                {
                    var result = MessageBox.Show(
                        string.Format(
                            Properties.Resources.MessageBoxTextForceCashing,
                            selectedUser.Name,
                            clubDues.ToCommaStringAbs()
                            ),
                        "部費強制徴収",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button2
                        );

                    // 徴収をしない場合
                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    // 強制徴収
                    if (this.db.ForceCashing(
                        selectedUid,
                        clubDues,
                        this.user.Uid
                        ))
                    {
                        // メールを送信する
                        if (this.user.Mail != null)
                        {
                            ThreadPool.QueueUserWorkItem((WaitCallback)delegate(object o)
                            {
                                Mail.SendCollectClubDues(
                                        selectedUser.Mail,
                                        selectedUser.Name,
                                        this.user.Name,
                                        selectedUser.Money - clubDues,
                                        clubDues
                                    );

                            });
                        }

                        MessageBox.Show("部費徴収に成功しました。");

                        // ユーザー情報を更新
                        this.dataGridViewList.DataSource =
                            this.db.GetUserList(this.user.Uid);
                        this.Sort();
                    }
                }
            }
        }

        private void menuItemRepayRequest_Click(object sender, EventArgs e)
        {
            // 項目が選択状態でない場合
            if (this.selectedUid == null)
            {
                return;
            }

            var selectedUser = this.db.GetUser(this.selectedUid);

            // ユーザが存在しない場合
            if (selectedUser == null) return;

            // 借用していない場合
            if (selectedUser.Money > 0)
            {
                MessageBox.Show("このユーザは借用をしていません。");
                return;
            }

            var result = MessageBox.Show(
                string.Format(
                    Properties.Resources.MessageBoxTextRepayRequest,
                    selectedUser.Name
                    ),
                Properties.Resources.MessageBoxTitleRepayRequest,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button2
                );

            if (result == DialogResult.Yes && selectedUser.Mail != null)
            {
                ThreadPool.QueueUserWorkItem((WaitCallback)delegate(object o)
                {
                    Mail.SendRepayRequest(
                        selectedUser.Mail,
                        selectedUser.Name,
                        this.user.Name,
                        selectedUser.Money
                    );
                });

                MessageBox.Show("メールの送信に成功しました。");
            }
        }

    }
}
