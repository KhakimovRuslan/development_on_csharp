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
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.IsElementPresent(By.CssSelector("[name*=selected]")) == false)
            {
                app.Groups.Create(new GroupData("123"));
            }

            app.Groups.Modify(1, new GroupData("новая группа", "456", "789"));
        }
    }
}
