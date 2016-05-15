﻿namespace _6.EFCodeFirst_Phonebook.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Email
    {
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
