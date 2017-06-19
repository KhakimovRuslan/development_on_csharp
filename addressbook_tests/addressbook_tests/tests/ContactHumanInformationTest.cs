using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactHumanInformationTest : AuthTestBase
    {
        int index = 0;

        [Test]
        public void TestContactHumanInformation()
        {
            string fromHuman = app.Contacts.GetContactInformationFromHuman(index);
            string fromEdit = app.Contacts.GetContactInformationFromEditForm(index).GetDisplayForm();

            Assert.AreEqual(fromHuman, fromEdit);
           
        }
    }
}
