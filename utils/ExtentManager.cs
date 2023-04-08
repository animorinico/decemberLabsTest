using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace DecemberLabsTest.utils
{
    /// <summary>
    /// Class purpose: manipulate ExtentReport framework.
    /// </summary>
    class ExtentManager
    {

        private readonly ExtentReports extentReports;
        private ExtentTest extentTest;

        public ExtentManager()
        {
            string path = ParameterReader.GetEnvironment("PathReportHtml") == "" ?
                Directory.GetCurrentDirectory().Replace(@"bin\Debug\netcoreapp3.1", @"reportHTML")
                :
                ParameterReader.GetEnvironment("PathReportHtml");
            string projectFolder = typeof(ExtentManager).Namespace.Replace(".utils", string.Empty);
            string timeDate = "reporte " + DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss");
            string pathAndFileName = ParameterReader.GetEnvironment("PathReportHtml") == "" ?
                @path + @"\" + timeDate + @"\"
                :
                @path + projectFolder + @"\" + timeDate + @"\"; ;

            var htmlReporter = new ExtentHtmlReporter(pathAndFileName);
            htmlReporter.Config.Theme = (Theme)int.Parse(ParameterReader.GetEnvironment("Theme"));
            htmlReporter.Config.DocumentTitle = ParameterReader.GetEnvironment("DocumentTitle");
            htmlReporter.Config.ReportName = ParameterReader.GetEnvironment("ReportName");
            htmlReporter.Config.Encoding = ParameterReader.GetEnvironment("Encoding");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);

        }




        /// <summary>
        /// Creates a test node to add into the HTML report.
        /// </summary>
        /// <param name="name">Nombre del test</param>
        /// <param name="description">Descripcion del test</param>
        public void CreateTest(string name, string description)
        {
            extentTest = extentReports.CreateTest(name, description);
        }

        /// <summary>
        /// Adds a test log.
        /// </summary>
        /// <param name="detail">Message to add in the log</param>
        /// <param name="status">Status to add in the log</param>
        public void AddLog(StatusTest status, string detail)
        {
            extentTest.Log((Status)status, detail);
        }

        /// <summary>
        /// Adds a log with Info type in the report with HTML format.
        /// </summary>
        /// <param name="extentTest">ExtentTest previously configured.</param>
        /// <param name="message">Personilized message</param>
        public void AddLog(StatusTest status, string[] message)
        {
            string li = null;

            for (int i = 1; i < message.Length; i++)
                li += "<li>" + message[i] + "</li>";

            string ul = "<ul>" + li + "</ul>";

            extentTest.Log((Status)status, message[0] + ul);
        }

        /// <summary>
        /// Adds a test status.
        /// </summary>
        /// <param name="detail">Message to add in the status</param>
        /// <param name="status">Status to assign</param>
        public void AddEstate(StatusTest status, string detail)
        {
            extentTest.Log((Status)status, detail);
        }

        /// <summary>
        /// Adds an screenshot of the test screen in a determined status.
        /// </summary>
        /// <param name="capture">Screenshot in BASE64</param>
        /// <param name="status">Status to add to the screenshot</param>
        public void AddScreenshot(StatusTest status, string capture)
        {
            extentTest.Log((Status)status, MediaEntityBuilder.CreateScreenCaptureFromBase64String(capture).Build());
        }

        /// <summary>
        /// Registers a status with a screenshot. 
        /// <para>Status evaluated are:</para>
        /// <list type="bullet">
        ///     <item>
        ///         <description>Failed</description>
        ///     </item>
        ///     <item>
        ///         <description>Skipped</description>
        ///     </item>
        ///     <item>
        ///         <description>Passed</description>
        ///     </item>
        ///     <item>
        ///         <description>Inconclusive</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="driver">Driver previously configured.</param>
        /// <param name="extentTest">Intance previously initializated.</param>
        public void AddTestResult(IWebDriver driver)
        {

            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            string testMessage = TestContext.CurrentContext.Result.Message;
            string screenshot = Utils.GetScreenshot(driver);

            switch (testStatus)
            {
                case TestStatus.Failed:
                    extentTest
                        .Fail(testMessage)
                        .Fail("Screenshot of the fail", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build())
                        .Fail("Test incomplete");
                    break;
                case TestStatus.Skipped:
                    extentTest
                         .Skip(testMessage)
                         .Skip("Screenshot of the fail", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build())
                         .Skip("Test incomplete");
                    break;
                case TestStatus.Passed:
                    extentTest.Pass("Test complete", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
                    break;
                case TestStatus.Inconclusive:
                    extentTest.Warning("Unexpected error")
                        .Warning("screenshot of the unexpected error ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build())
                        .Warning("Test incomplete");
                    break;
                default:
                    extentTest.Warning("Unexpected error");
                    break;
            }
        }

        /// <summary>
        /// Registers the test node configured to the HTML report.
        /// </summary>
        public void EndTest()
        {
            extentReports.Flush();
        }
    }
}
