using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Videos.Models;
using Videos.Rest.Models.BindingModels;
using Videos.Rest.Models.ViewModels;

namespace Videos.Rest.Controllers
{
    public class VideosController : BaseApiController
    {
        // GET /api/videos?locationId={locationId}
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetVideos()
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var data = this.Data.Videos
                .OrderBy(v => v.Username)
                .ThenBy(v => v.Title)
                .Select(VideoViewModel.Create)
                .ToList();

            return this.Ok(data);
        }

        // POST /api/videos Content-Type: application/json {"title":"{title}","locationId":"{id}"}
        [HttpPost]
        public IHttpActionResult AddVideo(AddVideoBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No data was sent.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var location = this.Data.Locations.Find(model.LocationId);
            if (location == null)
            {
                return this.BadRequest("Invalid location id: " + model.LocationId);
            }

            var loggedUserId = this.User.Identity.GetUserId();

            var video = new Video
            {
                Title = model.Title,
                LocationId = location.Id,
                UsernameId = loggedUserId
            };

            this.Data.Videos.Add(video);
            this.Data.SaveChanges();

            var result = this.Data.Videos
                .Where(v => v.Id == video.Id)
                .Select(VideoViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }
    }
}
