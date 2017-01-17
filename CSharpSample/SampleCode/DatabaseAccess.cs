using CSharpSample.DesignPattern.Factory;
using CVL.Extentions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpSample.SampleCode
{
    public class DatabaseAccess : ISamplePractitioner
    {
        /// <summary>
        /// Sampleの実行
        /// </summary>
        /// <param name="exampleNo">例番号</param>
        /// <returns>実行結果</returns>
        public bool Do(int exampleNo)
        {
            switch (exampleNo)
            {
                case 1:
                    AccessSQLServer();
                    break;
                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// SQL Serverへのアクセス
        /// </summary>
        public void AccessSQLServer()
        {
#if false
            // 接続文字列取得（パスワード等を記載することになるので、文字列を置換する）
            var connectionString = ConfigurationManager.ConnectionStrings["SampleDB"].ConnectionString;
            SqlCommand command = new SqlCommand();

            // 接続文字列置換：接続文字列を完成させるには、SampleDBSettins.txtの内容を読み込み変更する必要がある。
            Dictionary<string, string> sampleDBSettings = new Dictionary<string, string>
                {
                    { "ServerName", string.Empty },
                    { "DBName", string.Empty },
                    { "UserName", string.Empty },
                    { "Password", string.Empty },
                };

            using (StreamReader sr = new StreamReader("SampleDBSettings.txt", Encoding.GetEncoding("Shift_JIS")))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    var key = string.Empty;
                    var value = string.Empty;

                    sampleDBSettings.ForEach(x =>
                    {
                        if (line.IndexOf(x.Key) >= 0)
                        {
                            key = (line.Split('='))[0];
                            value = (line.Split('='))[1];
                            return;
                        }
                    });

                    if(key != string.Empty)
                    {
                        sampleDBSettings[key] = value;
                    }
                }
            }

            // app.configから読み込んだ接続文字列を置換する
            connectionString = connectionString.Replace("$(ServerName)", sampleDBSettings["ServerName"]);
            connectionString = connectionString.Replace("$(DBName)", sampleDBSettings["DBName"]);
            connectionString = connectionString.Replace("$(UserName)", sampleDBSettings["UserName"]);
            connectionString = connectionString.Replace("$(Password)", sampleDBSettings["Password"]);
#else
            var connectionString = GetConnectionString();
#endif

            // SQL Serverに接続
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            // SELECT文を設定します。
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM HouseholdAccount";
            command.Connection = connection;

            // SQLを実行します。
            SqlDataReader reader = command.ExecuteReader();

            // 結果を表示します。
            while (reader.Read())
            {
                var id = (int)reader.GetValue(0);
                var date = (DateTime)reader.GetValue(1);
                var item = (string)reader.GetValue(2);

                Console.WriteLine("Id:" + id + " 日付:" + date + " 品目:" + item);
            }

            // SQL Serverへの接続を閉じる
            connection.Close();
        }

        /// <summary>
        /// SQL Serverへの接続文字列を取得する
        /// </summary>
        /// <returns>接続文字列</returns>
        private string GetConnectionString()
        {
            // 接続文字列取得（パスワード等を記載することになるので、文字列を置換する）
            var connection = ConfigurationManager.ConnectionStrings["SampleDB"].ConnectionString;
            SqlCommand command = new SqlCommand();

            // 接続文字列置換：接続文字列を完成させるには、SampleDBSettins.txtの内容を読み込み変更する必要がある。
            Dictionary<string, string> sampleDBSettings = new Dictionary<string, string>
                {
                    { "ServerName", string.Empty },
                    { "DBName", string.Empty },
                    { "UserName", string.Empty },
                    { "Password", string.Empty },
                };

            using (StreamReader sr = new StreamReader("SampleDBSettings.txt", Encoding.GetEncoding("Shift_JIS")))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    var key = string.Empty;
                    var value = string.Empty;

                    sampleDBSettings.ForEach(x =>
                    {
                        if (line.IndexOf(x.Key) >= 0)
                        {
                            key = (line.Split('='))[0];
                            value = (line.Split('='))[1];
                            return;
                        }
                    });

                    if (key != string.Empty)
                    {
                        sampleDBSettings[key] = value;
                    }
                }
            }

            // app.configから読み込んだ接続文字列を置換する
            connection = connection.Replace("$(ServerName)", sampleDBSettings["ServerName"]);
            connection = connection.Replace("$(DBName)", sampleDBSettings["DBName"]);
            connection = connection.Replace("$(UserName)", sampleDBSettings["UserName"]);
            connection = connection.Replace("$(Password)", sampleDBSettings["Password"]);

            return connection;

        }
    }
}