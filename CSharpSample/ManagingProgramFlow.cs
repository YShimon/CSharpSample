//-----------------------------------------------------------------------
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
        /// スレッド内のLocal Field
        /// </summary>
        [ThreadStatic]
        private static int field;

        /// <summary>
        /// スレッド内のLocal Field
        /// </summary>
        private static ThreadLocal<int> threadLocalField = new ThreadLocal<int>(() => { return Thread.CurrentThread.ManagedThreadId; });

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
        /// Example 1.4 スレッドの停止
        /// </summary>
        public void StoppingAThread()
        {
            bool stopped = false;

            Thread t = new Thread(new ThreadStart(() => 
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(500);
                }
            }));

            t.Start();

            Console.WriteLine("Please any key to exit");
            Console.ReadKey();

            stopped = true;
            t.Join();
        }

        /// <summary>
        /// Example 1.5 Static Attributeの使用例
        /// ラムダ式を使ったスレッドで、内部で利用するフィールドが共有されない設定
        /// </summary>
        public void StaticAttribute()
        {
            new Thread(() => 
            {
                Enumerable.Range(0, 10).ForEach(x => 
                {
                    field++;
                    Console.WriteLine($"Thread A : field={field}");
                });
            }).Start();

            new Thread(() => 
            {
                Enumerable.Range(0, 10).ForEach(x => 
                {
                    field++;
                    Console.WriteLine($"Thread B : field={field}");
                });
            }).Start();

            Console.ReadKey();
        }

        /// <summary>
        /// Example 1.6 ThreadLocalの使用例
        /// </summary>
        public void ThreadLocal()
        {
            new Thread(() => 
            {
                Enumerable.Range(0, threadLocalField.Value).ForEach(x => 
                {
                    Console.WriteLine($"Thread A : field={x}");
                });
            }).Start();

            new Thread(() => 
            {
                Enumerable.Range(0, threadLocalField.Value).ForEach(x => 
                {
                    Console.WriteLine($"Thread B : field={x}");
                });
            }).Start();

            Console.ReadKey();
        }

        /// <summary>
        /// Example 1.7 ThreadPoolに処理を登録する例
        /// </summary>
        public void ThreadPools()
        {
            ThreadPool.QueueUserWorkItem((s) => 
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            Console.ReadLine();
        }

        /// <summary>
        /// Example 1.8 Taskの実行例
        /// </summary>
        public void NewTask()
        {
            Task t = Task.Run(() => 
            {
                Enumerable.Range(0, 40).ForEach(x => 
                {
                    Console.Write("*");
                });
                Console.WriteLine("");
            });

            t.Wait();
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
        /// <param name="numLoop">コンソールに表示する回数</param>
        private void ThreadMethod(object numLoop)
        {
            int numWriteLine = (int)numLoop;
            Enumerable.Range(0, numWriteLine).ForEach(x =>
            {
                Console.WriteLine($"ThreadProc{x}");
                Thread.Sleep(0);
            });
        }
    }
}
