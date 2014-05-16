using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace FelicaCashingSystem
{
    /// <summary>
    /// 一定周期でのバックアップ機能を提供するクラスです。
    /// </summary>
    class Backup : IDisposable
    {
        /// <summary>
        /// <see cref="Config"/>のバッキングストアです。
        /// </summary>
        private BackupConfig config;

        /// <summary>
        /// バックアップの設定を表します。
        /// 設定は開始中のバックアップにも即座に反映されます。
        /// </summary>
        public BackupConfig Config
        {
            set
            {
                // null は設定不可
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                // 設定を保存する
                this.config = value;

                // タイマーが開始されている場合、タイマーをリスタートする
                if (this.IsTimerStarted) { this.StartBackup(); }
            }
            get { return this.config; }
        }

        /// <summary>
        /// バックアップに使われるタイマーです。
        /// </summary>
        private Timer Timer { set; get; }

        /// <summary>
        /// タイマーが開始されているか表します。開始されている場合は真です。
        /// </summary>
        public bool IsTimerStarted { private set; get; }

        public Database Database { private set; get; }

        /// <summary>
        /// バックアップクラスを初期化します。
        /// </summary>
        /// <param name="config">バックアップの設定</param>
        public Backup(BackupConfig config, Database database)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            this.Config = config;
            this.Database = database;
            this.Timer = null;
            this.IsTimerStarted = false;
        }

        /// <summary>
        /// バックアップを開始します。
        /// バックアップは別スレッドで行われるため、処理はブロックされません。
        /// </summary>
        public void StartBackup()
        {
            this.ThrowExceptionIfDisposed();

            // タイマー開始を保存
            this.IsTimerStarted = true;

            // 妥当な設定でない場合、開始しない
            if (!this.Config.IsValid)
            {
                return;
            }

            // タイマーが作成されていない場合
            if (this.Timer == null)
            {
                // タイマーから呼び出されるデリゲートを生成
                var timerCallback = new TimerCallback(this.TimerCallback);

                // タイマーを開始
                this.Timer = new Timer(
                    timerCallback,   // タイマーから呼び出されるデリゲート
                    null,            // デリゲートに渡される引数
                    0,               // 開始遅延時間 (初回実行)
                    Timeout.Infinite // タイマー間隔 (繰り返し実行無効)
                    );
            }

            // タイマーが作成されている場合
            else
            {
                this.Timer.Change(0, Timeout.Infinite);
            }
        }

        /// <summary>
        /// <para>バックアップを停止します。</para>
        /// </summary>
        public void StopBackup()
        {
            this.ThrowExceptionIfDisposed();

            // タイマー停止を保存
            this.IsTimerStarted = false;

            // タイマーが作成されている場合
            if (this.Timer != null)
            {
                // タイマーを停止する
                this.Timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        /// <summary>
        /// 非同期にバックアップを一度実行する
        /// </summary>
        /// <returns></returns>
        public async Task BackupOnceAsync()
        {
            this.ThrowExceptionIfDisposed();

            // バックアップを実行する
            await Task.Run(() => { BackupOnce(); });
        }

        /// <summary>
        /// バックアップを実行するメソッドです。
        /// バックアップが終了するまでブロックします。
        /// </summary>
        public void BackupOnce()
        {
            this.ThrowExceptionIfDisposed();

            if (this.Config != null && this.Config.IsValid && this.Database != null)
            {
                this.Database.CopyTo(this.Config.FolderPath);
            }
        }

        /// <summary>
        /// <para>バックアップタイマーから呼び出されるコールバックメソッドです。</para>
        /// </summary>
        /// <param name="o"></param>
        private void TimerCallback(object o)
        {
            this.ThrowExceptionIfDisposed();

            if (!this.Config.IsValid)
            {
                return;
            }

            // タイマーを停止
            this.Timer.Change(Timeout.Infinite, Timeout.Infinite);

            // バックアップを実行
            try
            {
                this.BackupOnce();
            }

            // バックアップが失敗した場合
            catch (Exception)
            {
                return;
            }

            // 初回実行のみ行い、繰り返し実行はしない
          // (次回にタイマーを再度設定する)
          this.Timer.Change(this.Config.Interval, Timeout.Infinite);
        }

        #region Dispose Finalize パターン
        private bool disposed = false;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        ~Backup()
        {
            this.Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            if (this.disposed) { return; }

            this.disposed = true;

            if (disposing)
            {
                // マネージドリソースの開放
                if (this.Timer != null) { this.Timer.Dispose(); }
            }

            // アンマネージドリソースの開放
        }

        /// <summary>
        /// 破棄されていたら例外を発生させるメソッドです。
        /// </summary>
        protected void ThrowExceptionIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().ToString());
            }
        }

        #endregion
    }
}
