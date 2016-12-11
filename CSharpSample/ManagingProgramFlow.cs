﻿//-----------------------------------------------------------------------
// <copyright file="ManagingProgramFlow.cs" company="CVLab">
//      Copyright(c) CVLab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using CVL.Extentions;

    /// <summary>
    /// サブスレッド
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public class ManagingProgramFlow
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ManagingProgramFlow() { }

        /// <summary>
        /// Example 1.1 マルチスレッドの例
        /// </summary>
        public void MultithreadingAndAsynchronuous()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            Enumerable.Range(0, 30).ForEach(x =>
            {
                Console.WriteLine($"Main Thread Do Some Work.{x}");
                Thread.Sleep(0);
            });

            t.Join();
        }

        /// <summary>
        /// Example 1.2 バックグラウンドスレッドの例
        /// </summary>
        public void BackgroundThread()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));

            // IsBackground = trueの場合、スレッドは、バックグランドで処理される
            // IsBackground = falseの場合、スレッドは、フォアグランドで処理される
            t.IsBackground = false;
            t.Start();
        }

        /// <summary>
        /// Example 1.3 スレッドにパラメータを渡す例
        /// </summary>
        public void ParameterizedThreadStart()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(10);
            t.Join();
        }

        /// <summary>
        /// 30回コンソールに文字列を表示するサブスレッド
        /// </summary>
        private void ThreadMethod()
        {
            Enumerable.Range(0, 30).ForEach(x =>
            {
                Console.WriteLine($"ThreadProc{x}");
                Thread.Sleep(0);
            });
        }

        /// <summary>
        /// 指定回数コンソールに文字列を表示するサブスレッド
        /// </summary>
        /// <param name="o"></param>
        private void ThreadMethod(object o = null)
        {
            int numWriteLine = (int)o;
            Enumerable.Range(0, numWriteLine).ForEach(x =>
            {
                Console.WriteLine($"ThreadProc{x}");
                Thread.Sleep(0);
            });
        }
    }
}
