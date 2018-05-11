using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SaneWebDriver_CSharp.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.C_Starting_To_Structure
{
    /*
     * This class shows making use of setup and teardown methods to sort out
     * parts of functionality.
     * 
     * The test itself is still rather messy and should have data setup 
     * handled elsewhere -- but you'll see that in the API examples!
     */

    [TestFixture]
    public class Can_create_contact
    {
        IWebDriver browser;
        WebDriverWait wait;

        [OneTimeSetUp]
        public void setup()
        {
            browser = new FirefoxDriver();
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            browser.Navigate().GoToUrl(Settings.SITE_URL + "/KendoGrid.html");
        }

        [OneTimeTearDown]
        public void teardown()
        {
            browser.Quit();
        }

        [Test]
        public void create_contact_appears_on_grid()
        {
            ContactDataObject contact = new ContactDataObject();
            contact.Company = "Guidepost Systems LLC";
            contact.Region = "Oregon";
            contact.LName = "Holmes";
            contact.FName = "Lydia";

            ContactGridPageObject gridPage = new ContactGridPageObject(browser);
            ContactPopUpPageObject editWindow = gridPage.GetContactPopUp();

            editWindow.Company = contact.Company;
            editWindow.Region = contact.Region;
            editWindow.LName = contact.LName;
            editWindow.FName = contact.FName;
            editWindow.UpdateButton.Click();
            string testXPath = "//tbody/tr[contains(.,'Lydia')]";
            wait.Until(ExpectedConditions.ElementExists(By.XPath(testXPath)));
            Assert.IsNotNull(gridPage.GetRowByRowTextContent("Lydia"));
        }

    }
}
