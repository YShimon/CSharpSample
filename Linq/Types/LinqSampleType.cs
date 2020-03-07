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

        /// <summary>
        /// Min
        /// </summary>
        [Display(Name = "Min")]
        Min,

        /// <summary>
        /// Average
        /// </summary>
        [Display(Name = "Average")]
        Average,

        /// <summary>
        /// Sum
        /// </summary>
        [Display(Name = "Sum")]
        Sum,

        /// <summary>
        /// Count
        /// </summary>
        [Display(Name = "Count")]
        Count,

        /// <summary>
        /// Aggregate
        /// </summary>
        [Display(Name = "Aggregate")]
        Aggregate,

        /// <summary>
        /// All
        /// </summary>
        [Display(Name = "All")]
        All,

        /// <summary>
        /// Any
        /// </summary>
        [Display(Name = "Any")]
        Any,

        /// <summary>
        /// Contains
        /// </summary>
        [Display(Name = "Contain")]
        Contains,

        /// <summary>
        /// SequenceEqual
        /// </summary>
        [Display(Name = "SequenceEqual")]
        SequenceEqual,

        /// <summary>
        /// Union
        /// </summary>
        [Display(Name = "Union")]
        Union,

        /// <summary>
        /// Except
        /// </summary>
        [Display(Name = "Except")]
        Except,

        /// <summary>
        /// Intersect
        /// </summary>
        [Display(Name = "Intersect")]
        Intersect,

        /// <summary>
        /// OrderBy
        /// </summary>
        [Display(Name = "OrderBy")]
        OrderBy,

        /// <summary>
        /// OrderByDescending
        /// </summary>
        [Display(Name = "OrderByDescending")]
        OrderByDescending,

        /// <summary>
        /// ThenBy
        /// </summary>
        [Display(Name = "ThenBy")]
        ThenBy,

        /// <summary>
        /// ThenByDescending
        /// </summary>
        [Display(Name = "ThenByDescending")]
        ThenByDescending,

        /// <summary>
        /// Reverse
        /// </summary>
        [Display(Name = "Reverse")]
        Reverse,

        /// <summary>
        /// Select
        /// </summary>
        [Display(Name = "Select")]
        Select,

        /// <summary>
        /// GroupBy
        /// </summary>
        [Display(Name = "GroupBy")]
        GroupBy,

        /// <summary>
        /// SelectMany
        /// </summary>
        [Display(Name = "SelectMany")]
        SelectMany,
    }
}
