namespace SocialNetwork.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddPostBindingModel
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string WallOwnerUsername { get; set; }
    }
}