using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Videos.Models
{
    public class Playlist
    {
        private ICollection<Video> videos;
        //private ICollection<Tag> tags;

        public Playlist()
        {
            this.videos = new HashSet<Video>();
            //this.tags = new HashSet<Tag>();

        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UsernameId { get; set; }

        public virtual ApplicationUser Username { get; set; }

        public virtual ICollection<Video> Videos
        {
            get { return this.videos; }
            set { this.videos = value; }
        }

        //public virtual ICollection<Tag> Tags
        //{
        //    get { return this.tags; }
        //    set { this.tags = value; }
        //}
    }
}