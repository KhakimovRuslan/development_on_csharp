using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeleteContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestDeleteContactToGroup()
        {
            app.Groups.CheckCountGroup();
            GroupData group = GroupData.GetAll()[0];
            int oldCount = app.Contacts.CountContactToGroup(group.Id);
            app.Navigator.GoToHomePage();
            List<ContactData> oldList = group.GetContacts();
            app.Contacts.ClearGroupFilter();
            app.Contacts.DeleteContactFromGroup(group.Id);
            int newCount = app.Contacts.CountContactToGroup(group.Id);
            if (oldCount == 1)
            {
                Assert.AreEqual(oldCount, newCount);
            }
            else
            {
                Assert.AreEqual(oldCount, newCount + 1);
            }
        }
    }
}
