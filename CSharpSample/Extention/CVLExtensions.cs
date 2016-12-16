//-----------------------------------------------------------------------
// <copyright file="CVLExtensions.cs" company="CVLab">
//      Copyright(c) CVLab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CVL.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 拡張メソッド
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public static class CVLExtensions
    {
        /// <summary>
        /// ForEach拡張メソッド
        /// </summary>
        /// <typeparam name="T">Generics型T</typeparam>
        /// <param name="sequence">処理要素配列</param>
        /// <param name="action">実行するアクションデリゲート</param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence) { action(item); }
        }
    }
}
