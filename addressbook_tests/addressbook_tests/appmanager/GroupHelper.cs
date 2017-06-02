using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper (ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsList();

            //if (driver.FindElements(By.CssSelector("[name*=selected]")).Count < v)
            //{
            //    throw new Exception("Количество элментов превышено");
            //}
            //else
            //{
                SelectGroup(v);
                DeleteGroup();
                ReturnToGroupPage();
                return this;
            //}
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsList();

            //if (driver.FindElements(By.CssSelector("[name*=selected]")).Count < v)
            //{
            //    throw new Exception("Количество элментов превышено");
            //}
            //else
            //{
                SelectGroup(v);
                InitGroupModification();
                FillGroupform(newData);
                SubmitGroupModification();
                ReturnToGroupPage();
                return this;
            //}
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsList();

            InitGroupCreation();
            FillGroupform(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupform(GroupData group)
        {

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupPage()
        {

            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
