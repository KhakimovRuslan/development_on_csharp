using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests.tests
{

    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

                if (app.Contact.IsElementPresent(By.CssSelector("[title=Details]")) == false)
                {
                    app.Contact.Create(new ContactData("Sergey", "Sergeev", "Sergeevich"));
                }
                app.Contact.Modify(1, new ContactData("Petr", "Petrov", "Petrovich"));
            //}
        }
    }
}
