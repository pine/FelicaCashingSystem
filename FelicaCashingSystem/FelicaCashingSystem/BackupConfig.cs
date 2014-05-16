using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FelicaCashingSystem
{
    /// <summary>
    /// 設定の抽象クラス
    /// </summary>
    abstract public class Config
    {
        /// <summary>
        /// 設定を保存先から読み込む
        /// </summary>
        abstract public void Load();
        
        /// <summary>
        /// 設定を保存先に保存する
        /// </summary>
        /// <returns></returns>
        virtual public async Task Save()
        {
            await Task.Run(() =>
            {
                Properties.Settings.Default.Save();
            });

        }

        /// <summary>
        /// 指定されたプロパティ名の値を読み出す
        /// </summary>
        /// <typeparam name="Type">型名</typeparam>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>読みだした値</returns>
        protected Type LoadProperty<Type>(string propertyName)
        {
            return (Type)Properties.Settings.Default[propertyName];
        }

        /// <summary>
        /// 指定されたプロパティ名の値を保存する
        /// </summary>
        /// <typeparam name="Type">型名</typeparam>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="propertyValue">値</param>
        protected void SaveProperty<Type>(string propertyName, Type propertyValue)
        {
            Properties.Settings.Default[propertyName] = propertyValue;
        }
    }

    /// <summary>
    /// バックアップ設定
    /// </summary>
    public class BackupConfig : Config
    {
        public const int IntervalMin = 60 * 1000; // 1分

        /// <summary>
        /// バックアップ先のフォルダーパス
        /// </summary>
        public string FolderPath { get; set;  }

        /// <summary>
        /// バックアップ間隔 (ミリ秒)
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 設定を読み込む
        /// </summary>
        override public void Load()
        {
            this.FolderPath = this.LoadProperty<string>("BackupFolderPath");
            this.Interval = this.LoadProperty<int>("BackupInterval");
        }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        /// <returns></returns>
        override public async Task Save()
        {
            this.SaveProperty("BackupFolderPath", this.FolderPath);
            this.SaveProperty("BackupInterval", this.Interval);

            await base.Save();
        }

        /// <summary>
        /// 妥当な設定であるかを返す。
        /// </summary>
        /// <returns></returns>
        public bool IsValid
        {
            get
            {
                return Directory.Exists(this.FolderPath) && this.Interval > 0;// BackupConfig.IntervalMin;
            }
        }
    }
}
