using System.ComponentModel.DataAnnotations;

namespace CSharpSample.SampleCode.Constants
{
    /// <summary>
    /// サンプル定数
    /// TODO:削除Types等に移動する
    /// </summary>
    public class SampleConstants
    {
        /// <summary>
        /// Enum Sample(数値を表す列挙型)
        /// </summary>
        public enum NumberJP
        {
            /// <summary>
            /// Zero
            /// </summary>
            [Display(Name = "零")]
            Zero,

            /// <summary>
            /// One
            /// </summary>
            [Display(Name = "壱")]
            One,

            /// <summary>
            /// Two
            /// </summary>
            [Display(Name = "弐")]
            Two,

            /// <summary>
            /// Three
            /// </summary>
            [Display(Name = "参")]
            Three,
        }
    }
}