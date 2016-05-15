namespace Student_System.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public ResouceType ResouceType { get; set; }

        [Required]
        public string Url { get; set; }

        public int? CourseLicenseId { get; set; }

        public CourseLicense License { get; set; }
    }
}
