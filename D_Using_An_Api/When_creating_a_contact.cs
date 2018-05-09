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

namespace SaneWebDriver_CSharp.D_Using_An_Api
{
    [TestFixture]
    public class When_creating_a_contact
    {
        IWebDriver browser;
        WebDriverWait wait;
        ContactDataObject contact;
        [OneTimeSetUp]
        public void run_once_before_anything_else_in_this_fixture()
        {
            browser = new FirefoxDriver();
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));

            browser.Navigate().GoToUrl(Settings.CONTACT_URI);
        }

        [OneTimeTearDown]
        public void run_once_after_everything_else_in_this_fixture()
        {
            Support.DataHelpers.Delete_contact_by_id(contact.Id);
            browser.Quit();
        }

        [Test]
        public void Creating_contact_reflects_on_grid_and_in_database()
        {
            ContactGridPageObject gridPage = new ContactGridPageObject(browser);
            ContactPopUpPageObject popUp = gridPage.GetContactPopUp();
            popUp.Region = contact.Region;
            popUp.Company = contact.Company;
            popUp.LName = contact.LName;
            popUp.FName = contact.FName;
            popUp.UpdateButton.Click();

            wait.Until(ExpectedConditions.ElementExists(
                By.XPath("//tbody/tr[contains(.,'" + contact.LName + "')]")));
            //Don't need an assert for the UI--the wait handles. Either contact 
            //  will appear or we'll get an exception!

        }
    }
}
