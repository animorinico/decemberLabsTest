using OpenQA.Selenium;
using DecemberLabsTest.utils;

namespace DecemberLabsTest.pages
{
    /// <summary>
    /// Class purpose: manipulate December Labs main page objects/interface
    /// </summary>

    class DecemberLabsMainPage : BasePage
    {
        #region Headers and menu
        public By mainHeader;
        public By supMenu;
        #endregion

        #region Offices
        public By officeLink;
        #endregion

        public DecemberLabsMainPage(IWebDriver driver) : base(driver)
        {
            #region Headers and menu
            mainHeader = By.CssSelector("header[id=intro] .content_text > h2");
            supMenu = By.Id("menu-header-main-menu");
            #endregion

            #region Offices
            
            #endregion
        }

        public void GoToDecemberLabsMainPage()
        {
            Navigate(ParameterReader.GetEnvironment("UrlEnvironment"));
        }

        public void VerifySuperiorMenuIsDisplayed()
        {
            ElementIsDisplayed(supMenu);
        }

        #region Offices

        public void GoToOfficeByLink(string officeLinkName)
        {
            officeLink = By.XPath("//li[@class='offices_section']//a[text()='" + officeLinkName + "']");
            Click(officeLink);
        }
        #endregion
    }
}

