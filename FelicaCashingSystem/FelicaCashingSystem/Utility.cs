using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

namespace FelicaCashingSystem
{
    // ユーティリティ関数 (笑) クラス
    static class Utility
    {
        public static string ToString(string str)
        {
            if (str == null) { return string.Empty; }
            return str;
        }

        public static string ToGreeting(this string name)
        {
            return "「 " + name + " 」さん、こんにちは。";
        }

        public static string ToCommaStringAbs(this int val)
        {
            return String.Format("{0:#,0}", Math.Abs(val));
        }

        public static string ToCommaString(this int val)
        {
            return (val > 0 ? "+" : "") +String.Format("{0:#,0}", val);
        }

        // テキストを数値に変換する
        // コンマは無視し、変換出来るところまで変換する
        public static int ToIntFromComma(this string str)
        {
            var intStr = Regex.Match(str.Replace(",", ""), "[0-9]+").ToString();

            return intStr.Length > 0 ? int.Parse(intStr) : 0;
        }

        // ボタンのテキストを数値に変換する
        // コンマは無視し、変換出来るところまで変換する
        public static int ToInt(this Button button)
        {
            var buttonText = button.Text.Replace(",", "");
            var intStr = Regex.Match(buttonText, "[0-9]+").ToString();

            return intStr.Length > 0 ? int.Parse(intStr) : 0;
        }

        // 開いているメッセージボックスを閉じる
        public static void CloseMessageBox()
        {
            new CloseMessageBoxImpl().Close();
        }

        // 金額の色を取得
        public static Color GetMoneyColor(this int money)
        {
            if (money > 0)
            {
                return Color.Blue;
            }

            else if (money < 0)
            {
                return Color.Red;
            }

            else
            {
                return SystemColors.ControlText;
            }
        }

        // ハイフン区切りの日付を数値に変換
        public static int[] ToDateIntArray(this string str)
        {
            var values = str.Split('-');
            var values_int = new int[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                values_int[i] = int.Parse(values[i]);
            }

            return values_int;
        }

        // 文字列の数値に変換
        public static string ToDateString(this int[] values_int)
        {
            // YYYY-MM-DD
            if (values_int.Length == 3)
            {
                return string.Format(
                    "{0:D4}-{1:D2}-{1:D2}",
                    values_int[0],
                    values_int[1],
                    values_int[2]
                    );
            }

            // YYYY-MM
            if (values_int.Length == 2)
            {
                return string.Format("{0:D4}-{1:D2}", values_int[0], values_int[1]);
            }
            
            throw new NotImplementedException();
        }

        // 一つ前を取得
        
        public static int[] PrevDateIntArray(this int[] arg)
        {
            int[] date = (int[])arg.Clone();

            // YYYY-MM
            if (date.Length == 2)
            {
                --date[1];

                if (date[1] < 1)
                {
                    --date[0];
                    date[1] = 12;
                }

                return date;
            }

            throw new NotImplementedException();
        }
    }

    internal class CloseMessageBoxImpl
    {
        private delegate int EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, [Out] StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PostMessage(
            IntPtr hWnd,
            int Msg,
            IntPtr wParam,
            IntPtr lParam
            );

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(
            IntPtr hWnd
            );

        internal void Close()
        {
            EnumWindows(new EnumWindowsProc(this.EnumCallback), IntPtr.Zero);
        }

        internal int EnumCallback(IntPtr hWnd, IntPtr lParam)
        {
            uint processId;
            uint threadId;

            threadId = GetWindowThreadProcessId(hWnd, out processId);

            if (processId == Process.GetCurrentProcess().Id)
            {
                StringBuilder className = new StringBuilder("", 256);
                GetClassName(hWnd, className, 256);

                // メッセージボックスを閉じる
                if (className.ToString() == "#32770")
                {
                    const int WM_COMMAND = 0x111;

                    PostMessage(hWnd, WM_COMMAND, new IntPtr(2), IntPtr.Zero); // キャンセルボタン
                    PostMessage(hWnd, WM_COMMAND, new IntPtr(7), IntPtr.Zero); // Noボタン
                    SetForegroundWindow(hWnd);
                    SendKeys.SendWait("n");

                    return 1;
                }
            }
            return 1;
        }
    }
}
