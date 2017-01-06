using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSample.DesignPattern
{
    /// <summary>
    /// Sample Code実行クラス
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public interface ISamplePractitioner
    {
        /// <summary>
        /// サンプルコードを実行
        /// </summary>
        /// <param name="exampleNo">例番号</param>
        /// <returns>実行結果</returns>
        bool Do(int exampleNo);
    }
}
