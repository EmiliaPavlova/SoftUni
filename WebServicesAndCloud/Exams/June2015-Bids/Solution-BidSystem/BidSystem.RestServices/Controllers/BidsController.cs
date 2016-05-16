namespace BidSystem.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BidSystem.Data.Models;
    using BidSystem.Data.UnitOfWork;
    using BidSystem.RestServices.Models;

    using Microsoft.AspNet.Identity;

    [Authorize]
    [RoutePrefix("api")]
    public class BidsController : ApiController
    {
        private readonly IBidSystemData db;

        public BidsController() : this(new BidSystemData())
        {
        }

        public BidsController(IBidSystemData data)
        {
            this.db = data;
        }

        // GET: api/bids/my
        [HttpGet]
        [Route("bids/my")]
        public IQueryable<BidOutputModel> GetUserBids()
        {
            var currentUserId = User.Identity.GetUserId();
            var bids = db.Bids.All()
                .Where(b => b.BidderId == currentUserId)
                .OrderByDescending(b => b.DateCreated)
                .ThenByDescending(b => b.Id)
                .Select(BidOutputModel.FromBid);
            return bids;
        }

        // GET: api/bids/won
        [HttpGet]
        [Route("bids/won")]
        public IQueryable<BidOutputModel> GetUserWonBids()
        {
            var currentUserId = User.Identity.GetUserId();
            var bids = db.Bids.All()
                .Where(b => b.BidderId == currentUserId)
                .Where(b => b.OfferedPrice == b.Offer.Bids.Max(bid => bid.OfferedPrice))
                .OrderBy(b => b.DateCreated)
                .ThenBy(b => b.Id)
                .Select(BidOutputModel.FromBid);
            return bids;
        }

        // POST: api/offers/{id}/bid
        [HttpPost]
        [Route("offers/{id}/bid")]
        public IHttpActionResult Bid(int id, BidInputModel bidData)
        {
            if (bidData == null)
            {
                return BadRequest("Missing bid data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offer = this.db.Offers.All()
                .Where(o => o.Id == id)
                .Select(o => new
                {
                    InitialPrice = o.InitialPrice,
                    ExpirationDateTime = o.ExpirationDateTime,
                    Bids = o.Bids.Select(b => b.OfferedPrice)
                })
                .FirstOrDefault();
            if (offer == null)
            {
                return this.NotFound();
            }

            if (offer.ExpirationDateTime < DateTime.Now)
            {
                return this.BadRequest("Offer has expired.");
            }

            var maxBidPrice = offer.InitialPrice;
            if (offer.Bids.Any())
            {
                maxBidPrice = offer.Bids.Max();
            }

            if (bidData.BidPrice <= maxBidPrice)
            {
                return this.BadRequest("Your bid should be > " + maxBidPrice);
            }

            var currentUserId = User.Identity.GetUserId();
            var user = this.db.UserStore.FindByIdAsync(currentUserId).Result;
            if (user == null)
            {
                return this.Unauthorized();
            }

            var bid = new Bid()
            {
                OfferId = id,
                BidderId = currentUserId,
                OfferedPrice = bidData.BidPrice,
                Comment = bidData.Comment,
                DateCreated = DateTime.Now
            };
            db.Bids.Add(bid);
            db.SaveChanges();

            return this.Ok(
                new { bid.Id, Bidder = user.UserName, Message = "Bid created." });
        }
    }
}
