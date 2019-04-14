using System.Collections.Generic;
using System.Windows;

namespace CSharpSample.Common.Types
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
}
