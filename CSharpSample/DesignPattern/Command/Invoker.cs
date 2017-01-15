using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVL.Extentions;

namespace CSharpSample.DesignPattern.Command
{
    public class Invoker
    {
        private Stack<ICVLCommand> commands = new Stack<ICVLCommand>();

        public void AddCommand(ICVLCommand command)
        {
            commands.Push(command);
        }

        public void UndoCommand()
        {
            Console.WriteLine("UndoCommand");
            var command = commands.Pop();
            command.Execute();
        }

        public void Execute()
        {
            commands.ForEach(x => x.Execute());
        }
    }
}
