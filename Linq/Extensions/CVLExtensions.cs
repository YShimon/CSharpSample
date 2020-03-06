namespace Linq.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 拡張メソッド
    /// TODO:拡張メソッドは移設する
    /// TODO:namespace変更
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

        public static int ToIntOrDefault(this string str, int def = 0)
        {
            return int.TryParse(str, out int ret) ? ret : def;
        }

        /// <summary>
        /// 属性の表示名称(Display)を取得
        /// </summary>
        /// <typeparam name="T">表示する型T</typeparam>
        /// <param name="value">表示するプロパティ</param>
        /// <returns>表示名称</returns>
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
