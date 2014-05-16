using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace FelicaCashingSystem
{
    static class Mail
    {
        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        // SMTP を使ってメールを送信する
        private static void Send(string to, string subject, string body)
        {
            // メールアドレスの形式を確認する
            if (!IsValidEmail(to))
            {
                return; // 不正なメールアドレス
            }

            // メールメッセージを作成する
            using (
                var msg = new MailMessage(
                Properties.Settings.Default.MailFrom,
                to,
                subject,
                body
                ))

            // SMTP クライアントを作成
            using(
                var sc = new SmtpClient()
                )
            {
                // サーバーの情報を設定する
                sc.Host = Properties.Settings.Default.SmtpHost; // ホスト名
                sc.Port = Properties.Settings.Default.SmtpPort; // ポート番号

                // ユーザー名とパスワード
                sc.Credentials = new NetworkCredential(
                    Properties.Settings.Default.SmtpUser,    // ユーザー名
                    Properties.Settings.Default.SmtpPassword // パスワード
                    );

                // SSL は使わない
                // 工科大の SSL 証明書は検証に失敗するので (自己証明書?)
                sc.EnableSsl = false;

                sc.Send(msg);
            }
        }

        // テンプレートを適応する
        static private string Template(
            string template_name,
            out string subject,
            object[] args
            )
        {
            string[] lines = File.ReadAllLines(
                Properties.Settings.Default.TemplateDirectory +
                    template_name +
                    Properties.Settings.Default.TemplateExtension,
                Encoding.UTF8
                );

            subject = lines[0];

            var plainText = string.Join("\r\n", lines, 1, lines.Length - 1);

            // テンプレートを適応
            return string.Format(plainText, args);
        }

        // 部費徴収
        static public void SendCollectClubDues(
            string to,
            string userName,
            string adminUserName,
            int moneySum,
            int clubDues
            )
        {
            string subject;

            // テンプレートを適応する
            string text = Template(
                "CollectClubDues",
                out subject,
                new object[] {
                    userName,
                    adminUserName,
                    clubDues.ToCommaStringAbs(),
                    moneySum.ToCommaString()
                }
                );
            
            // メールを送信
            Mail.Send(to, subject, text);
        }

        // 登録完了
        static public void RegisterComplete(
            string to,
            string userName
            )
        {
            string subject; // タイトル
            
            // テンプレートを適応する
            string text = Template(
                "RegisterComplete",
                out subject,
                new object[] { userName }
                );

            // メールを送信
            Mail.Send(to, subject, text);
        }

        // 支払い要求
        public static void SendRepayRequest(
            string to,
            string userName,
            string adminUserName,
            int moneySum
            )
        {
            string subject;

            // テンプレートを適応する
            string text = Template(
                "RepayRequest",
                out subject,
                new object[] {
                    userName,
                    adminUserName,
                    moneySum.ToCommaString()
                }
                );

            // メールを送信
            Mail.Send(to, subject, text);
        }
    }
}
