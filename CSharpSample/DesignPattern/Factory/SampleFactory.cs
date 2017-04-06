using System.Collections.Generic;
using CSharpSample.SampleCode;

namespace CSharpSample.DesignPattern.Factory
{
    /// <summary>
    /// Sampleを生成するFactory
    /// </summary>
    public class SampleFactory
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private SampleFactory()
        {
            SamplePractitionerCache.Add(1, ManagingProgramFlow.GetInstance());
            SamplePractitionerCache.Add(5, DatabaseAccess.GetInstance());
            SamplePractitionerCache.Add(8, DelegateSample.GetInstance());
            SamplePractitionerCache.Add(9, new GenericsSamples());
            SamplePractitionerCache.Add(10, new DependancyProperties());
        }

        /// <summary>
        /// SampleFactoryクラスのインスタンス
        /// </summary>
        public static SampleFactory Instance { get; set; } = new SampleFactory();

        /// <summary>
        /// サンプル機能のキャッシュ
        /// </summary>
        private Dictionary<int, ISamplePractitioner> SamplePractitionerCache { get; set; } = new Dictionary<int, ISamplePractitioner>();

        /// <summary>
        /// Sampleクラスのインスタンスの取得
        /// </summary>
        /// <param name="sectionNo">セクション番号</param>
        /// <returns>Sample ClassのInterface</returns>
        public ISamplePractitioner Create(int sectionNo) => SamplePractitionerCache[sectionNo];
    }
}