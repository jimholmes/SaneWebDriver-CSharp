using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SaneWebDriver_CSharp.Support
{
    public class ContactPopUpPageObject
    {
        private IWebDriver browser;

        private IWebElement region;
        private IWebElement company;
        private IWebElement lname;
        private IWebElement fname;

        public IWebElement UpdateButton;

        public string Region
        {
            get { return region.Text; }
            set { region.SendKeys(value); }
        }

        public string Company
        {
            get { return company.Text; }
            set { company.SendKeys(value); }
        }

        public string LName
        {
            get { return lname.Text; }
            set { lname.SendKeys(value); }
        }

        public string FName
        {
            get { return fname.Text; }
            set { fname.SendKeys(value); }
        }

        public ContactPopUpPageObject(IWebDriver browser)
        {
            this.browser = browser;

            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("k-window-titlebar k-header")));
            region = browser.FindElement(By.Name("Region"));
            company = browser.FindElement(By.Name("Company"));
            lname = browser.FindElement(By.Name("LName"));
            fname = browser.FindElement(By.Name("FName"));
            UpdateButton = browser.FindElement(By.ClassName("k-button k-button-icontext k-grid-update"));
        }
    }
}