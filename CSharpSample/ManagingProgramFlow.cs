using CVL.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSample
{
    /// <summary>
    /// サブスレッド
    /// </summary>
    public class ManagingProgramFlow
    {
        private void ThreadMethod()
        {
            Enumerable.Range(0, 30).ForEach(x =>
            {
                Console.WriteLine($"ThreadProc{x}");
                Thread.Sleep(0);
            });
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ManagingProgramFlow() { }

        /// <summary>
        /// マルチスレッドのテスト
        /// ThreadMethodをサブスレッドとして動作させるテスト
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
    }
}
