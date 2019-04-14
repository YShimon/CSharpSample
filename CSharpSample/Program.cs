using System;
using CSharpSample.DesignPattern.Factory;

namespace CSharpSample
{
    /// <summary>
    /// Main Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main関数（ここからプログラムが開始する）
        /// </summary>
        /// <param name="args">Program Arguments</param>
        public static void Main(string[] args)
        {
            // Unhandled Exceptionのハンドラ登録
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // 起動引数確認
            if (args.Length != 2) { throw new Exception("引数を確認して下さい"); }
            int.TryParse(args[0], out int sectionNo);
            int.TryParse(args[1], out int exampleNo);

            // Sample Codeの呼び出しと実行
            var sample = SampleFactory.Instance.Create(sectionNo: sectionNo);
            sample.Do(exampleNo: exampleNo);
        }

        /// <summary>
        /// UnhandledException例外ハンドラ
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("[Unhandled Exception]Program Unsuccessfuly Finished");
        }
    }
}
