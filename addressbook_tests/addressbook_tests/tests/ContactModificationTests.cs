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
            app.Navigator.GoToHomePage();

            if (app.Contacts.IsElementPresent(By.CssSelector("[title=Details]")) == false)
                {
                    app.Contacts.Create(new ContactData("Sergey", "Sergeev", "Sergeevich"));
                }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newData = new ContactData("Petr", "Petrov");

            ContactData toBeModify = oldContacts[0];

            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if(contact.Id == toBeModify.Id)
                {
                    Assert.AreEqual(toBeModify.Firstname, contact.Firstname);
                    Assert.AreEqual(toBeModify.Lastname, contact.Lastname);
                }
            }

        }
    }
}
