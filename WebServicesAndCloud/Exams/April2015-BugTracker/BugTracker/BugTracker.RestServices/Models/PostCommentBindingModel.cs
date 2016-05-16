namespace BugTracker.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PostCommentBindingModel
    {
        [Required]
        public string Text { get; set; }
    }
}