using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactListWeb.API.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }    
        public string ContactPhone { get; set; }
        public DateTime ContactDateAdded { get; set; }
    }
}