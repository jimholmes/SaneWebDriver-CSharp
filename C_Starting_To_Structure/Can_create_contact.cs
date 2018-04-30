using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneWebDriver_CSharp.C_Starting_To_Structure
{
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
        }

    }
}
