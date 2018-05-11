using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

using SaneWebDriver_CSharp.Support;


namespace SaneWebDriver_CSharp.C_Starting_To_Structure
{
    /*
     * Page Objects and settings files let you keep separate responsibilities
     * out of your tests. Your tests shouldn't know a thing about the mechanics
     * of the page--how to find things, how to handle asynch, etc.
     * All of that info is stored in the ContactGridPageObject.
     * 
     * Similarly, using a Settings file (or similar concept) ensures your tests
     * aren't hardwired up to environment specifics. Your build system can update
     * files, environment settings, etc. for each run, and the Settings
     * will handle reading those specifics in.
     * 
     */
    [TestFixture]
    public class Using_page_objects_and_settings
    {
        IWebDriver browser;
        WebDriverWait wait;

        [OneTimeSetUp]
        public void Setup()
        {
            browser = new FirefoxDriver();
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));

            browser.Navigate().GoToUrl(Settings.SITE_URL+"/KendoGrid.html");
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            browser.Quit();
        }

        [Test]
        public void grid_shows_on_page()
        {
            wait.Until(ExpectedConditions.
                ElementExists(By.Id(
                    ContactGridPageObject.GRID_ID)));
        }

       
        [Test]
        public void create_button_is_on_page()
        {
            wait.Until(ExpectedConditions.
                ElementExists(By.Id( 
                    ContactGridPageObject.CREATE_BTN_ID)));

        }

        [Test]
        public void grid_is_populated()
        {
            ContactGridPageObject page = new ContactGridPageObject(browser);

            //I'm not happy with this implementation right now. Need to rethink!
            Assert.IsTrue(page.WaitUntilGridIsPopulatedWithRows(browser));
        }

        //This test totally depends on knowing the test data set -- "Jim"
        // is part of the baseline dataset that would be loaded when the
        // overall test suite execution is started.
        [Test]
        public void check_jim_is_on_page()
        {
            ContactGridPageObject page = new ContactGridPageObject(browser);
            page.WaitUntilGridIsPopulatedWithRows(browser);
            Assert.IsNotNull(page.GetRowByRowTextContent( "Jim"));
        }
    }
}
