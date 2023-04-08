using NUnit.Framework;
using OpenQA.Selenium;
using DecemberLabsTest.pages;
using DecemberLabsTest.utils;

namespace DecemberLabsTest.test
{
    class TestBase
    {
        protected static IWebDriver driver;
        protected AustinOfficePage austinOfficePage;
        protected ExtentManager extentManager;
        public string MainPageTitle = ParameterReader.GetTestValues("MainPage", "Title");

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            extentManager = new ExtentManager();
        }

        [SetUp]
        public void Setup()
        {

            driver = Utils.DriverConfiguration();
            DecemberLabsMainPage decemberLabsMainPage = new DecemberLabsMainPage(driver);
            decemberLabsMainPage.GoToDecemberLabsMainPage();

            Assert.That(driver.Title, Is.EqualTo(MainPageTitle));
            decemberLabsMainPage.VerifySuperiorMenuIsDisplayed();

        }

        [TearDown]
        public void Teardown()
        {
            extentManager.AddTestResult(driver);
            extentManager.EndTest();
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            driver.Quit();
        }
    }
}
