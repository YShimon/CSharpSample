//-----------------------------------------------------------------------
// <copyright file="SampleData001.cs" company="CVLab">
//      Copyright(c) cv-lab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CSharpSample.DataFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// SampleData001 Class
    /// </summary>
    public class SampleData001 : BaseSampleData
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the LinkId
        /// </summary>
        public int? LinkId { get; set; }

        /// <summary>
        /// Create SampleData001
        /// </summary>
        /// <returns>SampleData001 List</returns>
        public IEnumerable<SampleData001> Create()
        {
            var linkIds = new[]
            {
                new SampleData001()
                {
                    Id = 1,
                    LinkId = 10,
                },
                new SampleData001()
                {
                    Id = 3,
                    LinkId = 10,
                },
                new SampleData001()
                {
                    Id = 2,
                    LinkId = 10,
                },
                new SampleData001()
                {
                    Id = 4,
                    LinkId = 5,
                },
                new SampleData001()
                {
                    Id = 5,
                    LinkId = 5,
                },
                new SampleData001()
                {
                    Id = 6,
                },
                null,
                new SampleData001()
                {
                    Id = 8,
                    LinkId = 8,
                },
            };
            return linkIds;
        }
    }
}
