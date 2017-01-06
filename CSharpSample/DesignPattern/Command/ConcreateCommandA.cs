using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSample.DesignPattern.Command
{
    class ConcreateCommandA : ICVLCommand
    {
        private int id;
        protected IReceiver receiver;
        private string name = "CommandA";

        public ConcreateCommandA(int id)
        {
            this.id = id;
        }

        public void Execute()
        {
            this.receiver.Action(name + ":" + id.ToString());
        }

        public void SetReciever(IReceiver receiver)
        {
            this.receiver = receiver;
        }
    }
}
