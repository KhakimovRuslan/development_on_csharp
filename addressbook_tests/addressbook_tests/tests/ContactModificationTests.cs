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

            List<ContactData> oldContacts = app.Contact.GetContactList();

            ContactData newData = new ContactData("Petr", "Petrov");

            app.Contact.Modify(0, newData);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
