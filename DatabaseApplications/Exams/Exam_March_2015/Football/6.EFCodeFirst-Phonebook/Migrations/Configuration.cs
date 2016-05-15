namespace _6.EFCodeFirst_Phonebook.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<_6.EFCodeFirst_Phonebook.PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_6.EFCodeFirst_Phonebook.PhonebookContext context)
        {
            if (!context.Contacts.Any())
            {
                var peter = new Contact()
                {
                    Name = "Peter Ivanov",
                    Position = "CTO",
                    Company = "Smart Ideas",
                    Phones = new HashSet<Phone>()
                    {
                        new Phone() {PhoneNumber = "+359 2 22 22 22"},
                        new Phone() {PhoneNumber = "+359 88 77 88 99"}
                    },
                    Emails = new HashSet<Email>()
                    {
                        new Email() {EmailAddress = "peter@gmail.com"},
                        new Email() {EmailAddress = "peter_ivanov@yahoo.com"}
                    },
                    Notes = "Friend from school"
                };
                context.Contacts.Add(peter);

                var maria = new Contact()
                {
                    Name = "Maria",
                    Phones = new HashSet<Phone>()
                    {
                        new Phone() { PhoneNumber = "+359 22 33 44 55" }
                    }
                };
                context.Contacts.Add(maria);

                var angie = new Contact()
                {
                    Name = "Angie Stanton",
                    Emails = new HashSet<Email>()
                    {
                        new Email() { EmailAddress = "info@angiestanton.com" }
                    },
                    Url = "http://angiestanton.com"
                };
                context.Contacts.Add(angie);

                context.SaveChanges();
            }
        }
    }
}
