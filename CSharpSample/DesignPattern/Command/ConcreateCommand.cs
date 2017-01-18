using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSample.DesignPattern.Command
{
    /// <summary>
    /// コマンド具象クラス生成
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "For Japanese support")]
    public class ConcreateCommand : ICVLCommand
    {
        /// <summary>
        /// コマンドパターンRecieverクラス
        /// </summary>
        private IReceiver receiver;

        /// <summary>
        /// Id
        /// </summary>
        private int id;

        /// <summary>
        /// TODO:内容確認
        /// </summary>
        private string name = "Command";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">Id</param>
        public ConcreateCommand(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// コマンド実行
        /// </summary>
        public void Execute()
        {
            this.receiver.Action(name + ":" + id.ToString());
        }

        /// <summary>
        /// Recierの設定
        /// </summary>
        /// <param name="receiver">Reciever Class(Interface)</param>
        public void SetReciever(IReceiver receiver)
        {
            this.receiver = receiver;
        }
    }
}
