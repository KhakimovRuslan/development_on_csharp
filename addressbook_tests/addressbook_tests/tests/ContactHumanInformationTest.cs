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
        int index = 1;

        [Test]
        public void TestContactHumanInformation()
        {
            List<string> fromHuman = app.Contacts.GetContactInformationFromHuman(index);
            List<string> fromEdit = app.Contacts.GetContactInformationFromEditFormCompareHuman(index);

            fromHuman.Sort();
            fromEdit.Sort();

            Assert.AreEqual(fromHuman, fromEdit);
           
        }
    }
}
