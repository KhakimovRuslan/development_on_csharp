using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{

    [TestFixture]
    public class Log : AuthTestBase
    {

        [Test]
        public void Login()
        {
            if (app.Auth.GetLoggedUserName() != "admin")
            {
                Console.WriteLine("Not admin");
            }
            else
            {
                Console.WriteLine("you are admin");
            }

            
        }

    }
}
