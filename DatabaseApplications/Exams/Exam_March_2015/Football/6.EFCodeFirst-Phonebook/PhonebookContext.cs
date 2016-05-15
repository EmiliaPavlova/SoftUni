namespace _6.EFCodeFirst_Phonebook
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("name=PhonebookContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Email> Emails { get; set; }

        public virtual DbSet<Phone> Phones { get; set; } 
    }
}