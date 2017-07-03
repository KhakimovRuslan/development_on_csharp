using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsList();

            app.Groups.CheckCountGroup();

            List<GroupData> oldGroups = GroupData.GetAll();

            List<GroupData> UIgroups = app.Groups.GetGroupList();

            GroupData myData = new GroupData("zzz","456", "789");

            GroupData toBeModify = oldGroups[0];

            app.Groups.Modify(toBeModify.Id, myData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModify.Id)
                {
                    Assert.AreEqual(myData.Name, group.Name);
                }
            }
        }
    }
}
