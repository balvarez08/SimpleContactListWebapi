using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using ContactListWeb.API.Repository;
using ContactListWeb.API.Models;

namespace ContactListWeb.API.Controllers
{
    public class ContactController : ApiController
    {
        public ContactListRepository _contactRepo;

        public ContactController()
        {
            _contactRepo = new ContactListRepository();
        }

        [Route("~/api/getcontact/")]
        [HttpGet]
        public IHttpActionResult getContact()
        {
            var query = _contactRepo.GetData();
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(query);
            return Ok(json);
        }

        [Route("~/api/addcontact")]
        [HttpPost]
        public IHttpActionResult addContact([FromBody]List<ContactModel> contactmodel)
        {
            _contactRepo.AddData(contactmodel);
            return Ok("Contact Added");

        }
    }
}
