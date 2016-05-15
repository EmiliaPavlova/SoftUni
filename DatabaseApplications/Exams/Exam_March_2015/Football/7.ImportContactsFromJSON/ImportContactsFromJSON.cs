namespace _7.ImportContactsFromJSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _6.EFCodeFirst_Phonebook;
    using _6.EFCodeFirst_Phonebook.Models;

    class ImportContactsFromJSON
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"..\..\contacts.json");
            var jsonSerializer = new JavaScriptSerializer();
            var parsedContacts = jsonSerializer.Deserialize<ContactDTO[]>(json);

            foreach (var parsedContact in parsedContacts)
            {
                try
                {
                    ImportContactToDatabase(parsedContact);
                    Console.WriteLine("Contact {0} imported", parsedContact.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void ImportContactToDatabase(ContactDTO contactDto)
        {
            if (contactDto.Name == null)
            {
                throw new ArgumentException("Name is required");
            }
            var newContact = new Contact()
            {
                Name = contactDto.Name,
                Company = contactDto.Company,
                Position = contactDto.Position,
                Url = contactDto.Site,
                Notes = contactDto.Notes
            };
            if (contactDto.Emails != null)
            {
                newContact.Emails = contactDto.Emails
                    .Select(e => new Email() {EmailAddress = e})
                    .ToList();
            }
            if (contactDto.Phones != null)
            {
                newContact.Phones = contactDto.Phones
                    .Select(p => new Phone() { PhoneNumber = p })
                    .ToList();
            }
            var context = new PhonebookContext();
            context.Contacts.Add(newContact);
            context.SaveChanges();
        }
    }
}
