using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSample.DesignPattern.Command
{
    public interface IReceiver
    {
        void Action(string msg);
    }
}
