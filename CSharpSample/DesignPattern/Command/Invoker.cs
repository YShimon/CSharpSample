using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CVL.Extentions;

namespace CSharpSample.DesignPattern.Command
{
    /// <summary>
    /// コマンド起動クラス
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public class Invoker
    {
        /// <summary>
        /// 登録されたコマンド
        /// </summary>
        private Stack<ICVLCommand> commands = new Stack<ICVLCommand>();

        /// <summary>
        /// コマンドの追加
        /// </summary>
        /// <param name="command">追加するコマンド</param>
        public void AddCommand(ICVLCommand command)
        {
            commands.Push(command);
        }

        /// <summary>
        /// コマンド繰り返し
        /// </summary>
        public void UndoCommand()
        {
            Console.WriteLine("UndoCommand");
            var command = commands.Pop();
            command.Execute();
        }

        /// <summary>
        /// コマンド実行
        /// </summary>
        public void Execute()
        {
            commands.ForEach(x => x.Execute());
        }
    }
}
