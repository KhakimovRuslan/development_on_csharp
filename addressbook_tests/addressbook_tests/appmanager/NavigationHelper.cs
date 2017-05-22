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
            driver.Navigate().GoToUrl(baseUrl + "/addressbook/");
        }
        public void GoToGroupsList()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
