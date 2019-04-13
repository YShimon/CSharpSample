using System;
using CVL.Extentions;

namespace CSharpSample.SampleCode.Attributes
{
    /// <summary>
    /// ジェネリクスクラスサンプル
    /// </summary>
    /// <typeparam name="T">サンプル型</typeparam>
    public class SampleGenerics<T>
    {
        /// <summary>
        /// Sample Property
        /// </summary>
        public T SampleProperty { get; set; }

        /// <summary>
        /// Genericsクラスで定義されたプロパティ取得例
        /// </summary>
        public void GetPropertyAttribute()
        {
            typeof(T).GetProperties().ForEach(x => 
            {
                x.GetCustomAttributes(typeof(SampleAttribute), false).ForEach(y => 
                {
                    Console.WriteLine($"\t\tCustomAttributeの作者は、{((SampleAttribute)y).Author}です");
                    Console.WriteLine($"\t\tCustomAttributeの所属は、{((SampleAttribute)y).Affiliation}です");
                });
            });
        }
    }
}
