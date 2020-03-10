namespace T4
{
    /// <summary>
    /// 生成に利用するパラメーター
    /// </summary>
    public class GenerationContext
    {
        /// <summary>
        /// 名前空間
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// クラス名接尾語
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// 生成個数
        /// </summary>
        public int Count { get; set; }
    }
}
