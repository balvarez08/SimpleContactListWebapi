namespace ContactDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactList")]
    public partial class ContactList
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(12)]
        public string ContactPhone { get; set; }

        public DateTime? ContactDateAdded { get; set; }
    }
}
