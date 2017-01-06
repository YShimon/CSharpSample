using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace CSharpSample.DesignPattern
{
    /// <summary>
    /// SampleクラスFactory
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public class SampleFactory
    {
        /// <summary>
        /// Sampleクラスのインスタンスの生成
        /// </summary>
        /// <param name="sectionNo">セクション番号</param>
        /// <returns>Sample ClassのInterface</returns>
        public static ISamplePractitioner Create(int sectionNo)
        {
            ISamplePractitioner practitioner = null;

            if (sectionNo == 1)
            {
                practitioner = new ManagingProgramFlow();
            }

            return practitioner;
        }
    }
}