namespace _7.ImportContactsFromJSON
{
    public class ContactDTO
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Site { get; set; }

        public string Notes { get; set; }

        public virtual string[] Emails { get; set; }

        public virtual string[] Phones { get; set; }
    }
}
