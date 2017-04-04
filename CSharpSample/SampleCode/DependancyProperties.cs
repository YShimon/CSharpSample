using System;
using System.Collections.Generic;
using System.Windows;
using CSharpSample.DesignPattern.Factory;

namespace CSharpSample.SampleCode
{
    /// <summary>
    /// Personクラス 依存関係プロパティサンプル
    /// </summary>
    public class Person : DependencyObject
    {
        /// <summary>
        /// 依存プロパティ例
        /// </summary>
        /// <remarks>
        /// Nameプロパティは省略
        /// </remarks>
        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register(
                "Children",
                typeof(List<Person>),
                typeof(Person),
                new PropertyMetadata(new List<Person>())); // デフォルト値は共有される

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Person()
        {
            // デフォルト値をコンストラクタで指定するようにする
            this.Children = new List<Person>();
        }

        /// <summary>
        /// Children 依存プロパティ利用例
        /// </summary>
        public List<Person> Children
        {
            get { return (List<Person>)GetValue(ChildrenProperty); }
            set { this.SetValue(ChildrenProperty, value); }
        }
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public class DependancyProperties : ISamplePractitioner
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
