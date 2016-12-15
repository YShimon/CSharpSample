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
                Console.WriteLine(string.Empty);
            });

            t.Wait();
        }

        /// <summary>
        /// Example 1.9 戻り値を持つTaskクラスの使用例
        /// </summary>
        public void TaskThatReturnValue()
        {
            Task<int> t = Task.Run(() => { return 1024; });
            Console.WriteLine($"結果:{t.Result}");
        }

        /// <summary>
        /// Example 1.10-11 Taskを継続する(Taskが成功した場合、失敗した場合の例)
        /// </summary>
        public void TaskContinueWith()
        {
            // 前段のTaskが成功したとこのみ実行される
            Task<int> t = Task.Run(() => { return 1024; });
            t.ContinueWith(
                _t => { Console.WriteLine($"Result:{_t.Result}"); },
                TaskContinuationOptions.OnlyOnRanToCompletion);

            // 前段のTaskでハンドルされない例外が発生した時のみ実行される
            Task t2 = Task.Run(() => { throw new Exception(); });
            t2.ContinueWith(
                _t => { Console.WriteLine($"Occured Exception"); },
               TaskContinuationOptions.OnlyOnFaulted);

            Console.ReadKey();
        }

        /// <summary>
        /// Example 1.12 子タスクを親タスクに関連付け
        /// </summary>
        public void AttachingChildTasksToParentTask()
        {
            Task<int[]> parent = Task.Run(() => 
            {
                var results = new int[3];

                new Task(() => { results[0] = 0; }, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => { results[1] = 1; }, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => { results[2] = 2; }, TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var finalTask = parent.ContinueWith(parentTask => 
            {
                parentTask.Result.ForEach(x => Console.WriteLine($"Parent Task Result is {x}"));
            });

            finalTask.Wait();
        }

        /// <summary>
        /// Example 1.13 Task Factoryの利用例
        /// </summary>
        public void TaskFactoryClass()
        {
            Task<int[]> parent = Task.Run(() =>
            {
                var results = new int[3];

                TaskFactory tf = new TaskFactory(
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

                return results;
            });

            var finalTask = parent.ContinueWith(parentTask => 
            {
                parentTask.Result.ForEach(x => Console.WriteLine($"Parent Task Result is {x}"));
            });

            finalTask.Wait();
        }

        /// <summary>
        /// Example 1.14 Task.WaitAllの利用例
        /// </summary>
        public void TaskWaitAll()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() => 
            {
                Thread.Sleep(500);
                Console.WriteLine("Thread A:1");
                return 1;
            });
            tasks[1] = Task.Run(() => 
            {
                Thread.Sleep(500);
                Console.WriteLine("Thread B:2");
                return 2;
            });
            tasks[2] = Task.Run(() => 
            {
                Thread.Sleep(500);
                Console.WriteLine("Thread C:3");
                return 3;
            });

            Task.WaitAll(tasks);
        }

        /// <summary>
        /// Example 1.15 Task.WaitAnyの利用例
        /// </summary>
        public void TaskWaitAny()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });

            while(tasks.Length > 0)
            {
                // WaitAnyは完了したTaskのindexを戻す
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];

                Console.WriteLine($"Completed Task Result:{completedTask.Result}");

                var tmp = tasks.ToList();
                tmp.RemoveAt(i);
                tasks = tmp.ToArray();
            }
        }

        /// <summary>
        /// Example 1.16 Parallel.ForとForeachの利用例
        /// </summary>
        public void ParallelForAndForeach()
        {
            Console.WriteLine("Example Parallel.For()");
            Parallel.For(0, 10, x => 
            {
                Console.WriteLine($"Running {x}");
            });

            Console.WriteLine("Example Parallel.ForEach()");
            var range = Enumerable.Range(0, 10);
            Parallel.ForEach(range, x => 
            {
                Console.WriteLine($"Running {x}");
            });
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
