//-----------------------------------------------------------------------
// <copyright file="CVLExtensions.cs" company="CVLab">
//      Copyright(c) cv-lab.com.All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CVL.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 拡張メソッド
    /// </summary>
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

        public static string DisplayName<T>(this T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];
            if (descriptionAttributes != null && descriptionAttributes.Length > 0)
            {
                return descriptionAttributes[0].Name;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
