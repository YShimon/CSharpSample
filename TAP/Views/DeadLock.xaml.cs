using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace TAP.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DeadLock : Window
    {
        /// <summary>
        /// MainWindowコンストラクタ
        /// </summary>
        public DeadLock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// デッドロックを確認するボタン押下時の動作
        /// （非同期にするには、Button_Clickにasync、DoSomethingAsyncにawaitを付加する）
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskResult.Text = string.Empty;

            // 何らかの処理を実行する
            var someTask = DoSomethingAsync();

            // Resultを利用しているのでsomeTask.Wait()と同じ効果あり
            TaskResult.Text = someTask.Result;
        }

        /// <summary>
        /// 時間のかかる処理を行う
        /// </summary>
        /// <returns>終了確認の文字列(Done)</returns>
        private async Task<string> DoSomethingAsync()
        {
            Debug.WriteLine("1000msec待機します [DelayAsync]");

            // デッドロックする
            // awaitでタスクの完了まで、以降の処理は実行されず待機するが、
            // UIスレッド側では、someTask.Result(someTask.Wait())が呼び出されスレッドが待ち状態となります。
            // こちらのスレッドでは、await Task.Delay()を抜けてsomeTask.Result(someTask.Wait())を実行しようとしても
            // UIスレッドが待ち状態のため実行できないことになる。つまり、全てのスレッドが待ち状態となりデッドロックとなる
            await Task.Delay(1000);

            // こちらのコード(await Task.Delay...)だとデッドロックしない(ただし、Button_Clickにasyncが指定されてないので、同期処理となる)
            // もしくは、someTask.Resultを使用しないことにするとデッドロックしない
            // ConfigureAwait(false)を付加することによりUIスレッドではないスレッドに戻ることになる。
            //await Task.Delay(1000).ConfigureAwait(false);

            Debug.WriteLine("1000msec待機完了しました [DelayAsync]");

            return "Done";
        }
    }
}
