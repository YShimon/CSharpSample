using System;
using CSharpSample.SampleCode;

namespace CSharpSample.Common.Types
{
    /// <summary>
    /// ジェネリックテンプレートサンプルクラス01
    /// </summary>
    public class GenericsInterfaceSample01 : IGenerics<TypeIN, TypeOut>
    {
        /// <summary>
        /// クラスのインスタンス
        /// </summary>
        private GenericsInterfaceSample01 instance = null;

        /// <summary>
        /// インスタンス取得
        /// </summary>
        /// <returns>GenericsInterfaceSample01のインスタンス</returns>
        public GenericsInterfaceSample01 GetInstatnce()
        {
            if (instance == null)
            {
                instance = new GenericsInterfaceSample01();
            }

            return instance;
        }

        /// <summary>
        /// インターフェイスの実装
        /// </summary>
        /// <param name="input">入力データ</param>
        /// <returns>出力データ</returns>
        public TypeOut DoSomething(TypeIN input)
        {
            Console.WriteLine("GenericsInterface.DoSomething()");
            return new TypeOut();
        }
    }
}
