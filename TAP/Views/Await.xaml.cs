using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace TAP.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class Await : Window
    {
        /// <summary>
        /// HTTPクライアント
        /// </summary>
        HttpClient client = new HttpClient();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Await()
        {
            InitializeComponent();
        }

        /// <summary>
        /// HTML取得完了を待機する場合の例 (Await機能確認1ボタン押下時の処理)
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private async void AwaitTest1_Click(object sender, RoutedEventArgs e)
        {
            // HTML取得完了を待機する
            string html = await client.GetStringAsync("http://www.yahoo.co.jp/");
            ContentText.Text = "HTMLの取得を完了しました";
            await Task.Delay(100);
            ContentText.Text = html;
        }

        /// <summary>
        /// 取得処理実行後にawaitする(Await機能確認2ボタン押下時の処理)
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private async void AwaitTest2_Click(object sender, RoutedEventArgs e)
        {
            // HTML取得完了を待機しない
            var htmlTask = client.GetStringAsync("http://www.yahoo.co.jp/");
            ContentText.Text = "HTMLを取得しています…";

            // HTMLを表示する箇所で待機する
            ContentText.Text = await htmlTask;
        }
    }
}
