using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpSample.SampleCode.Attributes
{
    /// <summary>
    /// AttributeのSample Class
    /// </summary>
    /// <remarks>
    /// このSampleでは、Class,Methodに適用する設定にしている(enum,structも設定できます)
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SampleAttribute : Attribute
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 所属
        /// </summary>
        public string Affiliation { get; set; }
    }
}