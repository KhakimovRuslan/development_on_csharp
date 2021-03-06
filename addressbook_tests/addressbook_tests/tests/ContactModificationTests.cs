﻿using System;
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
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GoToHomePage();

            app.Contacts.CheckCountContact();

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData newData = new ContactData("Petr", "Petrov");

            ContactData toBeModify = oldContacts[0];

            app.Contacts.Modify(toBeModify.Id, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            toBeModify.Firstname = newData.Firstname;
            toBeModify.Lastname = newData.Lastname;
            //oldContacts.Sort();
            //newContacts.Sort();

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
