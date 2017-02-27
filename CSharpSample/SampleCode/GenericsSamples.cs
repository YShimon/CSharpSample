using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSample.DesignPattern.Factory;

namespace CSharpSample.SampleCode
{
    interface IGenerics<TI, TO>
    {
        TO DoSomething(TI input);
    }

    class TypeIN
    {
        public TypeIN()
        {
            Console.WriteLine("Constructor : TypeIN");
        }
    }

    class TypeOut
    {
        public TypeOut()
        {
            Console.WriteLine("Constructor : TypeOut");
        }
    }

    class GenericsInterfaceSample01 : IGenerics<TypeIN, TypeOut>
    {
        private GenericsInterfaceSample01 Instance = null;

        public GenericsInterfaceSample01 GetInstatnce()
        {
            if(Instance == null)
            {
                Instance = new GenericsInterfaceSample01();
            }
            return Instance;
        }

        public TypeOut DoSomething(TypeIN input)
        {
            Console.WriteLine("GenericsInterface.DoSomething()");
            return new TypeOut();
        }
    }

    class GenericsInterfaceSample02<TI, TO> : IGenerics<TI, TO>
    {
        private GenericsInterfaceSample02<TI, TO> Instance = null;

        public GenericsInterfaceSample02<TI, TO> GetInstatnce()
        {
            if(Instance == null)
            {
                Instance = new GenericsInterfaceSample02<TI, TO>();
            }
            return Instance;
        }

        public TO DoSomething(TI input)
        {
            Console.WriteLine($"class name of TI : {typeof(TI).Name}");
            Console.WriteLine($"class name of TO : {typeof(TO).Name}");
            return default(TO);
        }
    }


    class GenericsSamples : ISamplePractitioner
    {
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

        private void GenericsSample01()
        {
            var sample = new GenericsInterfaceSample01();
            var inParam = new TypeIN();
            var outParam = sample.DoSomething(inParam);
        }

        private void GenericsSample02()
        {
            var sample = new GenericsInterfaceSample02<TypeIN, TypeOut>();
            var inParam = new TypeIN();
            var outParam = sample.DoSomething(inParam);
        }
    }
}
