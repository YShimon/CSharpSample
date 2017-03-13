using System;
using System.Collections.Generic;
using System.Windows;
using CSharpSample.DesignPattern.Factory;

namespace CSharpSample.SampleCode
{
    public class Person : DependencyObject
    {
        // Nameプロパティは省略

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register(
                "Children",
                typeof(List<Person>),
                typeof(Person),
                new PropertyMetadata(new List<Person>())); // デフォルト値は共有される


        public List<Person> Children
        {
            get { return (List<Person>)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        public Person()
        {
            // デフォルト値をコンストラクタで指定するようにする
            this.Children = new List<Person>();
        }

    }

    class DependancyProperties : ISamplePractitioner
    {
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
