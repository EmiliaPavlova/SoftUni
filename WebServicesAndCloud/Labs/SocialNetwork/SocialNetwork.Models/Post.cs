namespace SocialNetwork.Models
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<Comment> comments;
        private ICollection<PostLike> likes;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<PostLike>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public int WallOwnerId { get; set; }

        public virtual ApplicationUser WallOwner { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<PostLike> Likes
        {
            get { return this.Likes; }
            set { this.Likes = value; }
        }
    }
}
