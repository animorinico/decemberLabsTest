using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DecemberLabsTest.pages
{
    /// <summary>
    /// Class purpose: provides methods to the child classes.
    /// </summary>
    class BasePage
    {
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private protected void Click(By by)
        {
            driver.FindElement(by).Click();
        }

        private protected void SendKeys(By by, string text)
        {
            driver.FindElement(by).SendKeys(text);
        }

        private protected void Clear(By by)
        {
            driver.FindElement(by).Clear();
        }

        private protected string Text(By by)
        {
            return driver.FindElement(by).Text;
        }

        private protected string GetAttribute(By by, string attribute)
        {
            return driver.FindElement(by).GetAttribute(attribute);
        }

        private protected void SelectByIndex(By by, int index)
        {
            new SelectElement(driver.FindElement(by)).SelectByIndex(index);
        }

        private protected void SelectByText(By by, string text)
        {
            new SelectElement(driver.FindElement(by)).SelectByText(text);
        }

        private protected void SelectByValue(By by, string value)
        {
            new SelectElement(driver.FindElement(by)).SelectByValue(value);
        }

        private protected void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        private protected bool ElementIsDisplayed(By by)
        {
            return driver.FindElement(by).Displayed;
        }

        private protected string GetElementText(By by)
        {
            return driver.FindElement(by).Text;
        }

        private protected string Title()
        {
            return driver.Title;
        }

        private protected void Quit()
        {
            driver.Quit();
        }

        private protected void SwitchToFrame(IWebElement frameElement)
        {
            driver.SwitchTo().Frame(frameElement);
        }

        private protected IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }

        private protected bool ElementExists(By locator) =>
        driver.FindElements(locator).Count > 0;

    }
}
