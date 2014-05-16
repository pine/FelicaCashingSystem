using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Data.SQLite;
using System.Threading;

namespace FelicaCashingSystem
{
    
    static class Program
    {
        private static Mutex mutex = null;
        private static Form mainForm = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // ミューテックスを生成する
                Program.mutex = new Mutex(false, Application.ProductName);
            }
            catch (ApplicationException)
            {
                // グローバル・ミューテックスによる多重起動禁止
                MessageBox.Show("すでに起動しています。2つ同時には起動できません。", "多重起動禁止");
                return;
            }

            // ミューテックスを取得する
            if (mutex.WaitOne(0, false))
            {
                // アプリケーションを実行
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (var form = new MainForm())
                {
                    Program.mainForm = form;
                    Application.Run(form);
                    Program.mainForm = null;
                }

                // ミューテックスを解放する
                mutex.ReleaseMutex();
            }
            else
            {
                //  警告を表示して終了
                MessageBox.Show("すでに起動しています。2つ同時には起動できません。", "多重起動禁止");
            }

            // ミューテックスを破棄する
            mutex.Close();
        }

        public static void Exit()
        {
            if (Program.mainForm != null)
            {
                Program.mainForm.Dispose();
            }

            Application.Exit();
        }
    }
}
