using System;
using System.Collections.Generic;
using System.Linq;

namespace CVL.Extentions
{
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
            foreach (var item in sequence) action(item);
        }
    }
}
