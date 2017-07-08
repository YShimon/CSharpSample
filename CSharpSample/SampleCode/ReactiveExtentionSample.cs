using System;
using System.Reactive.Linq;
using CSharpSample.DesignPattern.Factory;

namespace CSharpSample.SampleCode
{
    /// <summary>
    /// Reactive Extentionsのサンプルクラス
    /// </summary>
    public class ReactiveExtentionSample : ISamplePractitioner
    {
        /// <summary>
        /// Singleton
        /// </summary>
        private static ReactiveExtentionSample Instance { get; set; } = new ReactiveExtentionSample();

        /// <summary>
        /// Singleton Instanceの取得
        /// </summary>
        /// <returns>ReactiveExtentionSampleのSingleton Instance</returns>
        public static ReactiveExtentionSample GetInstance() => Instance;

        /// <summary>
        /// Sample Codeを実行
        /// </summary>
        /// <param name="exampleNo">サンプル番号</param>
        /// <returns>実行ステータス</returns>
        public bool Do(int exampleNo)
        {
            switch (exampleNo)
            {
                case 1:
                    Sample01();
                    break;
                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Reactive Linqの利用例 Range/ForEachAsync
        /// </summary>
        private void Sample01()
        {
            Observable.Range(0, 10).ForEachAsync(x => { Console.WriteLine($"x = {x}"); });
        }
    }
}
