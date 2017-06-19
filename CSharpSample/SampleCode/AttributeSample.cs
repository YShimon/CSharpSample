using System;
using System.Diagnostics;
using CSharpSample.DesignPattern.Factory;
using CSharpSample.SampleCode.Attributes;

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
                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Sample 1
        /// </summary>
        private void Sample01()
        {
            Console.WriteLine("Start : Attribute.Sample01()");
            ConditionalDebug();
            ConditionalObsolete();
            CustomAttribute();
            Console.WriteLine("End   : Attribute.Sample01()");
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

        [Sample(Author="Shimon", Affiliation ="CVLab.com")]
        public void CustomAttribute()
        {
            Console.WriteLine("\tMethod CustomeAttributeは、[Sample]のCustom Attributeが付いてます");
            Console.WriteLine("\t\t実行時に属性Authorが表示されます");
            foreach(var n in typeof(AttributeSample).GetMethods())
            {
                foreach(var m in n.GetCustomAttributes(typeof(SampleAttribute), false))
                {
                    Console.WriteLine($"\t\tCustomAttributeの作者は、{((SampleAttribute)m).Author}です");
                    Console.WriteLine($"\t\tCustomAttributeの所属は、{((SampleAttribute)m).Affiliation}です");
                }
            }
        }
    }
}