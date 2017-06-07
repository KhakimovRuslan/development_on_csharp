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

        public void CheckCountGroup()
        {
            manager.Navigator.GoToGroupsList();

            if (GetGroupCount() < 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Create(new GroupData("Для удаления"));
                }
            }
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsList();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    }   );
                }
            }           

            return new List<GroupData> (groupCache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
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
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupPage()
        {

            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
