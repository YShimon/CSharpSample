﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSharpSample.Common.Types;
using CSharpSample.DesignPattern.Factory;
using CVL.Extentions;

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
    /// ジェネリクスサンプルクラス
    /// </summary>
    public class GenericsSamples : ISamplePractitioner
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private GenericsSamples() { }

        /// <summary>
        /// 唯一のインスタンス
        /// </summary>
        private static GenericsSamples Instance { get; } = new GenericsSamples();

        /// <summary>
        /// Instatnce取得
        /// </summary>
        /// <returns>GenericsSamplesクラスのインスタンス</returns>
        public static GenericsSamples GetInstance() => Instance;

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
                case 3:
                    GenericsSample03();
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

        /// <summary>
        /// サンプル03
        /// </summary>
        private void GenericsSample03()
        {
            var innerClass = new InnerClass();
            GetProperties(innerClass).ForEach(x => Console.WriteLine($"Property Name={x.Key}, Value={x.Value}"));
        }

        /// <summary>
        /// インスタンスのプロパティをDictionaryに変換して取得
        /// </summary>
        /// <param name="instance">インスタンス</param>
        /// <returns>Dictionary(key=PropertyName, Value=Property Value)</returns>
        private Dictionary<string, string> GetProperties(object instance)
        {
            var propnames = instance.GetType().GetProperties();
            var properties = propnames.ToDictionary(x => x.Name, y => y.GetValue(instance).ToString());
            return properties;
        }

        /// <summary>
        /// インスタンスのプロパティをDictionaryに変換して取得
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="instance">インスタンス</param>
        /// <returns>Dictionary(key=PropertyName, Value=Property Value)</returns>
        private Dictionary<string, string> GetPropertiesByGenerics<T>(T instance)
        {
            var propnames = instance.GetType().GetProperties();
            var properties = propnames.ToDictionary(x => x.Name, y => y.GetValue(instance).ToString());
            return properties;
        }

        /// <summary>
        /// InnerClass(ジェネリクスサンプルに利用。サンプルクラスのため特に意味はない)
        /// </summary>
        public class InnerClass
        {
            /// <summary>
            /// StringProperty（サンプルのプロパティで特に意味はない）
            /// </summary>
            public string StringProperty { get; set; } = "String Property";

            /// <summary>
            /// IntProperty(サンプルのプロパティで特に意味はない)
            /// </summary>
            public int IntProperty { get; set; } = -1;
        }
    }
}
