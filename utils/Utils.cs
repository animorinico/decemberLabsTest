using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using OpenQA.Selenium.Firefox;

namespace DecemberLabsTest.utils
{
    /// <summary>
    /// Contains methos to assist tests.
    /// </summary>
    class Utils
    {
        /// <summary>
        /// Configures and returns a IWebDriver.
        /// </summary>
        /// <returns>Configured Driver.</returns>
        public static IWebDriver DriverConfiguration()
        {
            IWebDriver driverRetorno;
            string browser = ParameterReader.GetEnvironment("Browser");

            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.AddArguments("start-maximized");
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driverRetorno = new ChromeDriver(optionsChrome);
                    break;
                case "firefox":
                    FirefoxOptions optionsFirefox = new FirefoxOptions();
                    optionsFirefox.AddArguments("start-maximized");
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driverRetorno = new FirefoxDriver(optionsFirefox);
                    break;
                default:
                    ChromeOptions optionsDefault = new ChromeOptions();
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driverRetorno = new ChromeDriver(optionsDefault);
                    break;
            }

            driverRetorno.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driverRetorno;
        }

        /// <summary>
        /// Takes an screenshot.
        /// </summary>
        /// <param name="driver">Driver previously configured.</param>
        /// <returns>Screenshot coded in Base64.</returns>
        public static string GetScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}