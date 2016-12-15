//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CVLab">
//      Copyright(c) CVLab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CSharpSample.DataFactory;

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
            // 1. Manage Program Flow
            var mpf = new ManagingProgramFlow();

            // Exp 1.1
            // mpf.MultithreadingAndAsynchronuous();

            // Exp 1.2
            // mpf.BackgroundThread();

            // Exp 1.3
            // mpf.ParameterizedThreadStart();

            // Exp 1.4
            // mpf.StoppingAThread();

            // Exp 1.5
            // mpf.StaticAttribute();

            // Exp 1.6
            // mpf.ThreadLocal();

            // Exp 1.7
            // mpf.ThreadPools();

            // Exp 1.8
            // mpf.NewTask();

            // Exp 1.9
            // mpf.TaskThatReturnValue();

            // Exp 1.10-11
            // mpf.TaskContinueWith();

            // Exp 1.12
            // mpf.AttachingChildTasksToParentTask();

            // Exp 1.13
            // mpf.TaskFactoryClass();

            // Exp 1.14
            // mpf.TaskWaitAll();

            // Exp 1.15
            // mpf.TaskWaitAny();

            // Exp 1.16
            // mpf.ParallelForAndForeach();

            // Exp 1.17
            // mpf.ParallelBreak();

            // Exp 1.18
            // mpf.SimpleExampleOfAsynchronousMethod();

            // Exp 1.19 20 21 is skipped

            // Exp 1.22/23
            // mpf.AsParallel();

            // Exp 1.24
            mpf.AsParallelAsOrdered();

            // 一時的にコメントアウト。
            // TODO;引数で動作を変更するようにする
            // X. Linq to Object
            // LinqSampleBehavior001.SampleData001_BasicBehaviorOfLinq();
        }
    }
}
