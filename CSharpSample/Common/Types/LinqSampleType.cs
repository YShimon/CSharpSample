using System.ComponentModel.DataAnnotations;

namespace CSharpSample.Common.Types
{
    /// <summary>
    /// Linq Sample Code(Sample Number)
    /// </summary>
    public enum LinqSampleType
    {
        /// <summary>
        /// ElementAt
        /// </summary>
        [Display(Name = "ElementAt")]
        ElementAt,

        /// <summary>
        /// ElementAtOrDefault
        /// </summary>
        [Display(Name = "ElementAtOrDefault")]
        ElementAtOrDefault,

        /// <summary>
        /// First
        /// </summary>
        [Display(Name = "First")]
        First,

        /// <summary>
        /// FirstOrDefault
        /// </summary>
        [Display(Name = "FirstOrDefault")]
        FirstOrDefault,

        /// <summary>
        /// Last
        /// </summary>
        [Display(Name = "Last")]
        Last,

        /// <summary>
        /// LastOrDefault
        /// </summary>
        [Display(Name = "LastOrDefault")]
        LastOrDefault,

        /// <summary>
        /// Single
        /// </summary>
        [Display(Name = "Single")]
        Single,

        /// <summary>
        /// SingleOrDefault
        /// </summary>
        [Display(Name = "SingleOrDefault")]
        SingleOrDefault,

        /// <summary>
        /// Where
        /// </summary>
        [Display(Name = "Where")]
        Where,
    }
}
