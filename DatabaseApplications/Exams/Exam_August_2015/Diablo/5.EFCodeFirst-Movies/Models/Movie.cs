namespace _5.EFCodeFirst_Movies.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public Movie()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        public AgeRrestriction AgeRrestriction { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
