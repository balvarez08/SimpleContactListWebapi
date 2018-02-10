using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Http;
using System.Linq;
using ContactDB.Data;
using ContactListWeb.API.Models;
using ContactListWeb.API.Controllers;
using ContactListWeb.API.Repository;

namespace ContactListWeb.API.Tests
{
    /// <summary>
    /// Summary description for ContactListUnitTest
    /// </summary>
    [TestClass]
    
    public class ContactListUnitTest
    {
        private ContactListModel _contactModelTest;
        private ContactListRepository _contactRepoTest;

        [TestInitialize]
        public void Setup()
        {
            _contactModelTest = new ContactListModel();
            _contactRepoTest = new ContactListRepository();
        }

        [TestMethod]
        public void AddContact_from_Controller_Test()
        {
            var controller = new ContactController();
            var item = GetContactList();
            var result = controller.addContact(item);
            Assert.IsNotNull(result);
            //Delete Test Record;
            CleanUpTestRecord();
        }
        [TestMethod]
        public void GetContact_from_Controller_Test()
        {
            var controller = new ContactController();
            var result = controller.getContact();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Add_Get_Customer_Repo_Test()
        {
            var custquery = _contactModelTest.ContactLists.ToList();
            if (custquery.Count > 0)
            {
                CleanUpTestRecord();
            }
            var contact = GetContactList();
            _contactRepoTest.AddData(contact);
            var count = _contactModelTest.ContactLists.Count();
            var getOneRecord = _contactModelTest.ContactLists.Where(i => i.ContactName == "Kobe Bryant").SingleOrDefault();

            var getCustData = _contactRepoTest.GetData();
            Assert.AreEqual(3, count);
            Assert.AreEqual(3, getCustData.Count());
            Assert.AreEqual("Kobe Bryant", getOneRecord.ContactName);
            //Delete Test Record;
            CleanUpTestRecord();

        }

        private void CleanUpTestRecord()
        {
            var all = from c in _contactModelTest.ContactLists select c;
            _contactModelTest.ContactLists.RemoveRange(all);
            _contactModelTest.SaveChanges();
        }

        private List<ContactModel> GetContactList()
        {
            var contactList = new List<ContactModel>();
            contactList.Add(new ContactModel { ContactName = "Michael Jordan", ContactPhone = "8552347857" });
            contactList.Add(new ContactModel { ContactName = "Kobe Bryant", ContactPhone = "8551113333" });
            contactList.Add(new ContactModel { ContactName = "Nick Foles", ContactPhone = "8558985677" });
            return contactList;
        }
    }
}
