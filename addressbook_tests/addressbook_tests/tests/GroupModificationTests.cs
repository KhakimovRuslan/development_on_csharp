﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.IsElementPresent(By.CssSelector("[name*=selected]")) == false)
            {
                app.Groups.Create(new GroupData("123"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData myData = new GroupData("zzz","456", "789");

            app.Groups.Modify(0, myData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = myData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
