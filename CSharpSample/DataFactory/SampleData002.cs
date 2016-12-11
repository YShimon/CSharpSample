//-----------------------------------------------------------------------
// <copyright file="SampleData002.cs" company="CVLab">
//      Copyright(c) CVLab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample.DataFactory
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// SampleData002データ生成クラス
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public class SampleData002 : BaseSampleData
    {
        /// <summary>
        /// Gets or sets the LinkId
        /// </summary>
        public int LinkId { get; set; }

        /// <summary>
        /// Gets or sets the Comment Related LinkId
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Create SampleData002
        /// </summary>
        /// <returns>サンプルデータ</returns>
        public IEnumerable<SampleData002> Create()
        {
            var sampleData002 = new[]
            {
                new SampleData002
                {
                    LinkId = 5,
                    Comment = "Comment(LinkId == 5)",
                },

                new SampleData002
                {
                    LinkId = 5,
                    Comment = "Comment(LinkId != 7)",
                },

                new SampleData002
                {
                    LinkId = 10,
                    Comment = "Comment(LinkId == 10)",
                },
            };

            return sampleData002;
        }
    }
}
