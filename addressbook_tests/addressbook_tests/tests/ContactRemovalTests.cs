using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {           
            if (app.Driver.FindElements(By.CssSelector("[title=Details]")).Count < 2) //app.Contact.IsElementPresent(By.CssSelector("[title=Details]")) == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    app.Contact.Create(new ContactData("Sergey", "Sergeev", "Sergeevich"));
                }               
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Remove(0);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }             
    }
}
