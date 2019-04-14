using System;
using CSharpSample.Common.Types;
using CSharpSample.DesignPattern.Factory;

namespace CSharpSample.SampleCode
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public class DependancyProperties : ISamplePractitioner
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private DependancyProperties() { }

        /// <summary>
        /// 唯一のインスタンス
        /// </summary>
        private static DependancyProperties Instance { get; } = new DependancyProperties();

        /// <summary>
        /// Instatnce取得
        /// </summary>
        /// <returns>DependancyPropertiesクラスのインスタンス</returns>
        public static DependancyProperties GetInstance() => Instance;

        /// <summary>
        /// サンプルコードを実行
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
        /// サンプル１
        /// </summary>
        private void Sample01()
        {
            // Childrenプロパティの使用
            var p1 = new Person();
            var p2 = new Person();

            p1.Children.Add(new Person());
            p2.Children.Add(new Person());

            Console.WriteLine("p1.Children.Count = {0}", p1.Children.Count);
            Console.WriteLine("p2.Children.Count = {0}", p2.Children.Count);
        }
    }
}
