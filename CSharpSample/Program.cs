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

                var sample = SampleFactory.Create(sectionNo: sectionNo);
                sample.Do(exampleNo: exampleNo);

                // 一時的にコメントアウト。
                // TODO;引数で動作を変更するようにする
                // X. Linq to Object
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

                // -->> debug 臨時コード
                // ユーザ名・パスワード・サーバー名は、別途定義できるようにする。
                var connectionString = ConfigurationManager.ConnectionStrings["sqlsvr"].ConnectionString;
                SqlCommand command = new SqlCommand();

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

                connection.Close();
                // <<-- debug 臨時コード
            }
            catch
            {
                Console.WriteLine("Program Unsuccessfuly Finished");
            }
        }
    }
}
