using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_test_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            GroupData newItem = new GroupData("toBeRemoved");
            List<GroupData> oldList = app.Groups.GetGroupList();
            if (oldList.Count == 1)
            {
                app.Groups.Add(newItem);
                app.Groups.Delete(newItem);
            }
            else
            {
                GroupData deleteItem = oldList[0];
                app.Groups.Delete(deleteItem);
            }

            List<GroupData> newList = app.Groups.GetGroupList();

            if (oldList.Count != 1)
            {
                oldList.RemoveAt(0);
            }
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
