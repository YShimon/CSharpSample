using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSample.DesignPattern.Factory;

namespace CSharpSample.SampleCode
{
    /// <summary>
    /// ジェネリックインターフェイスのサンプル
    /// </summary>
    /// <typeparam name="TI">入力用クラス</typeparam>
    /// <typeparam name="TO">出力用クラス</typeparam>
    public interface IGenerics<TI, TO>
    {
        /// <summary>
        /// ジェネリックメソッドサンプル　
        /// </summary>
        /// <param name="input">入力データ</param>
        /// <returns>出力データ</returns>
        TO DoSomething(TI input);
    }

    /// <summary>
    /// Genericsサンプルで利用するクラス1(TypeIn:入力されるクラスとして用意)
    /// </summary>
    public class TypeIN
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TypeIN()
        {
            Console.WriteLine("Constructor : TypeIN");
        }
    }

    /// <summary>
    /// Genericsサンプルで利用するクラス1(TypeOut:出力されるくらすとして用意)
    /// </summary>
    public class TypeOut
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TypeOut()
        {
            Console.WriteLine("Constructor : TypeOut");
        }
    }

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

    /// <summary>
    /// ジェネリクスサンプルクラス
    /// </summary>
    public class GenericsSamples : ISamplePractitioner
    {
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
                    GenericsSample01();
                    break;
                case 2:
                    GenericsSample02();
                    break;
                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// サンプル01
        /// </summary>
        /// <remarks>クラス定義時既に型が決定している例</remarks>
        private void GenericsSample01()
        {
            var sample = new GenericsInterfaceSample01();
            var inParam = new TypeIN();
            var outParam = sample.DoSomething(inParam);
        }

        /// <summary>
        /// サンプル02
        /// </summary>
        /// <remarks>実行時に型を決定する例</remarks>
        private void GenericsSample02()
        {
            var sample = new GenericsInterfaceSample02<TypeIN, TypeOut>();
            var inParam = new TypeIN();
            var outParam = sample.DoSomething(inParam);
        }
    }
}
