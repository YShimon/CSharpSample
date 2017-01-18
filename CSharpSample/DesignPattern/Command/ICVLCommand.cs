using System.Diagnostics.CodeAnalysis;

namespace CSharpSample.DesignPattern.Command
{
    /// <summary>
    /// コマンドインターフェイス
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public interface ICVLCommand
    {
        /// <summary>
        /// Recieverの設定
        /// </summary>
        /// <param name="reciever">Recieverインターフェイス</param>
        void SetReciever(IReceiver reciever);

        /// <summary>
        /// コマンド実行
        /// </summary>
        void Execute();
    }
}
