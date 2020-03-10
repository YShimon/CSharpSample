using System.IO;
using System.Text;

namespace T4
{
    /// <summary>
    /// T4 Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args">引数(未使用)</param>
        static void Main(string[] args)
        {
            // コード生成パラメータ
            var outPath = @"./GeneratedCode.cs";
            var nameSpace = "T4";
            var classNameSuffix = "Sample";
            var count = 15;

            // コード生成
            GenerateCode(outPath, nameSpace, classNameSuffix, count);
        }

        /// <summary>
        /// コード生成
        /// </summary>
        /// <param name="outputPath">出力パス</param>
        /// <param name="nameSpace">名前空間</param>
        /// <param name="suffix">クラス名接尾語</param>
        /// <param name="count">生成するクラスの個数</param>
        public static void GenerateCode(string outputPath, string nameSpace, string suffix, int count)
        {
            // 生成パラメータをContextに設定
            var context = new GenerationContext
            {
                Namespace = nameSpace,
                Suffix = suffix,
                Count = count
            };

            // テキストを生成
            var generatedCode = new RuntimeTextTemplate(context).TransformText();

            // ファイル出力
            File.WriteAllText(outputPath, generatedCode, new UTF8Encoding(false));
        }
    }
}
