namespace ContactDB.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContactListModel : DbContext
    {
        public ContactListModel()
            : base("name=ContactListModel")
        {
        }

        public virtual DbSet<ContactList> ContactLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactList>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactList>()
                .Property(e => e.ContactPhone)
                .IsUnicode(false);
        }
    }
}
