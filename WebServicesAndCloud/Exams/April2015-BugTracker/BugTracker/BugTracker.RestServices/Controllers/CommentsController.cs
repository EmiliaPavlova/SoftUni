namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models;

    public class CommentsController : BaseApiController
    {
        // GET /api/comments
        [HttpGet]
        public IHttpActionResult GetAllComments()
        {
            var data = this.Data.Comments
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new
                {
                    c.Id,
                    c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.CreatedOn,
                    BugId = c.Bug.Id,
                    BugTitle = c.Bug.Title
                });

            return this.Ok(data);
        }

        // GET /api/bugs/{id}/comments
        [HttpGet]
        [Route("api/bugs/{id}/comments")]
        public IHttpActionResult GetBugComments(int id)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = bug.Comments
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.CreatedOn
                });

            return this.Ok(comments);
        }
        
        // POST /api/bugs/{id}/comments
        [HttpPost]
        [Route("api/bugs/{id}/comments")]
        public IHttpActionResult AddNewComment(int id, PostCommentBindingModel model)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);

            var comment = new Comment()
            {
                Text = model.Text,
                Author = user,
                CreatedOn = DateTime.Now
            };

            bug.Comments.Add(comment);
            this.Data.SaveChanges();

            if (user == null)
            {
                return this.Ok(new
                {
                    Id = comment.Id,
                    Message = string.Format("Added anonymous comment for bug #{0}", bug.Id)
                });
            }
            else
            {
                return this.Ok(new
                {
                    Id = comment.Id,
                    Author = user.UserName,
                    Message = string.Format("User comment added for bug #{0}", bug.Id)
                });
            }
        }
    }
}
