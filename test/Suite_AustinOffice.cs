using NUnit.Framework;
using DecemberLabsTest.utils;
using DecemberLabsTest.pages;

namespace DecemberLabsTest.test
{
    class Suite_AustinOffice : TestBase
    {
        #region Variables
        public string austinOfficeTitle = ParameterReader.GetTestValues("AustinOfficePage", "Title");
        public string austinOfficeUrl = ParameterReader.GetTestValues("AustinOfficePage", "Url");
        public string calendarHeaderText = ParameterReader.GetTestValues("AustinOfficePage", "CalendarHeaderText");
        #endregion

        [Test]
        [Description("Verifies the pop-up/modal Schedule Free Consultation")]
        public void AustinOffice_ValidateScheduleFreeConsultationModal()
        {

            #region Create Page Objects classes new instances and HTML test report
            AustinOfficePage austinOfficePage = new AustinOfficePage(driver);
            DecemberLabsMainPage decemberLabsMain = new DecemberLabsMainPage(driver);
            extentManager.CreateTest("Austin Office - Validate Schedule Free Consultation Modal", "Verifies the pop-up calendar from the Schedule Free Consultation button");
            #endregion

            #region GIVEN User navigates to Austin Office link
            decemberLabsMain.GoToOfficeByLink("Austin");
            extentManager.AddLog(StatusTest.INFO, $"User navigates to Austin Office link");
            #endregion

            #region THEN The Title and URL are expected
            Assert.That(driver.Title, Is.EqualTo(austinOfficeTitle));
            Assert.That(driver.Url, Is.EqualTo(austinOfficeUrl));
            extentManager.AddLog(StatusTest.INFO, $"Validation of Title and URL");
            #endregion

            #region WHEN User opens the Schedule Free Consultation calendar
            austinOfficePage.ClickScheduleConsultButton();
            extentManager.AddLog(StatusTest.INFO, $"User opens Schedule Free Consultation Calendar");
            #endregion

            #region THEN The Schedule Consultant Modal Calendar and the Header are visible
            //Switching to the iFrame that contains this Modal
            austinOfficePage.SwitchToScheduleFreeConsultFrame();

            Assert.IsTrue(austinOfficePage.ValidateSchedCalendarExists());
            Assert.AreEqual(calendarHeaderText, austinOfficePage.GetHeaderScheduleConsultModalText());

            //Switching back to the Default Content
            austinOfficePage.SwitchToDefaultContent();
            extentManager.AddLog(StatusTest.INFO, $"Then the Schedule Consultant Modal Calendar is visible and Header is expected");
            #endregion

            #region WHEN Closing the Schedule Free Consultation Modal
            austinOfficePage.CloseScheduleConsultCalendar();
            extentManager.AddLog(StatusTest.INFO, $"User closes the Scheudle Free Consultation Modal");
            #endregion

            #region THEN The Schedule Consultant Modal is not visible anymore
            Assert.IsFalse(austinOfficePage.ValidateSchedCalendarExists());
            extentManager.AddLog(StatusTest.INFO, $"Then the Schedule Consultant Modal is closed");
            #endregion

        }
    }
}
