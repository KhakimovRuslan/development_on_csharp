using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();

            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int j, ContactData newData)
        {
            //if (driver.FindElements(By.CssSelector("[name=entry]")).Count < j)
            //{
            //    throw new Exception("Количество элментов превышено");
            //}
            //else
            //{
                SelectContact(j);
                ClickEditContact(j);
                FillContactForm(newData);
                SubmitContactModification();
                manager.Navigator.ReturnToHomePage();
                return this;
            //}
            

        }

        public ContactHelper Remove(int j)
        {
            //if (driver.FindElements(By.CssSelector("[name=entry]")).Count < j)
            //{
            //    throw new Exception("Количество элментов превышено");
            //}
            //else
            //{

                SelectContact(j);
                DeleteContact();

                manager.Navigator.ReturnToHomePage();
                return this;
            //}
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.CssSelector("[value = Delete]")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.CssSelector("[value=Update]")).Click();
            return this;
        }

        public ContactHelper ClickEditContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + index +"]")).Click();
            return this;
        }

    }
}
