using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {           
            if (app.Contact.IsElementPresent(By.CssSelector("[title=Details]")) == false)
            {
                app.Contact.Create(new ContactData("Sergey", "Sergeev", "Sergeevich"));
            }
            app.Contact.Remove(1);
        }             
    }
}
