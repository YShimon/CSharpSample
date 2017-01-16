//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CVLab">
//      Copyright(c) cv-lab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using DesignPattern.Factory;
    using DesignPattern.Command;
    using CVL.Extentions;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    /// <summary>
    /// Begging of Assembly
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args">Program Arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2) { throw new Exception(); }

                int sectionNo = 0;
                int exampleNo = 0;
                int.TryParse(args[0], out sectionNo);
                int.TryParse(args[1], out exampleNo);

                // ----------
                // 1.ManagingProgramFlow
                // ----------
                var sample = SampleFactory.Create(sectionNo: sectionNo);
                sample.Do(exampleNo: exampleNo);

                // 一時的にコメントアウト。
                // TODO;引数で動作を変更するようにする
                // X. Linq to Object(Linqを取り扱っている章は、4.3)
                // LinqSampleBehavior001.SampleData001_BasicBehaviorOfLinq();

                var receiver = new ConcreateReceiver();
                var invoker = new Invoker();
                var commands = new ICVLCommand[5];
                for (int i = 0; i < commands.Length; i++)
                {
                    commands[i] = new ConcreateCommandA(i);
                    commands[i].SetReciever(receiver);
                    invoker.AddCommand(commands[i]);
                }

                invoker.Execute();
                invoker.UndoCommand();
                invoker.Execute();

                // DataBaseへの接続は、Factoryの5を使う
                // SQL Serverへの接続コードを一旦こちらに記載
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
                        sampleDBSettings[key] = value;
                    }
                }

                connectionString = connectionString.Replace("$(ServerName)", sampleDBSettings["ServerName"]);
                connectionString = connectionString.Replace("$(DBName)", sampleDBSettings["DBName"]);
                connectionString = connectionString.Replace("$(UserName)", sampleDBSettings["UserName"]);
                connectionString = connectionString.Replace("$(Password)", sampleDBSettings["Password"]);

                // SQL Serverに接続
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                // SELECT文を設定します。
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
            catch
            {
                Console.WriteLine("Program Unsuccessfuly Finished");
            }
        }
    }
}
