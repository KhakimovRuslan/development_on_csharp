using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests.tests
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void Sale()
        {
            double total = 999;
            bool vipClient = false;

            if (total > 1000 || !vipClient )
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма " + total);
            }
            else
            {
                //Console.Out.Write("Скидки нет, общая сумма " + total);
            }
        }
    }
}
