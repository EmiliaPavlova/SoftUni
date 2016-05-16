namespace BidSystem.RestServices.Models
{
    using System;
    using System.Linq.Expressions;

    using BidSystem.Data.Models;

    public class BidOutputModel
    {
        public int Id { get; set; }

        public int OfferId { get; set; }

        public DateTime DateCreated { get; set; }

        public string Bidder { get; set; }

        public decimal OfferedPrice { get; set; }

        public string Comment { get; set; }

        public static Expression<Func<Bid, BidOutputModel>> FromBid
        {
            get
            {
                return b => new BidOutputModel()
                {
                    Id = b.Id,
                    OfferId = b.OfferId,
                    DateCreated = b.DateCreated,
                    Bidder = b.Bidder.UserName,
                    OfferedPrice = b.OfferedPrice,
                    Comment = b.Comment
                };
            }
        }
    }
}
