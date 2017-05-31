using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseUrl;

        public NavigationHelper (ApplicationManager manager,string baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }
        public void GoToHomePage()
        {
            if (driver.Url == baseUrl + "/addressbook")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseUrl + "/addressbook/");
        }
        public void GoToGroupsList()
        {
            if(driver.Url == baseUrl + "/addressbook/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
