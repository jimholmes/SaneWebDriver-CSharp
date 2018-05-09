using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.Support
{
    public class ContactGridPageObject
    {
        public static string GRID_ID = "grid";
        public static string CREATE_BTN_ID = "create_btn";

        public IWebElement CreateButton;

        private IWebDriver browser;

        public ContactGridPageObject (IWebDriver browser)
        {
            this.browser = browser;
        }

        public IWebElement GetContactGrid()
        {
            return browser.FindElement(By.Id(GRID_ID));
        }

        public IWebElement GetCreateButton()
        {
            return browser.FindElement(By.Id(CREATE_BTN_ID));
        }

        public ContactPopUpPageObject GetContactPopUp()
        {
            return new ContactPopUpPageObject(browser);
        }

        public IWebElement GetGridRowById(string rowId)
        {
            return browser.FindElement(By.Id(rowId));
        }

        /*
         * Grid as currently configured appends contact's LName to the dynamically
         * generated ID, in the form of
         *              48-Holmes
         * Ergo, we can use the CSS selector id$="Holmes" to match. Yay.
         */
        public IWebElement GetGridRowByContactName( string contactName)
        {
            string selector = "tr[id$='" + contactName + "']";
            return browser.FindElement(By.CssSelector(selector));
        }

        public IWebElement GetRowByRowTextContent (string contentText)
        {
            string contentXpath = "//tbody/tr[contains(.," + contentText + ")]";
            return browser.FindElement(By.XPath(contentXpath));
        }

        public bool WaitUntilGridIsPopulatedWithRows()
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//tbody/tr")));

            return true;
        }
    }

 
}
