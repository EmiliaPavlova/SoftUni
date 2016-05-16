using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videos.Models
{
    public class Video
    {
        private ICollection<Tag> tags;

        public Video()
        {
            this.tags = new HashSet<Tag>();
        }

        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        public string UsernameId { get; set; }

        public virtual ApplicationUser Username { get; set; }

        //public int PlaylistId { get; set; }

        //public virtual Playlist Playlist { get; set; }

        public VideoStatus Status { get; set; }

        [Required]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
