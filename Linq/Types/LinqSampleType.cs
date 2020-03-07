using System.ComponentModel.DataAnnotations;

namespace Linq.Types
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

        /// <summary>
        /// Distinct
        /// </summary>
        [Display(Name = "Distinct")]
        Distinct,

        /// <summary>
        /// Skip
        /// </summary>
        [Display(Name = "Skip")]
        Skip,

        /// <summary>
        /// SkipWhile
        /// </summary>
        [Display(Name = "SkipWhile")]
        SkipWhile,

        /// <summary>
        /// Take
        /// </summary>
        [Display(Name = "Take")]
        Take,

        /// <summary>
        /// TakeWhile
        /// </summary>
        [Display(Name = "TakeWhile")]
        TakeWhile,

        /// <summary>
        /// Max
        /// </summary>
        [Display(Name = "Max")]
        Max,
    }
}
