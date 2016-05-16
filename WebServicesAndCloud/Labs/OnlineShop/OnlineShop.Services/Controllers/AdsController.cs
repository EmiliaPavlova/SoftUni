namespace OnlineShop.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.WebSockets;
    using Data;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Models;
    using OnlineShop.Models;

    [Authorize]
    public class AdsController : BaseApiController
    {
        public AdsController() : base()
        {
        }

        public AdsController(IOnlineShopData onlineShopData, IUserIdProvider userIdProvider)
            : base(onlineShopData, userIdProvider)
        {
        }
        
        //Get api/ads
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult OpenAds()
        {
            var openAds = this.Data.Ads.All()
                .Where(a => a.Status == AdStatus.Open)
                .OrderBy(a => a.Type.Name)
                .ThenBy(a => a.PostedOn)
                .Select(AdViewModel.Create);

            return this.Ok(openAds);
        }

        [HttpPost]
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            var userId = this.UserIdProvider.GetUserId();
            if (userId == null)
            {
                return this.BadRequest("UserId cannot be null");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            if (!model.Categories.Any() || model.Categories.Count() > 3)
            {
                return this.BadRequest("Categories count cannot be " + model.Categories.Count());
            }

            var dbType = this.Data.AdTypes.All().FirstOrDefault(c => c.Id == model.TypeId);
            if (dbType == null)
            {
                return this.BadRequest("No type with id " + model.TypeId + " found!");
            }

            var categories = new List<Category>();
            foreach (var catId in model.Categories)
            {
                var cat = this.Data.Categories.All()
                    .FirstOrDefault(c => c.Id == catId);
                categories.Add(cat);
            }

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                PostedOn = DateTime.Now,
                Status = AdStatus.Open,
                OwnerId = userId,
                TypeId = model.TypeId,
                Categories = categories
            };

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var result = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }

        // PUT api/ads/{id}/close
        [HttpPut]
        [Route("api/ads/{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            Ad ad = this.Data.Ads.Find(id);
            if (ad == null)
            {
                return this.NotFound();
            }

            var userId = this.UserIdProvider.GetUserId();
            if (userId != ad.OwnerId)
            {
                return this.Unauthorized();
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;
            this.Data.SaveChanges();

            var result = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }
    }
}
