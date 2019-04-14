using System;
using CSharpSample.SampleCode;

namespace CSharpSample.Common.Types
{
    /// <summary>
    /// ジェネリックテンプレートサンプルクラス01
    /// </summary>
    /// <typeparam name="TI">入力用クラス</typeparam>
    /// <typeparam name="TO">出力用クラス</typeparam>
    public class GenericsInterfaceSample02<TI, TO> : IGenerics<TI, TO>
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private GenericsInterfaceSample02<TI, TO> Instance { get; set; } = new GenericsInterfaceSample02<TI, TO>();

        /// <summary>
        /// インスタンスを取得
        /// </summary>
        /// <returns>GenericsInterfaceSample02のインスタンス</returns>
        public GenericsInterfaceSample02<TI, TO> GetInstatnce()
        {
            if (Instance == null)
            {
                Instance = new GenericsInterfaceSample02<TI, TO>();
            }

            return Instance;
        }

        /// <summary>
        /// インターフェイスの実装
        /// </summary>
        /// <param name="input">入力用クラス</param>
        /// <returns>出力用クラス</returns>
        public TO DoSomething(TI input)
        {
            Console.WriteLine($"class name of TI : {typeof(TI).Name}");
            Console.WriteLine($"class name of TO : {typeof(TO).Name}");
            return default(TO);
        }
    }
}
