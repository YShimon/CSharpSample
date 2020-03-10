namespace T4
{
    /// <summary>
    /// ランタイムコード生成クラスにコンテキストを追加するための定義クラス
    /// </summary>
    public partial class RuntimeTextTemplate
    {
        /// <summary>
        /// コード生成パラメータ
        /// </summary>
        private GenerationContext Context { get; }

        /// <summary>
        /// コンストラクタ(コンテキスト受取用)
        /// </summary>
        /// <param name="context">コンテキスト(生成パラメータ)</param>
        public RuntimeTextTemplate(GenerationContext context)
        {
            Context = context;
        }
    }
}
