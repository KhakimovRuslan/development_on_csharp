﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private StringBuilder fullInformation;

        public ContactData(string firstname, string lastname, string middlename = null)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
        }

        public ContactData()
        {
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int intLastName = Lastname.CompareTo(other.Lastname);
            if (intLastName == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return intLastName;

        }

        public override string ToString()
        {
            return "firstname=" + Firstname + "\nlastname= " + Lastname + "\nmiddlename=" + Middlename;
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string GetDisplayForm()
        {
            fullInformation = new StringBuilder();
            fullInformation.AppendLine(Firstname + " " + Lastname);
            CheckProperty(Address);
            CheckPhones();
            CheckEmails();
            return fullInformation.ToString();
        }

        private void CheckPhones()
        {
            CheckProperties(HomePhone, MobilePhone, WorkPhone);
            CheckProperty(HomePhone, "H: ");
            CheckProperty(MobilePhone, "M: ");
            CheckProperty(WorkPhone, "W: ");
        }

        private void CheckEmails()
        {
            CheckProperties(Email, Email2, Email3);
            CheckProperty(Email);
            CheckProperty(Email2);
            CheckProperty(Email3);
        }

        private void CheckProperties(params string[] parts)
        {
            foreach (var part in parts)
            {
                if (string.IsNullOrEmpty(part)) continue;
                fullInformation.AppendLine();
                return;
            }
        }


        private void CheckProperty(string inform, string prefix = "")
        {
            if (string.IsNullOrEmpty(inform)) return;
            fullInformation.AppendLine(prefix + inform);
        }

        public string AllPhones
        {
            get
            {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
         }

        public string CleanUp(string phone)
        {
            if(phone == null || phone =="")
            {
                return  "";
            }
            return Regex.Replace(phone,"[ -()]","") + "\r\n";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
