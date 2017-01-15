//-----------------------------------------------------------------------
// <copyright file="DataFactory.cs" company="CVLab">
//      Copyright(c) cv-lab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

/// <summary>
/// テストデータFactory名前空間
/// </summary>
namespace CSharpSample.DataFactory
{
    using System.Collections.Generic;

    /// <summary>
    /// Test Data Factory
    /// </summary>
    /// <typeparam name="T">Sample Data Class</typeparam>
    public class DataFactory<T> 
    {
        /// <summary>
        /// Create Test Data
        /// </summary>
        /// <returns>Sample Data List</returns>
        public IEnumerable<T> Create()
        {
            IEnumerable<T> sampleData = null;
            if (typeof(T) == typeof(SampleData001))
            {
                sampleData = new SampleData001().Create() as IEnumerable<T>;
            }
            else if (typeof(T) == typeof(SampleData002))
            {
                sampleData = new SampleData002().Create() as IEnumerable<T>;
            }

            return sampleData;
        }
    }
}
