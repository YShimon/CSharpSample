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
            mpf.MultithreadingAndAsynchronuousExp01_01();

            // 一時的にコメントアウト。
            // TODO;引数で動作を変更するようにする
            // X. Linq to Object
            // LinqSampleBehavior001.SampleData001_BasicBehaviorOfLinq();
        }
    }
}
