using System;
using System.Threading.Tasks;
using System.Windows;

namespace TAP.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SimpleTAP : Window
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SimpleTAP()
        {
            InitializeComponent();
        }

        private void BasicTAP_Click(object sender, RoutedEventArgs e)
        {
            ContentText.Text = string.Empty;

            // 非同期メソッドではあるが、awaitを付けているので、DelayAsync001 -> DelayAsync002の順番で実行される
            // DelayAsync001のawaitを削除するとDelayAsync002のメッセージがコンソールに表示されることになる
            var sampleTask01 = Task.Run(async () =>
            {
                var delay001 = 3201;
                await DelayAsync001(delay001);
                //_ = DelayAsync001(delay001); // _(アンダースコア)はインスタンスの廃棄

                var delay002 = 1201;
                await DelayAsync002(delay002);
            });

            //Console.WriteLine("何かキーを入力して下さい");
            ContentText.Text += "メソッドの終端に到達しました" + Environment.NewLine;
        }

        /// <summary>
        /// 指定時間(msec)待機した後に待機完了をコンソールに表示するタスク
        /// </summary>
        /// <param name="delay">待機時間msec</param>
        /// <returns>void</returns>
        async Task DelayAsync001(int delay)
        {
            // 指定時間(msec)待機するという仕事の完了を待ち
            await Task.Delay(delay);

            // 完了したことをコンソールに表示
            //Console.WriteLine($"DelayAsync001 Done! {delay} msec delaied");
            Dispatcher.Invoke(() => 
            { 
                ContentText.Text += "DelayAsync001 Done! " + delay + "[msec] delaied" + Environment.NewLine;
            });
        }

        /// <summary>
        /// 指定時間(msec)待機した後に待機完了をコンソールに表示するタスク(戻り値あり版)
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        async Task<string> DelayAsync002(int delay)
        {
            // 指定時間(msec)待機するという仕事の完了を待ち
            await Task.Delay(delay);

            // 完了したことをコンソールに表示
            //Console.WriteLine($"DelayAsync002 Done! {delay} msec delaied");
            Dispatcher.Invoke(() => 
            { 
                ContentText.Text += "DelayAsync002 Done! " + "delay" +  "[msec] delaied" + Environment.NewLine;
            });
            return "Done";
        }
    }
}
