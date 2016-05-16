namespace BidSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bid
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BidderId { get; set; }

        public virtual User Bidder { get; set; }

        [Required]
        public int OfferId { get; set; }

        public virtual Offer Offer { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public decimal OfferedPrice { get; set; }

        public string Comment { get; set; }
    }
}
