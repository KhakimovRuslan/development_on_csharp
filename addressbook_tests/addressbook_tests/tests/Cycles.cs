using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests.tests
{
    [TestClass]
    public class Cycles
    {
        [TestMethod]
        public void Cycle()
        {
            //string[] s = new string[] { "I", "want", "to", "sleep" };

            //foreach (string element in s)             //foreach
            //{
            //    System.Console.Out.Write(element + "\n");
            //}

            //for (int i = 0; i < s.Length; i++)            //for
            //{
            //    System.Console.Out.Write(s[i] + "\n");
            //}

            //IWebDriver driver = null;             //while
            //int attempt = 0;

            //while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    attempt = attempt++;
            //}

            //// .....

            IWebDriver driver = null;             //while
            int attempt = 0;

            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt = attempt++;
            }
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);

            // .....
        }
    }
}
