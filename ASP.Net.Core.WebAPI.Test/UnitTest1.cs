using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASP.Net.Core.WebAPI.Test
{
    [TestClass]
    public class UnitTest1
    {
        // IIS Express のプロセス
        private static Process _iisProcess = null;

        // IIS のポート
        private const int Port = 9000;

        // リクエストUrl
        private const string UrlBase = "http://localhost:5000/";

        /// <summary>
        /// 初期起動処理
        /// TODO:初期化設定をグローバルにできない？(テストが実施されている間WEBAPIが起動有効となる設定)
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Trace.WriteLine("Beginning of TestMethod1");

#if false
            // IIS Express のプロセスStart
            if (_iisProcess == null)
            {
                //var applicationPath = GetApplicationPath("ASP.Net.Core.WebAPI\\bin\\Debug\\netcoreapp3.1\\ASP.Net.Core.WebAPI.exe");
                var applicationPath = GetApplicationPath("..\\..\\ASP.Net.Core.WebAPI\\bin\\Debug\\netcoreapp3.1\\ASP.Net.Core.WebAPI.exe");
                var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                var iisPath = Path.Combine(programFiles, "IIS Express", "iisexpress.exe");
                var startInfo = new ProcessStartInfo
                {
                    FileName = iisPath,
                    Arguments = $"/path:\"{applicationPath}\" /port:{Port}",
                };
                _iisProcess = Process.Start(startInfo);
            }
#else
                //var startInfo = new ProcessStartInfo
                //{
                //    FileName = @"C:\Users\Yukio\Documents\Develop\01_Code\02_LocalGit\CSharpSample\ASP.Net.Core.WebAPI\bin\Debug\netcoreapp3.1\ASP.Net.Core.WebAPI.exe",
                //};
                //_iisProcess = Process.Start(startInfo);
#endif
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            StopIIS();
        }

        /// <summary>
        /// ソリューションフォルダ直下にあるテスト対象アプリのフォルダパスを取得します。
        /// </summary>
        /// <returns>テスト対象アプリのフォルダパス</returns>
        private static string GetApplicationPath(string applicationName)
        {
            var solutionFolder = Path.GetDirectoryName(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }

        /// <summary>
        /// IIS Express を停止します。
        /// </summary>
        private static void StopIIS()
        {
            if (_iisProcess != null &&
                _iisProcess.HasExited == false)
            {
                _iisProcess.Kill();
            }
        }

        /// <summary>
        /// リクエストの作成
        /// </summary>
        /// <param name="url"></param>
        /// <param name="mthv"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private HttpRequestMessage CreateRequest(string url, string mthv, HttpMethod method)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(UrlBase + url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mthv));
            request.Method = method;
            return request;
        }

        [TestMethod]
        public void TestMethod1()
        {
            // http://localhost:5000/api/Staff
            // https://localhost:5001/api/Staff

            HttpClient client = new HttpClient();
            var request = CreateRequest(
                "api/Staff",
                "*/*",
                HttpMethod.Get
            );


            // API実行
            using (var response = client.SendAsync(request).Result)
            {
                // 
                var content = response.Content.ReadAsStringAsync().Result;

                // Responseがあるかの検証
                Assert.IsNotNull(response);
                // StatusCodeが正しいかの検証
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }

            Trace.WriteLine("End of TestMethod1");
        }
    }
}
