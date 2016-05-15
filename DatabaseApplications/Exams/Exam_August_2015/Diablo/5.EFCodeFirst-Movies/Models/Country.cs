namespace _5.EFCodeFirst_Movies.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public Country()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; } 
    }
}
