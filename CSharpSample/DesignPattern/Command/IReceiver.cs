using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSample.DesignPattern.Command
{
    /// <summary>
    /// CommandパターンにおけるReciever Interface
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public interface IReceiver
    {
        /// <summary>
        /// Action
        /// </summary>
        /// <param name="msg">メッセージ</param>
        void Action(string msg);
    }
}
