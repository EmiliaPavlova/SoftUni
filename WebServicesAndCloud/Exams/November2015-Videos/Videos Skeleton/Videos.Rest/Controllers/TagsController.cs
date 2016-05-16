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
    public class TagsController : BaseApiController
    {
        // POST /api/videos/{id}/addTag
        [HttpPost]
        [Route("api/videos/{id}/addTag")]
        public IHttpActionResult AddTag(AddTagBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var video = this.Data.Videos.Find(model.VideoId);
            if (video == null)
            {
                return this.BadRequest("Invalid video id: " + model.VideoId);
            }

            var tagName = this.Data.Tags.Find(model.Name);
            if (tagName != null)
            {
                return this.BadRequest("Tag " + model.Name + " already exist.");
            }

            var loggedUserId = this.User.Identity.GetUserId();
            if (video.UsernameId != loggedUserId)
            {
                return this.Unauthorized();
            }

            var tag = new Tag
            {
                TagName = model.Name,
                IsAdultContent = model.IsAdultContent,
                VideoId = model.VideoId
            };

            this.Data.Tags.Add(tag);
            this.Data.SaveChanges();

            return this.Ok();
        }

        // POST /api/Tags
        [HttpPost]
        [Route("api/tags")]
        public IHttpActionResult CreateTag(int id, CreateTagBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var loggedUserId = this.User.Identity.GetUserId();

            var tag = new Tag
            {
                VideoId = id,
                UsernameId = loggedUserId
            };

            this.Data.Tags.Add(tag);
            this.Data.SaveChanges();

            return this.Ok();
        }

        // DELETE /api/Tags/{id}
        [HttpDelete]
        [Route("api/tags/{id}")]
        public IHttpActionResult DeleteTag(int id)
        {
            var tag = this.Data.Tags.Find(id);
            if (tag == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var videoOwnerId = this.GetVideoOwnerId(tag.VideoId);
            if (videoOwnerId != loggedUserId)
            {
                return this.Unauthorized();
            }

            this.Data.Tags.Remove(tag);
            this.Data.SaveChanges();

            return this.Ok();
        }

        // PUT /api/Tags/{id}
        [HttpPut]
        [Route("api/tags/{id}")]
        public IHttpActionResult EditTag(int id, EditTagBindingModel model)
        {
            var tag = this.Data.Tags.Find(id);
            if (tag == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var videoOwnerId = this.GetVideoOwnerId(tag.VideoId);
            if (videoOwnerId != loggedUserId)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            tag.TagName = model.Name;
            tag.IsAdultContent = model.IsAdultContent;
            this.Data.SaveChanges();

            var tagData = this.Data.Tags
                .Where(t => t.Id == tag.Id)
                .Select(TagViewModel.Create)
                .FirstOrDefault();

            return this.Ok();
        }

        private string GetVideoOwnerId(int videoId)
        {
            return this.Data.Videos
                .Where(t => t.Id == videoId)
                .Select(t => t.UsernameId)
                .FirstOrDefault();
        }
    }
}
