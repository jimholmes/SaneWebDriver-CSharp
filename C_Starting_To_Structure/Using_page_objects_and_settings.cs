using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.C_Starting_To_Structure
{
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
            wait.Until(ExpectedConditions.ElementExists(By.Id(ContactGridPageObject.GRID_ID)));
        }

       
        [Test]
        public void create_button_is_on_page()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id(ContactGridPageObject.CREATE_BTN_ID)));

        }

        [Test]
        public void grid_is_populated()
        {
            ContactGridPageObject page = new ContactGridPageObject();

            //I'm not happy with this implementation right now. Need to rethink!
            Assert.IsTrue(page.WaitUntilGridIsPopulatedWithRows(browser));
        }

        [Test]
        public void check_jim_is_on_page()
        {
            ContactGridPageObject page = new ContactGridPageObject();
            page.WaitUntilGridIsPopulatedWithRows(browser);
            Assert.IsNotNull(page.GetRowByRowTextContent(browser, "Holmes"));
        }
    }
}
