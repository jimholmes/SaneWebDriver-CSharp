using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.B_Organizing_A_Test
{ 
    [TestFixture]
    public class Validate_grid_loads_and_is_configured_properly
    {
        IWebDriver browser;
        WebDriverWait wait;
        [OneTimeSetUp]
        public void run_once_before_anything_else_in_this_fixture()
        {
            // ARRANGE
            browser = new FirefoxDriver();
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));

            browser.Navigate().GoToUrl("http://demosite.com/KendoGrid.html");
            //browser.Navigate().GoToUrl("http://jhdemos.azurewebsites.net/KendoGrid.html");
        }

        [OneTimeTearDown]
        public void run_once_after_everything_else_in_this_fixture()
        {
            browser.Quit();
        }

        [Test]
        public void grid_appears_on_page()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("grid")));
            
            IWebElement grid = browser.FindElement(By.Id("grid"));
            Assert.IsNotNull(grid);
        }
        [Test]
        public void grid_populates_with_rows()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//tbody/tr")));
            IList<IWebElement> rows = browser.FindElements(By.XPath("//tbody/tr"));
            Assert.IsNotEmpty(rows);
        }

        [Test]
        public void create_button_displays()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("create_btn")));
            IWebElement create = browser.FindElement(By.Id("create_btn"));
            Assert.IsTrue(create.Displayed);
        }
    }
}
