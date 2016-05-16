using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videos.Models
{
    public class Tag
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string TagName { get; set; }

        [ForeignKey("Video")]
        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        [ForeignKey("Playlist")]
        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }

        public bool IsAdultContent { get; set; }

        [ForeignKey("Username")]
        public string UsernameId { get; set; }

        public virtual ApplicationUser Username { get; set; }
    }
}