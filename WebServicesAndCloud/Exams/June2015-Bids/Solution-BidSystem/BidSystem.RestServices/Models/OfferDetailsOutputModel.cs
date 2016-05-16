namespace BidSystem.RestServices.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using BidSystem.Data.Models;
    using System;
    using System.Linq.Expressions;

    public class OfferDetailsOutputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Seller { get; set; }

        public DateTime DatePublished { get; set; }

        public decimal InitialPrice { get; set; }

        public DateTime ExpirationDateTime { get; set; }

        public bool IsExpired { get; set; }

        public string BidWinner { get; set; }
        
        public IEnumerable<BidOutputModel> Bids { get; set; }
        
        public static Expression<Func<Offer, OfferDetailsOutputModel>> FromOffer
        {
            get
            {
                return o => new OfferDetailsOutputModel()
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    Seller = o.Seller.UserName,
                    DatePublished = o.DatePublished,
                    InitialPrice = o.InitialPrice,
                    ExpirationDateTime = o.ExpirationDateTime,
                    IsExpired = o.ExpirationDateTime <= DateTime.Now,
                    BidWinner = o.ExpirationDateTime <= DateTime.Now && o.Bids.Count > 0 ? 
                        o.Bids.OrderByDescending(b => b.OfferedPrice).FirstOrDefault().Bidder.UserName :
                        null,
                    Bids = o.Bids.AsQueryable().OrderByDescending(b => b.Id).Select(BidOutputModel.FromBid)
                };
            }
        }
    }
}