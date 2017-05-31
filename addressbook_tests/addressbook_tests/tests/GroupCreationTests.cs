using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    { 
        [Test]
        public void GroupCreationtTraining()
        {
            GroupData group = new GroupData("123");
            group.Header = "456";
            group.Footer = "789";

            app.Groups.Create(group);
        }
             
        [Test]
        public void EmptyGroupCreationtTraining()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";


            app.Groups.Create(group);
        }
    }
}
