using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.A_First_Tests
{
    [TestFixture]
    public class A_Initial_version
    {
        [Test]
        public void grid_appears_on_page_and_has_rows()
        {
            // ARRANGE
            IWebDriver browser = new FirefoxDriver();
            browser.Navigate().GoToUrl("http://demosite.com/KendoGrid.html");
            //browser.Navigate().GoToUrl("http://jhdemos.azurewebsites.net/KendoGrid.html");

            // ACT
            IWebElement grid = browser.FindElement(By.Id("grid"));
            // ASSERT
            Assert.IsNotNull(grid);

            IList<IWebElement> rows = browser.FindElements(By.XPath("//tbody/tr"));
            Assert.IsNotEmpty(rows);

            browser.Quit();
        }
    }
}
