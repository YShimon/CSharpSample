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
        // IIS Express �̃v���Z�X
        private static Process _iisProcess = null;

        // IIS �̃|�[�g
        private const int Port = 9000;

        // ���N�G�X�gUrl
        private const string UrlBase = "http://localhost:5000/";

        /// <summary>
        /// �����N������
        /// TODO:�������ݒ���O���[�o���ɂł��Ȃ��H(�e�X�g�����{����Ă����WEBAPI���N���L���ƂȂ�ݒ�)
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Trace.WriteLine("Beginning of TestMethod1");

#if false
            // IIS Express �̃v���Z�XStart
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
        /// �I������
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            StopIIS();
        }

        /// <summary>
        /// �\�����[�V�����t�H���_�����ɂ���e�X�g�ΏۃA�v���̃t�H���_�p�X���擾���܂��B
        /// </summary>
        /// <returns>�e�X�g�ΏۃA�v���̃t�H���_�p�X</returns>
        private static string GetApplicationPath(string applicationName)
        {
            var solutionFolder = Path.GetDirectoryName(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }

        /// <summary>
        /// IIS Express ���~���܂��B
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
        /// ���N�G�X�g�̍쐬
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


            // API���s
            using (var response = client.SendAsync(request).Result)
            {
                // 
                var content = response.Content.ReadAsStringAsync().Result;

                // Response�����邩�̌���
                Assert.IsNotNull(response);
                // StatusCode�����������̌���
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }

            Trace.WriteLine("End of TestMethod1");
        }
    }
}
