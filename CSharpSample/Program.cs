//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CVLab">
//      Copyright(c) cv-lab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample
{
    using System;
    using DesignPattern.Factory;

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

                int.TryParse(args[0], out int sectionNo);
                int.TryParse(args[1], out int exampleNo);

                // Sample Codeの呼び出しと実行
                var sample = SampleFactory.Instance.Create(sectionNo: sectionNo);
                sample.Do(exampleNo: exampleNo);
            }
            catch
            {
                Console.WriteLine("Program Unsuccessfuly Finished");
            }
        }
    }
}
