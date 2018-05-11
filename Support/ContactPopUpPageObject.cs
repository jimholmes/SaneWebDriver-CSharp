using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private static string UPDATE_BTN_XPATH =
            "//a[contains(@class,'k-grid-update')]";

        /*
         * KendoGrid's editor popup has an odd input which requires a
         * tab or focus event to actually update values on the grid.
         * Each Property setter method calls SetFocusToField which
         * WebDriver's Actions to focus
         * on a different field, thereby causing KendoGrid
         * to properly update.
         * 
         * This is the sort of stuff that comes from experience.
         * And pain.
         */
        public string Region
        {
            get { return region.Text; }
            set {
                region.SendKeys(value);
                SetFocusToField(company);
            }
        }

        public string Company
        {
            get { return company.Text; }
            set {
                company.SendKeys(value);
                SetFocusToField(region);
            }
        }

        public string LName
        {
            get { return lname.Text; }
            set {
                lname.SendKeys(value);
                SetFocusToField(fname);
            }
        }

        public string FName
        {
            get { return fname.Text; }
            set {
                fname.SendKeys(value);
                SetFocusToField(lname);
            }
        }

        public ContactPopUpPageObject(IWebDriver browser)
        {
            this.browser = browser;

            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("k-window-titlebar")));
            
            region = browser.FindElement(By.Name("Region"));
            company = browser.FindElement(By.Name("Company"));
            lname = browser.FindElement(By.Name("LName"));
            fname = browser.FindElement(By.Name("FName"));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(UPDATE_BTN_XPATH)));
            UpdateButton = browser.FindElement(By.XPath(UPDATE_BTN_XPATH));
        }

        //See comments above Setters in this class
        private void SetFocusToField(IWebElement field)
        {
            new Actions(browser).MoveToElement(field).Click().Perform();
        }
    }
}