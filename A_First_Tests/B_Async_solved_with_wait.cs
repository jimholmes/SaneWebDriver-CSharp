using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.A_First_Tests
{
    [TestFixture]
    public class B_Async_solved_with_wait
    {
        [Test]
        public void grid_appears_on_page_and_has_rows() 
        {
            IWebDriver browser = new FirefoxDriver();
            browser.Navigate().GoToUrl("http://demosite.com/KendoGrid.html");
            //browser.Navigate().GoToUrl("http://jhdemos.azurewebsites.net/KendoGrid.html");

            IWebElement grid = browser.FindElement(By.Id("grid"));
            Assert.IsNotNull(grid);

            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//tbody/tr")));
            IList<IWebElement> rows = browser.FindElements(By.XPath("//tbody/tr"));
            
            Assert.IsNotEmpty(rows);

            browser.Quit();
        }
    }
}
