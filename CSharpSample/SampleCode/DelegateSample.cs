using System;
using System.Collections.Generic;
using System.Linq;
using CSharpSample.DesignPattern.Factory;
using CVL.Extentions;

namespace CSharpSample.SampleCode
{
    /// <summary>
    /// デリゲートのサンプルクラス
    /// </summary>
    public class DelegateSample : ISamplePractitioner
    {
        /// <summary>
        /// 引数int,戻り値intを持つデリゲート
        /// </summary>
        private Func<int, int> func01 = (x) => { return x * 2; };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private DelegateSample() { }

        /// <summary>
        /// 唯一のインスタンス
        /// </summary>
        private static DelegateSample Instance { get; set; } = new DelegateSample();

        /// <summary>
        /// Singleton Instatnce取得
        /// </summary>
        /// <returns>DelegateSampleクラスのインスタンス</returns>
        public static DelegateSample GetInstance() => Instance;

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
                    DelegateSample01();
                    break;

                case 2:
                    DelegateSample02();
                    break;

                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Func(int, int) 引数int, 戻り値intを持つデリゲートのサンプル
        /// </summary>
        private void DelegateSample01()
        {
            int seed = 3;

            // デリゲート(Func01)の利用例01
            // デリゲート(Func01)を実行
            var value01 = func01(seed);
            Console.WriteLine($"value : {value01}");

            // デリゲート(Func01)の利用例02
            // デリゲート(Func01)をメソッドに渡して利用する
            var value02 = MethodWithFunc(seed, func01: func01);
            Console.WriteLine($"value : {value02}");

            // デリゲート(Func01)の利用例03
            // デリゲート(Func01)をnullでメソッドに渡すと動作しない
            var value03 = MethodWithFunc(seed);
            Console.WriteLine($"value : {value03}");
        }

        /// <summary>
        /// デリゲートを引数に持つメソッドの例
        /// </summary>
        /// <param name="value">デリゲートに渡す値</param>
        /// <param name="func01">デリゲート</param>
        /// <returns>デリゲートの戻り値</returns>
        private int MethodWithFunc(int value, Func<int, int> func01 = null)
        {
            int answer = 0;

            if (func01 != null)
            {
                answer = func01(value);
            }

            return answer;
        }

        /// <summary>
        /// Delegateの用途　述語(Predicate)のサンプル
        /// </summary>
        private void DelegateSample02()
        {
            var array = new int[] { 1, 8, 4, 11, 8, 15, 12, 19 };

            // 偶数のみを取得
            var even = Select(array, BuildFunc(0));
            Console.WriteLine("偶数のみを取得");
            even.ForEach(x => { Console.WriteLine($" {x}"); });

            // 10より大きい値を取得
            var over10 = Select(array, BuildFunc(1));
            Console.WriteLine("10より大きい値を取得");
            over10.ForEach(x => { Console.WriteLine($" {x}"); });

            // 10より大きい値を取得(前段の例から書き方のみを変更)
            over10 = Select(array, x => { return x > 10; });
            Console.WriteLine("10より大きい値を取得");
            over10.ForEach(x => { Console.WriteLine($" {x}"); });

            // 10より大きく,15より小さい値を取得
            var between5to15 = Select(array, BuildFunc(2));
            Console.WriteLine("5より大きく15より小さい値を取得");
            between5to15.ForEach(x => { Console.WriteLine($" {x}"); });
        }

        /// <summary>
        /// Predicateの利用例：配列から指定条件に沿った配列を返却
        /// </summary>
        /// <param name="array">数値配列</param>
        /// <param name="predicate">述語(条件指定デリゲート)</param>
        /// <returns>述語(条件指定デリゲート)により選別されたコレクション</returns>
        private IEnumerable<int> Select(IEnumerable<int> array, Func<int, bool> predicate) => array.Where(x => predicate(x));

        /// <summary>
        /// 条件に沿ってコレクション生成
        /// </summary>
        /// <param name="type">コレクション種別(0:=偶数,1:=10より大きい…等)</param>
        /// <returns>コレクション</returns>
        private Func<int, bool> BuildFunc(int type)
        {
            Func<int, bool> func = null;

            switch (type)
            {
                case 0:
                    func = (x) => { return x % 2 == 0; };
                    break;
                case 1:
                    func = (x) => { return x > 10; };
                    break;
                case 2:
                    func = (x) => { return (x > 5) && (x < 15); };
                    break;
                default:
                    break;
            }

            return func;
        }
    }
}
