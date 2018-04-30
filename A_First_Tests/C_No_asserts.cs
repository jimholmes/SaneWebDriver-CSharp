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
            //browser.Navigate().GoToUrl("http://jhdemos.azurewebsites.net/KendoGrid.html");
            browser.Navigate().GoToUrl("http://demosite.com/KendoGrid.html");

            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.Id("grid")));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//tbody/tr")));

            browser.Quit();
        }
    }
}
