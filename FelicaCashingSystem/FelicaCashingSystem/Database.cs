using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;
using System.Data;
using System.IO;

namespace FelicaCashingSystem
{
    // データベース
    public class Database
    {
        private static object lockDb         = new object();
        private        object lockInMemoryDb = new object();

        private readonly string connectionString;
        private readonly SQLiteConnection inMemoryDb;

        public static string FileName = Application.ProductName + ".db";

        public Database()
        {
            this.connectionString =
                "Data Source=" + FileName + "; Version=3; UseUTF16Encoding=True";

            // インメモリデータベースの処理
            this.inMemoryDb = new SQLiteConnection("Data Source=:memory:");
            this.inMemoryDb.Open();

            // テーブルを作成する
            this.CreateTable();

            // ユーザー一覧をキャッシュする
            this.CashUserList();
        }

        protected SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(this.connectionString);
        }

        public void CopyTo(string folderPath)
        {
            var dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            var backupFileName = dateTime + "_";
#if DEBUG
            backupFileName += "DEBUG_";
#endif
            backupFileName += Database.FileName;

            try
            {
                lock (Database.lockDb)
                {
                    File.Copy(
                        Database.FileName,
                        Path.Combine(folderPath, backupFileName)
                        );
                }
            }
            catch (Exception) { }
        }

        private void CreateTable()
        {
            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    this.NonQuery(conn,
                        "CREATE TABLE IF NOT EXISTS user (" +
                            "uid   TEXT    PRIMARY KEY," +
                            "name  TEXT    NOT NULL UNIQUE," +
                            "money INTEGER NOT NULL DEFAULT 0," +
                            "admin INTEGER NOT NULL DEFAULT 0," +
                            "mail  TEXT, " +
                            "dormitory    INTEGER NOT NULL DEFAULT 0, " +
                            "phone_number TEXT, " +
                            "room         TEXT " +
                        ");");

                    this.NonQuery(conn,
                        "CREATE TABLE IF NOT EXISTS log (" +
                            "uid     TEXT NOT NULL," +
                            "action  TEXT NOT NULL," +
                            "content TEXT DEFAULT ''," +
                            "date    TEXT NOT NULL" +
                        ");");

                    this.NonQuery(conn,
                        "CREATE TABLE IF NOT EXISTS bind (" +
                            "parent_uid TEXT NOT NULL," +
                            "child_uid  TEXT NOT NULL PRIMARY KEY" +
                        ");");

                    this.NonQuery(conn,
                        "CREATE VIEW if not exists statistics_cashing as " +
                            "select strftime(\"%Y-%m\", date) as date, sum(content) as sum, uid " +
                            "from log " +
                            "where action = \"AddCashing\" or action = \"BuyOrCashing\" " +
                            "group by strftime(\"%Y-%m\", date), uid;");

                    conn.Close();
                }
            }

            lock (lockInMemoryDb)
            {
                // インメモリデータベースの処理
                this.NonQuery(this.inMemoryDb,
                    "CREATE TABLE IF NOT EXISTS user (" +
                        "uid   TEXT    PRIMARY KEY," +
                        "name  TEXT    NOT NULL UNIQUE," +
                        "money INTEGER DEFAULT 0," +
                        "admin INTEGER NOT NULL DEFAULT 0," +
                        "mail  TEXT, " +
                        "dormitory    INTEGER DEFAULT 0, " +
                        "phone_number TEXT, " +
                        "room         TEXT " +
                    ");");

                this.NonQuery(this.inMemoryDb,
                    "CREATE TABLE IF NOT EXISTS bind (" +
                        "parent_uid TEXT NOT NULL," +
                        "child_uid  TEXT NOT NULL PRIMARY KEY" +
                    ");");
            }
        }


        public User GetUser(string uid)
        {
            string realUid = uid;
            User user = null;

            // 関連付けが存在するか調べる
            lock (lockInMemoryDb)
            {
                using (
                    var reader = this.Select(this.inMemoryDb,
                        "SELECT parent_uid " +
                        "FROM   bind " +
                        "WHERE  child_uid = '" + uid + "';"
                        )
                    )
                {
                    if (reader.Read())
                    {
                        uid = reader["parent_uid"].ToString();
                    }
                }

                using (
                    var reader = this.Select(this.inMemoryDb,
                        "SELECT name, money, admin, mail, dormitory, phone_number, room " +
                        "FROM user " +
                        "WHERE uid = '" + uid + "';"
                        )
                    )
                {
                    if (reader.Read())
                    {
                        user = new User(
                            uid,
                            realUid,
                            reader["name"].ToString(),
                            reader["money"].ToString(),
                            reader["admin"].ToString(),
                            reader["mail"].ToString(),
                            reader["dormitory"].ToString(),
                            reader["phone_number"].ToString(),
                            reader["room"].ToString()

                            );
                    }
                }
            }

            

            // ログを追加
            if (user != null)
            {
                this.AddLogAsync(uid, "GetUser", user.Name + "," + user.Money);
            }

            // ユーザーが存在しない場合
            else
            {
                this.AddLogAsync(uid, "GetUser", ",0");
            }

            return user;
        }

        public bool IsUserNameUnique(string name)
        {
            bool is_unique = false;

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    var command = new SQLiteCommand(conn);

                    command.CommandText =
                        "SELECT * " +
                        "FROM user " +
                        "WHERE name = '" + name + "'";

                    using (var reader = command.ExecuteReader())
                    {
                        // 結果セットが一行も存在しない場合
                        if (!reader.Read())
                        {
                            is_unique = true;
                        }
                    }

                    conn.Close();
                }
            }

            return is_unique;
        }

        public bool AddUser(string uid, string name, string mail)
        {
            bool result = false;

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    // ユーザーを追加する
                    int count = this.Insert(
                        conn,
                        "INSERT INTO user " +
                        "VALUES (?, ?, ?, ?, ?, ?, ?, ?);",
                        uid, name, 0, 0, mail, false, "", ""
                        );

                    // 成功した場合、ログを追加する
                    if (count == 1)
                    {
                        this.CashUserList();

                        if (this.AddLog(conn, uid, "AddUser", name))
                        {
                            result = true;
                        }
                    }

                    conn.Close();
                }
            }

            return result;
        }

        public bool Rename(string uid, string newName)
        {
            var result = false;

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    using (
                        // ユーザー名を取得
                        var reader = this.Select(conn,
                            "SELECT name " +
                            "FROM   user " +
                            "WHERE  uid = '" + uid + "';"
                            )
                        )
                    {
                        // ユーザー名が取得できた場合
                        if (reader.Read())
                        {
                            string oldName = reader["name"].ToString();

                            int count = this.Update(conn,
                               "UPDATE user " +
                               "SET name = '" + newName + "' " +
                               "WHERE uid = '" + uid + "';"
                               );

                            this.CashUserList();

                            if (count == 1)
                            {
                                if (this.AddLog(conn, uid, "Rename", oldName + "," + newName))
                                {
                                    result = true;
                                }
                            }
                        }
                    }

                    conn.Close();
                }
            }

            return result;
        }

        public bool UpdateUser(User user)
        {
            var result = false;

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    // name, money, admin, mail, dormitory, phone_number, room 
                    int count = this.Update(conn,
                        "UPDATE user " +
                        "SET mail = ?, dormitory = ?, phone_number = ?, room = ? " +
                        "WHERE uid = '" + user.Uid + "';",
                        user.Mail, user.IsDormitory ? 1 : 0, user.PhoneNumber, user.RoomNo
                        );

                    this.CashUserList();

                    if (count == 1)
                    {
                        if (this.AddLog(conn, user.Uid, "UpdateUser", user.Name))
                        {
                            result = true;
                        }
                    }

                    conn.Close();
                }
            }

            return result;
        }

        // 強制徴収
        public bool ForceCashing(string uid, int cashingMoney, string adminUid)
        {
            return this.BuyOrCashing(uid, cashingMoney, adminUid);
        }

        // 購入・借用
        public bool BuyOrCashing(string uid, int buyOrCashingMoney, string adminUid = null)
        {
            bool result = false;

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    var count = this.Update(conn,
                        "UPDATE user " +
                        "SET money = ((" +
                            "SELECT money " +
                            "FROM user " +
                            "WHERE uid = '" + uid + "') - " + buyOrCashingMoney + ")" +
                        "WHERE uid = '" + uid + "';");

                    if (count == 1)
                    {
                        // 金額データが更新されたため、ユーザーデータをキャッシュし直す
                        this.CashUserList();

                        // 更新成功
                        result = true;
                    }

                    conn.Close();
                }
            }

            // ログを書き込む
            if (adminUid != null)
            {
                // 強制徴収
                this.AddLogAsync(uid, "ForceCashing", buyOrCashingMoney.ToString() + "," + adminUid);
            }
            else
            {
                this.AddLogAsync(uid, "BuyOrCashing", buyOrCashingMoney.ToString());
            }

            return result;
        }

        public List<Log> GetLog(string uid)
        {
            var log = new List<Log>();

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    using (
                        var reader = this.Select(conn,
                            "SELECT log.uid, log.action, log.content, log.date, user.name " +
                            "FROM   log " +
                            "INNER JOIN user ON log.uid = user.uid " +
                            "ORDER BY log.date DESC " +
                            "LIMIT 100"
                            )
                        )
                    {

                        while (reader.Read())
                        {
                            log.Add(new Log(
                                reader["uid"].ToString(),
                                reader["action"].ToString(),
                                reader["content"].ToString(),
                                reader["date"].ToString(),
                                reader["name"].ToString()
                                ));
                        }
                    }

                    if (!this.AddLog(conn, uid, "GetLog", log.Count.ToString()))
                    {
                        log = null;
                    }

                    conn.Close();
                }
            }

            return log;
        }

        public DataTable GetUserList(string uid)
        {
            var users = new DataTable();

            users.Columns.Add("UID", Type.GetType("System.String"));
            users.Columns.Add("名前", Type.GetType("System.String"));
            users.Columns.Add("金額", Type.GetType("System.Int32"));
            users.Columns.Add("メールアドレス", Type.GetType("System.String"));

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    using (
                        var reader = this.Select(conn,
                            "SELECT uid, name, money, mail " +
                            "FROM   user "
                            )
                        )
                    {

                        while (reader.Read())
                        {
                            users.Rows.Add(
                                reader["uid"].ToString(),
                                reader["name"].ToString(),
                                reader["money"].ToString(),
                                reader["mail"].ToString()
                                );
                        }
                    }

                    if (!this.AddLog(conn, uid, "GetUserList", users.Rows.Count.ToString()))
                    {
                        users = null;
                    }

                    conn.Close();
                }
            }

            return users;
        }
        
        public bool RepayOrChargeMoney(string uid, int repayMoney)
        {
            bool result = false;

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    int count = this.Update(conn,
                        "UPDATE user " +
                        "SET money = ((" +
                            "SELECT money " +
                            "FROM   user " +
                            "WHERE uid = '" + uid + "') + " + repayMoney.ToString() + ") " +
                        "WHERE uid = '" + uid + "';"
                        );

                    if (count == 1)
                    {
                        this.CashUserList();

                  //      if (this.AddLog(conn, uid, "RepayMoney", repayMoney.ToString()))
                        if (this.AddLog(conn, uid, "RepayOrChargeMoney", repayMoney.ToString()))
                        {
                            result = true;
                        }
                    }

                    conn.Close();
                }
            }

            return result;
        }

        // 関連付けを追加する
        public bool AssociationAdd(string parentUid, string childUid)
        {
            bool result = false;

            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    var count = this.Insert(conn,
                        "INSERT INTO bind " +
                        "VALUES (?, ?);",
                        parentUid, childUid);

                    if (count == 1)
                    {
                        this.CashUserList();
                        result = true;
                    }

                    conn.Close();
                }
            }

            // ログを非同期で追加
            this.AddLogAsync(parentUid, "AssociationAdd", childUid);

            return result;
        }

        public DataTable[] GetStatisticsCashing(string uid)
        {

            var dict = new Dictionary<string, int>();

            // データベースから情報を取得
            lock (lockDb)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    var reader = this.Select(conn,
                        "SELECT date, sum " +
                        "FROM   statistics_cashing " +
                        "WHERE  uid = ?",
                        uid
                        );

                    while (reader.Read())
                    {
                        dict.Add(
                            reader["date"].ToString(),
                            int.Parse(reader["sum"].ToString())
                            );
                    }

                    reader.Dispose();
                    conn.Close();
                }
            }

            // 日付の最小値を取得
            string min_str = dict.Keys.Min();
            int[] min = min_str.ToDateIntArray();

            // 現在の日付を取得
            var current   = new int[] { DateTime.Today.Year, DateTime.Today.Month };


            while (current[0] > min[0] || (current[0] == min[0] && current[1] >= min[1]))
            {
                // 12ヶ月単位で処理
                for (int i = 0; i < 12; ++i)
                {
                    string key = current.ToDateString();

                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, 0);
                    }

                    // インクリメント処理
                    current = current.PrevDateIntArray();
                }
            }

            // 辞書のキー一覧を取得
            var keys_list = dict.Keys.ToList();
            keys_list.Sort();

            var keys = new Queue<string>(keys_list);

            // 戻り値のテーブルを作成
            var table = new DataTable[dict.Count / 12];

            for (int i = 0; i < dict.Count / 12; ++i)
            {
                table[i] = new DataTable();
                table[i].Columns.Add("月", Type.GetType("System.String"));
                table[i].Columns.Add("金額", Type.GetType("System.Int32"));

                for (int j = 0; j < 12; ++j)
                {
                    var key = keys.Dequeue();
                    table[i].Rows.Add(
                        key,
                        dict[key]
                        );
                }
            }

            return table;
        }

        private bool AddLog(SQLiteConnection conn, string uid, string action, string content)
        {
            var count = this.Insert(conn,
                "INSERT INTO log " +
                "VALUES ('" + uid + "', '" + action + "', '" +
                    content + "', DATETIME('NOW', 'LOCALTIME'));");

            if (count == 1)
            {
                return true;
            }
            
            return false;
        }

        // ログを追加 (非同期)
        private void AddLogAsync(string uid, string action, string content)
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)delegate(object arg)
            {
                lock (lockDb)
                {
                    using (var conn = this.GetConnection())
                    {
                        conn.Open();

                        this.AddLog(
                            conn,
                            uid,
                            action,
                            content
                        );
                        
                        conn.Close();
                    }
                }
            });
        }

        // ユーザーテーブルをインメモリデータベースにキャッシュする
        private void CashUserList()
        {
            lock (lockInMemoryDb)
                // lockDb は lock しないこと (lock の中から現状呼ばれているため)
            {
                using (var conn = this.GetConnection())
                {
                    conn.Open();

                    // ユーザー一覧
                    using (
                        var reader = this.Select(conn,
                            "SELECT uid, name, money, admin, mail, dormitory, phone_number, room  " +
                            "FROM   user "
                            )
                        )
                    {
                        // すべてのデータを削除
                        using (var trans = this.inMemoryDb.BeginTransaction())
                        {
                            this.Delete(this.inMemoryDb, "DELETE FROM user;");
                            trans.Commit();
                        }

                        using (var trans = this.inMemoryDb.BeginTransaction())
                        {
                            while (reader.Read())
                            {
                                this.Insert(this.inMemoryDb,
                                    "INSERT INTO user " +
                                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?);",
                                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]
                                    );
                            }

                            trans.Commit();
                        }
                    }

                    // 関連付け
                    using (
                        var reader = this.Select(conn,
                            "SELECT parent_uid, child_uid " +
                            "FROM   bind;"
                            )
                        )
                    {
                        // すべてのデータを削除
                        using (var trans = this.inMemoryDb.BeginTransaction())
                        {
                            this.Delete(this.inMemoryDb, "DELETE FROM bind;");
                            trans.Commit();
                        }

                        // すべてのデータを追加
                        using (var trans = this.inMemoryDb.BeginTransaction())
                        {
                            while (reader.Read())
                            {
                                this.Insert(this.inMemoryDb,
                                    "INSERT INTO bind " +
                                    "VALUES (" +
                                        "'" + reader["parent_uid"].ToString() + "'," +
                                        "'" + reader["child_uid"].ToString() + "'" +
                                        ");"
                                    );
                            }

                            trans.Commit();
                        }
                    }

                    conn.Close();
                }
            }
        }

        private int NonQuery(string query)
        {
            int count;

            using (var conn = this.GetConnection())
            {
                conn.Open();

                var command = new SQLiteCommand(conn);

                command.CommandText = query;
                count = command.ExecuteNonQuery();

                conn.Close();
            }

            return count;
        }

        private int NonQuery(SQLiteConnection conn, string query, params object[] args)
        {
            var command = new SQLiteCommand(conn);

            command.CommandText = query;

            foreach (var arg in args)
            {
                var parameter = command.CreateParameter();
                parameter.Value = arg;
                command.Parameters.Add(parameter);
            }

            return command.ExecuteNonQuery();
        }

        private int Update(string query)
        {
            return this.NonQuery(query);
        }

        private int Update(SQLiteConnection conn, string query, params object[] args)
        {
            return this.NonQuery(conn, query, args);
        }

        private int Insert(string query)
        {
            return this.NonQuery(query);
        }

        private int Insert(SQLiteConnection conn, string query, params object[] args)
        {
            return this.NonQuery(conn, query, args);
        }

        private int Delete(SQLiteConnection conn, string query)
        {
            return this.NonQuery(conn, query);
        }

        private SQLiteDataReader Select(
            SQLiteConnection conn,
            string query,
            params object[] args
            )
        {
            var command = new SQLiteCommand(query, conn);

            foreach (var arg in args)
            {
                var parameter = command.CreateParameter();
                parameter.Value = arg;
                command.Parameters.Add(parameter);
            }

            return command.ExecuteReader();
        }
    }

    

    public class Log
    {
        public string Name { private set; get; }
        public string Action { private set; get; }
        public string Content { private set; get; }
        public string Date { private set; get; }

        /// <summary>
        /// アカウントの代表 UID
        /// </summary>
        public string Uid { private set; get; }

        /// <summary>
        /// 現在ログインしている実際の UID
        /// </summary>
        public string RealUid { private set; get; }

        public Log(string uid, string action, string content, string date, string name)
        {
            this.Uid = uid;
            this.Action = action;
            this.Content = content;
            this.Date = date;
            this.Name = name;
        }
    }

}