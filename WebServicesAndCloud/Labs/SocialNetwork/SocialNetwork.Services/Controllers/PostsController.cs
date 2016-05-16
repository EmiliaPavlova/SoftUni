namespace SocialNetwork.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Microsoft.AspNet.Identity;
    using Models;
    using SocialNetwork.Models;

    public class PostsController : ApiController
    {
        // GET api/posts
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetPosts()
        {
            var context = new SocialNetworkContext();
            var data = context.Posts
                .OrderBy(p => p.PostedOn)
                .Select(p => p.Content);

            return this.Ok(data);
        }

        // POST api/posts/{id}
        public IHttpActionResult AddPost(AddPostBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null");
            }

            var context = new SocialNetworkContext();
            var wallOwner = context.Users
                .FirstOrDefault(u => u.UserName == model.WallOwnerUsername);

            if (wallOwner == null)
            {
                return this.BadRequest(string.Format("User {0} does not exist", model.WallOwnerUsername));
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var post = new Post()
            {
                AuthorId = loggedUserId,
                WallOwner = wallOwner,
                Content = model.Content,
                PostedOn = DateTime.Now
            };

            context.Posts.Add(post);
            context.SaveChanges();

            var data = context.Posts
                .Where(p => p.Id == post.Id)
                .Select(PostViewModel.Create)
                .FirstOrDefault();

            return this.Ok();
        }
    }
}
