using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
