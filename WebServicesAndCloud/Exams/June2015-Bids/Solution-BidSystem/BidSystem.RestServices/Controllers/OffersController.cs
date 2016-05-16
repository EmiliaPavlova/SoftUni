namespace BidSystem.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BidSystem.Data.Models;
    using BidSystem.Data.UnitOfWork;
    using BidSystem.RestServices.Models;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/offers")]
    public class OffersController : ApiController
    {
        private readonly IBidSystemData db;

        public OffersController() : this(new BidSystemData())
        {
        }

        public OffersController(IBidSystemData data)
        {
            this.db = data;
        }

        // GET: api/offers/all
        [HttpGet]
        [Route("all")]
        public IQueryable<OfferOutputModel> GetAllOffers()
        {
            var offers = db.Offers.All()
                .OrderByDescending(o => o.DatePublished)
                .ThenByDescending(o => o.Id)
                .Select(OfferOutputModel.FromOffer);
            return offers;
        }

        // GET: api/offers/active
        [HttpGet]
        [Route("active")]
        public IQueryable<OfferOutputModel> GetActiveOffers()
        {
            var offers = db.Offers.All()
                .Where(o => o.ExpirationDateTime > DateTime.Now)
                .OrderBy(o => o.ExpirationDateTime)
                .ThenBy(o => o.Id)
                .Select(OfferOutputModel.FromOffer);
            return offers;
        }

        // GET: api/offers/expired
        [HttpGet]
        [Route("expired")]
        public IQueryable<OfferOutputModel> GetExpiredOffers()
        {
            var offers = db.Offers.All()
                .Where(o => o.ExpirationDateTime <= DateTime.Now)
                .OrderBy(o => o.ExpirationDateTime)
                .ThenBy(o => o.Id)
                .Select(OfferOutputModel.FromOffer);
            return offers;
        }

        // GET: api/offers/details/{id}
        [HttpGet]
        [Route("details/{id}", Name = "OfferDetails")]
        public IHttpActionResult GetOfferDetails(int id)
        {
            var offerDetails = db.Offers.All()
                .Where(o => o.Id == id)
                .Select(OfferDetailsOutputModel.FromOffer)
                .FirstOrDefault();

            if (offerDetails == null)
            {
                return this.NotFound();
            }

            return Ok(offerDetails);
        }

        // GET: api/offers/my
        [HttpGet]
        [Authorize]
        [Route("my")]
        public IQueryable<OfferOutputModel> GetUserOffers()
        {
            var currentUserId = User.Identity.GetUserId();
            var offers = db.Offers.All()
                .Where(o => o.SellerId == currentUserId)
                .OrderBy(o => o.DatePublished)
                .ThenBy(o => o.Id)
                .Select(OfferOutputModel.FromOffer);
            return offers;
        }

        // POST: api/offers
        [HttpPost]
        [Authorize]
        public IHttpActionResult CrateOffer(OfferInputModel offerData)
        {
            if (offerData == null)
            {
                return BadRequest("Missing offer data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserId = User.Identity.GetUserId();
            var seller = this.db.UserStore.FindByIdAsync(currentUserId).Result;
            if (seller == null)
            {
                return this.Unauthorized();
            }

            var offer = new Offer()
            {
                Title = offerData.Title,
                Description = offerData.Description,
                DatePublished = DateTime.Now,
                SellerId = currentUserId,
                InitialPrice = offerData.InitialPrice,
                ExpirationDateTime = offerData.ExpirationDateTime
            };
            db.Offers.Add(offer);
            db.SaveChanges();

            return this.CreatedAtRoute("OfferDetails", 
                new { id = offer.Id},
                new { offer.Id, Seller = seller.UserName, Message = "Offer created." });
        }
    }
}
