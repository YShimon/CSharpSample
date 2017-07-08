using System;
using System.Diagnostics;
using CSharpSample.DesignPattern.Factory;
using CSharpSample.SampleCode.Attributes;
using System.Collections.Generic;
using CVL.Extentions;
using CSharpSample.SampleCode.Constants;

namespace CSharpSample.SampleCode
{
    /// <summary>
    /// Attribute Sample Class
    /// </summary>
    public class AttributeSample : ISamplePractitioner
    {
        /// <summary>
        /// Singleton Instance
        /// </summary>
        private static AttributeSample Instance { get; set; } = new AttributeSample();

        /// <summary>
        /// Instance取得
        /// </summary>
        /// <returns>AttributeSample ClassのInstance</returns>
        public static AttributeSample GetInstance() => Instance;

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

                case 2:
                    Sample02();
                    break;

                case 3:
                    Sample03();
                    break;

                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Sample 01(定義済みAttributesの例)
        /// </summary>
        private void Sample01()
        {
            Console.WriteLine("Start : Attribute.Sample01()");
            ConditionalDebug();
            ConditionalObsolete();
            Console.WriteLine("End   : Attribute.Sample01()");
        }

        /// <summary>
        /// Sample 02(Custom Attributesの例)
        /// </summary>
        private void Sample02()
        {
            Console.WriteLine("Start : Attribute.Sample02()");
            CustomAttribute();
            Console.WriteLine("End   : Attribute.Sample02()");
        }

        /// <summary>
        /// Sample 03(Attributesの利用例)
        /// Enumに定義した定数値のDisplay名称を取得する
        /// </summary>
        private void Sample03()
        {
            Console.WriteLine("Start : Attribute.Sample03()");
            (Enum.GetValues(typeof(SampleConstants.NumberJP)) as IEnumerable<SampleConstants.NumberJP>)
                .ForEach(x => { Console.WriteLine($"\t\t{x.DisplayName()}"); });
            Console.WriteLine("End   : Attribute.Sample03()");
        }

        /// <summary>
        /// Debug Mode時のみ実行されるMethod
        /// [Conditional("DEBUG")]を利用した例
        /// </summary>
        [Conditional("DEBUG")]
        private void ConditionalDebug()
        {
            Console.WriteLine("\tMethod ConditionalDebugは、[Conditional(\"DEBUG\")]のAttributeが付いてます。");
            Console.WriteLine("\t\tこの属性は、コンパイラが利用します");
            Console.WriteLine("\t\tDEBUGモードの時のみこのメッセージは表示されます。");
        }

        /// <summary>
        /// ビルド時に警告が表示されるMethod
        /// [Obsolete("")]を利用した例
        /// </summary>
        [Obsolete("Obsolete属性により、警告表示を行っています")]
        private void ConditionalObsolete()
        {
            Console.WriteLine("\tMethod ConditionalObsoleteは、[Obsolete]のAttributeが付いてます");
            Console.WriteLine("\t\tこの属性は、コンパイラが利用します");
            Console.WriteLine("\t\tコンパイル時にWarnningが表示されます");
            Console.WriteLine("\t\t「互換のために残しているが、新規に呼び出すべきではない」のような場合にこの属性を利用します");
        }

        /// <summary>
        /// Custom Attributeを表示する例
        /// </summary>
        /// <remarks>typeof(...).GetMethods()を利用しているので、このMethodはpublicである必要があります</remarks>
        [Sample(Author = "Shimon", Affiliation = "CVLab.com")]
        public void CustomAttribute()
        {
            Console.WriteLine("\tこのMethod CustomeAttributeには、[Sample]のCustom Attributeが設定されています");
            Console.WriteLine("\t\t実行時に属性(Author,Affiliation)が表示されます");
            foreach (var n in typeof(AttributeSample).GetMethods())
            {
                foreach (var m in n.GetCustomAttributes(typeof(SampleAttribute), false))
                {
                    Console.WriteLine($"\t\tCustomAttributeの作者は、{((SampleAttribute)m).Author}です");
                    Console.WriteLine($"\t\tCustomAttributeの所属は、{((SampleAttribute)m).Affiliation}です");
                }
            }
        }
    }
}