//-----------------------------------------------------------------------
// <copyright file="SampleData002.cs" company="CVLab">
//      Copyright(c) CVLab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample.DataFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
        /// <returns></returns>
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
