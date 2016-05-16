namespace BidSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Offer
    {
        public Offer()
        {
            this.Bids = new HashSet<Bid>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string SellerId { get; set; }

        public virtual User Seller { get; set; }

        [Required]
        public decimal InitialPrice { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required]
        public DateTime ExpirationDateTime { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}
