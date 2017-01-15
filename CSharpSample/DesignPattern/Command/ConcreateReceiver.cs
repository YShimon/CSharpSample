using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSample.DesignPattern.Command
{
    public class ConcreateReceiver : IReceiver
    {
        public void Action(string msg)
        {
            Console.WriteLine($"msg:{msg}");
        }
    }
}
