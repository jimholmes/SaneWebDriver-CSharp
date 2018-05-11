using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SaneWebDriver_CSharp.A_First_Tests
{
    [TestFixture]
    public class C_No_asserts
    {
        [Test]
        public void grid_appears_on_page_and_has_rows()
        {
            IWebDriver browser = new FirefoxDriver();
            browser.Navigate().GoToUrl("http://jhdemos.azurewebsites.net/KendoGrid.html");
            

            /* Note there are no Asserts! NUnit tests will pass and show green
            *  as long as there are no Assert failures or exceptions.
            *  This test will pass unless either wait.Until condition throws
            *  an exception, meaning either the grid doesn't display or
            *  rows don't populate.
            *  
            *  I don't particularly care for this style as it takes me a bit of
            *  extra time to mentally unwind what's going on with the test.
            *  I prefer an explicit "Assert" for readability.
            */
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.Id("grid")));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//tbody/tr")));

            browser.Quit();
        }
    }
}
