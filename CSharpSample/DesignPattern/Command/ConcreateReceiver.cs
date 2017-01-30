using System;
using System.Diagnostics.CodeAnalysis;

namespace CSharpSample.DesignPattern.Command
{
    /// <summary>
    /// Recieverクラスの具象化
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public class ConcreateReceiver : IReceiver
    {
        /// <summary>
        /// Action実行
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Action(string msg)
        {
            Console.WriteLine($"msg:{msg}");
        }
    }
}
