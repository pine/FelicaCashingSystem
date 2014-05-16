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
    public partial class BackupConfigForm : Form
    {
        /// <summary>
        /// バックアップの設定
        /// </summary>
        private BackupConfig Config { set; get; }

        /// <summary>
        /// バックアップ設定のダイアログを初期化する。
        /// </summary>
        /// <param name="config">バックアップの設定</param>
        public BackupConfigForm(BackupConfig config)
        {
            InitializeComponent();

            this.Config = config;
        }

        /// <summary>
        /// フォームがロードされた時に発生するイベントハンドラです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackupConfigForm_Load(object sender, EventArgs e)
        {
            this.textBoxBackupFolderPath.Text = this.Config.FolderPath;
            this.textBoxBackupInterval.Text = this.Config.Interval.ToString();
        }

        /// <summary>
        /// フォームが閉じられた時に発生するイベントハンドラです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BackupConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Config.FolderPath = this.textBoxBackupFolderPath.Text;

            try
            {
                // ミリ秒に直す
                this.Config.Interval = int.Parse(this.textBoxBackupInterval.Text) * 1000 * 60;
            }
            catch (Exception)
            {
                this.Config.Interval = 0;
            }

            await this.Config.Save();
        }

        /// <summary>
        /// バックアップ先の選択ボタンをクリックした時のイベントハンドラです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectBackupFolderPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "バックアップ先フォルダの選択"; // タイトル
                fbd.SelectedPath = this.Config.FolderPath;

                // ダイアログを表示する
                if (fbd.ShowDialog(this) == DialogResult.OK)
                {
                    // 選択されたフォルダをテキストボックスに表示させる
                    this.textBoxBackupFolderPath.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
