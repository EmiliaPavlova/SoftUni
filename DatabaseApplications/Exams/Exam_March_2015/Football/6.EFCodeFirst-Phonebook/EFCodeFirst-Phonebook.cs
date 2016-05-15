namespace _6.EFCodeFirst_Phonebook
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhonebookContext();
            var contacts = context.Contacts
                .Include(c => c.Phones)
                .Include(c => c.Emails)
                .ToList();
            foreach (var contact in contacts)
            {
                Console.WriteLine("Name: {0}", contact.Name);
                //Console.WriteLine(" Position: {0}", contact.Position);
                //Console.WriteLine(" Company: {0}", contact.Company);
                Console.WriteLine(" Emails: {0}", 
                    string.Join(", ", contact.Emails.Select(e => e.EmailAddress)));
                Console.WriteLine(" Phones: {0}", 
                    string.Join(", ", contact.Phones.Select(p => p.PhoneNumber)));
                //Console.WriteLine("  Url: {0}", contact.Url);
                //Console.WriteLine("  Notes: {0}", contact.Notes);
            }
        }
    }
}
