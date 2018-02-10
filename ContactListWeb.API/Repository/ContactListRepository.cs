using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactListWeb.API.Models;
using ContactDB.Data;


namespace ContactListWeb.API.Repository
{
    public class ContactListRepository
    {
        private ContactListModel _contactModel;

        public ContactListRepository()
        {
            _contactModel = new ContactListModel();
        }

        public void AddData(List<ContactModel> contactModel)
        {
            for (int i = 0; i < contactModel.Count; i++)
            {
                var contquery = new ContactList
                {
                    ContactName = contactModel[i].ContactName,
                    ContactDateAdded = DateTime.Now,
                    ContactPhone = contactModel[i].ContactPhone,
                };
                _contactModel.ContactLists.Add(contquery);
            }
            _contactModel.SaveChanges();
        }

        public List<ContactList> GetData()
        {
            var custquery = _contactModel.ContactLists.ToList();
            return custquery;

        }
    }
}