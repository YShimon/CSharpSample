//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CVLab">
//      Copyright(c) cv-lab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using DesignPattern.Factory;

    /// <summary>
    /// Begging of Assembly
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
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

                // Sample Codeの呼び出しと実行
                var sample = SampleFactory.Instance.Create(sectionNo: sectionNo);
                sample.Do(exampleNo: exampleNo);

                // Temporary Sample Code
                TmpTestCode();
            }
            catch
            {
                Console.WriteLine("Program Unsuccessfuly Finished");
            }
        }

        /// <summary>
        /// 一時的なサンプルコード（いづれ削除）
        /// </summary>
        private static void TmpTestCode()
        {
            // Linq to Objectサンプル
            // X. Linq to Object(Linqを取り扱っている章は、4.3)
            // LinqSampleBehavior001.SampleData001_BasicBehaviorOfLinq();

            //// コマンドパターンサンプル
            // var receiver = new ConcreateReceiver();
            // var invoker = new Invoker();
            // var commands = new ICVLCommand[5];
            // for (int i = 0; i < commands.Length; i++)
            // {
            //    commands[i] = new ConcreateCommandA(i);
            //    commands[i].SetReciever(receiver);
            //    invoker.AddCommand(commands[i]);
            // }

            // invoker.Execute();
            // invoker.UndoCommand();
            // invoker.Execute();
        }
    }
}
