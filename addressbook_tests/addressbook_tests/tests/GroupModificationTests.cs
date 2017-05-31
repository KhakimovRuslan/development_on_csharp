﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {            
            GroupData newData = new GroupData("новая группа");
            newData.Header = "456";
            newData.Footer = "789";

            app.Groups.Modify(1, newData);
        }
    }
}
