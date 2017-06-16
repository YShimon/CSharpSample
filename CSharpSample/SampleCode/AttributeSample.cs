using CSharpSample.DesignPattern.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpSample.SampleCode
{
    /// <summary>
    /// Attribute Sample Class
    /// </summary>
    public class AttributeSample : ISamplePractitioner
    {
        private static AttributeSample Instance { get; set; } = new AttributeSample();

        public static AttributeSample GetInstance() => Instance;

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

        private void Sample01()
        {
            Console.WriteLine("Start : Attribute.Sample01()");
            ConditionalDebug();
            ConditionalObsolete();
            Console.WriteLine("End   : Attribute.Sample01()");
        }

        [Conditional("DEBUG")]
        private void ConditionalDebug()
        {
            Console.WriteLine("Method ConditionalDebugは、[Conditional(\"DEBUG\")]のAttributeが付いてます。");
            Console.WriteLine("DEBUGモードの時のみこのメッセージは表示されます。");
        }

        [Obsolete("Obsolete属性により、警告表示を行っています")]
        private void ConditionalObsolete()
        {
            Console.WriteLine("Method ConditionalObsoleteは、[Obsolete]のAttributeが付いてます。");
            Console.WriteLine("コンパイル時にWarnningが表示されます");
        }
    }
}