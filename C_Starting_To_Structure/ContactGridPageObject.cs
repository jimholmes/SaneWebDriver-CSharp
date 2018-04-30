using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.C_Starting_To_Structure
{



    public class ContactGridPageObject
    {
        public static string GRID_ID = "grid";
        public static string CREATE_BTN_ID = "create_btn";

        public IWebElement GetContactGrid(IWebDriver browser)
        {
            return browser.FindElement(By.Id(GRID_ID));
        }

        public IWebElement GetCreateButton(IWebDriver browser)
        {
            return browser.FindElement(By.Id(CREATE_BTN_ID));
        }

        public IWebElement GetGridRowById(IWebDriver browser, string rowId)
        {
            return browser.FindElement(By.Id(rowId));
        }

        /*
         * Grid as currently configured appends contact's LName to the dynamically
         * generated ID, in the form of
         *              48-Holmes
         * Ergo, we can use the CSS selector id$="Holmes" to match. Yay.
         */
        public IWebElement GetGridRowByContactName(IWebDriver browser, string contactName)
        {
            string selector = "tr[id$='" + contactName + "']";
            return browser.FindElement(By.CssSelector(selector));
        }

        public IWebElement GetRowByRowTextContent (IWebDriver browser, string contentText)
        {
            string contentXpath = "//tbody/tr[contains(.," + contentText + ")]";
            return browser.FindElement(By.XPath(contentXpath));
        }

        public bool WaitUntilGridIsPopulatedWithRows(IWebDriver browser)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//tbody/tr")));

            return true;
        }
    }

 
}
