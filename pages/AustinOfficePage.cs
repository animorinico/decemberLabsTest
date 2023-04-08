using OpenQA.Selenium;
using DecemberLabsTest.utils;
using NUnit.Framework;

namespace DecemberLabsTest.pages
{
    /// <summary>
    /// Class purpose: manipulate Austin Office page objects/interface
    /// </summary>

    class AustinOfficePage : BasePage
    {
        #region Headers
        public By scheduleCalendarHeader;
        #endregion

        #region Schedule Free Consultation Modal
        public By scheduleConsultButton;
        public By scheduleCalendar;
        public By scheduleConsultModalCloseButton;
        public IWebElement iframeCalendar;
        #endregion

        public AustinOfficePage(IWebDriver driver) : base(driver)
        {
            #region Headers
            scheduleCalendarHeader = By.CssSelector("div.js-calendar-selector h3.text-medium");
            #endregion

            #region Schedule Free Consultation Modal
            scheduleConsultButton = By.XPath("//div[@class='buttons']/a[text()='Schedule free consultation']");
            scheduleConsultModalCloseButton = By.CssSelector("div[class*='dl-modal calendar-modal'] div.btn-close-modal");
            scheduleCalendar = By.CssSelector("div.js-calendar-selector");
            #endregion

        }

        public void ClickScheduleConsultButton()
        {
            Click(scheduleConsultButton);
        }

        public void SwitchToScheduleFreeConsultFrame()
        {
            IWebElement iframeCalendar = FindElement(By.CssSelector("div.dl-modal-content iframe[frameborder='0']"));
            SwitchToFrame(iframeCalendar);
        }

        public bool ValidateSchedCalendarExists()
        {
            bool verifyElementExists = ElementExists(scheduleCalendar);

            if (ElementExists(scheduleCalendar) == true)
            {
                verifyElementExists = ElementIsDisplayed(scheduleCalendar); 
            }
            return verifyElementExists;
        }

        public string GetHeaderScheduleConsultModalText()
        {
            string calendarHeaderText = GetElementText(scheduleCalendarHeader);
            return calendarHeaderText.ToString();
        }

        public void CloseScheduleConsultCalendar()
        {
            Click(scheduleConsultModalCloseButton);
        }
    }
}
