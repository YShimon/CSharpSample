using System.ComponentModel.DataAnnotations;

namespace CSharpSample.SampleCode.Constants
{
    /// <summary>
    /// Enum Sample(数値を表す列挙型)
    /// </summary>
    public class SampleConstants
    {
        public enum NumberJP
        {
            /// <summary>
            /// 0 = "零"
            /// </summary>
            [Display(Name = "零")]
            Zero,

            /// <summary>
            /// 1 = "壱"
            /// </summary>
            [Display(Name = "壱")]
            One,

            /// <summary>
            /// 2 = "弐"
            /// </summary>
            [Display(Name = "弐")]
            Two,

            /// <summary>
            /// 3 = "参"
            /// </summary>
            [Display(Name = "参")]
            Three,
        }
    }
}