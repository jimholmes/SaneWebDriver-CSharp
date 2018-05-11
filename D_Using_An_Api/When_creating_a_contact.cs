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
        ContactDataObject testContact;
        IWebDriver browser;
        WebDriverWait wait;
        [OneTimeSetUp]
        public void setup()
        {
            testContact = DataHelpers.Generate_random_contact();
            browser = new FirefoxDriver();
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));

            browser.Navigate().GoToUrl("http://jhdemos.azurewebsites.net/KendoGrid.html");

            ContactGridPageObject page = new ContactGridPageObject(browser);
            ContactPopUpPageObject create = page.GetContactPopUp();

            create.Company = testContact.Company;
            create.Region = testContact.Region;
            create.LName = testContact.LName;
            create.FName = testContact.FName;
            create.UpdateButton.Click();
        }

        [OneTimeTearDown]
        public void teardown()
        {
            DataHelpers.Delete_contact_by_id(testContact);
            browser.Quit();
        }

        [Test]
        public void contact_shows_on_grid()
        {
            ContactGridPageObject page = new ContactGridPageObject(browser);
            IWebElement row = 
                page.GetGridRowByIdSubstringContactName(testContact.LName);
            Assert.IsNotNull(row);
        }

        [Test]
        public void contact_properly_stored_in_database()
        {
            ContactDataObject contactFromDb = DataHelpers.Return_contact_by_id(testContact);
            Assert.AreEqual(contactFromDb.Region, testContact.Region);
            Assert.AreEqual(contactFromDb.Company, testContact.Company);
            Assert.AreEqual(contactFromDb.LName, testContact.LName);
            Assert.AreEqual(contactFromDb.FName, testContact.FName);

        }
    }
}
