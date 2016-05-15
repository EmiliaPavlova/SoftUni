namespace _5.EFCodeFirst_Movies.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Movies = new HashSet<Movie>();
            this.Ratings = new HashSet<Rating>();
        }
        
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
