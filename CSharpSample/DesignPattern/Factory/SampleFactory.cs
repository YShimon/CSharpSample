using System.Diagnostics.CodeAnalysis;
using CSharpSample.SampleCode;

namespace CSharpSample.DesignPattern.Factory
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

            switch(sectionNo)
            {
                case 1:
                    practitioner = new ManagingProgramFlow();
                    break;
                case 5:
                    practitioner = new DatabaseAccess();
                    break;
                default:
                    break;
            }

            return practitioner;
        }
    }
}