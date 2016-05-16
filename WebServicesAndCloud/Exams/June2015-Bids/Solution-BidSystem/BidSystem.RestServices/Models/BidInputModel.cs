namespace BidSystem.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BidInputModel
    {
        [Required]
        public decimal BidPrice { get; set; }

        public string Comment { get; set; }
    }
}
