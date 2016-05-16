namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Web.Http;
    using Data;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models;

    [RoutePrefix("api/bugs")]
    public class BugsController : BaseApiController
    {

        // GET /api/bugs
        [HttpGet]
        public IHttpActionResult GetAllBugs()
        {
            var bugs = this.Data.Bugs
                .OrderByDescending(b => b.SubmittedOn)
                .Select(b => new BugViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status.ToString(),
                    Author = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.SubmittedOn
                });

            return this.Ok(bugs);
        }

        // GET api/bugs/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBugById(int id)
        {
            var data = this.Data.Bugs
                .Where(b => b.Id == id)
                .Select(b => new BugDetailsViewModel__()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Status = b.Status.ToString(),
                    Author = b.Author == null ? null : b.Author.UserName,
                    DateCreated = b.SubmittedOn,
                    Comments = b.Comments
                        .OrderByDescending(c => c.CreatedOn)
                        .ThenByDescending(c => c.Id)
                        .Select(c => new CommentViewModel()
                        {
                            Id = c.Id,
                            Text = c.Text,
                            Author = c.Author == null ? null : c.Author.UserName,
                            DateCreated = c.CreatedOn
                        })
                }).FirstOrDefault(); var bug = this.Data.Bugs.Find(id);

            if (data == null)
            {
                return this.NotFound();
            }

            return this.Ok(data);
        }

        // POST api/bugs
        [HttpPost]
        public IHttpActionResult AddNewBug(PostBugBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null (no data send)");
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(loggedUserId);

            var bug = new Bug
            {
                Title = model.Title,
                Description = model.Description,
                SubmittedOn = DateTime.Now,
                Author = user
            };

            this.Data.Bugs.Add(bug);
            this.Data.SaveChanges();

            if (user == null)
            {
                return this.CreatedAtRoute(
                    "DefaultApi",
                    new {id = bug.Id},
                    new {id = bug.Id, message = "Anonymous bug submitted."});
            }
            else
            {
                return this.CreatedAtRoute(
                "DefaultApi",
                new { id = bug.Id },
                new { id = bug.Id, author = user.UserName, message = "User bug submitted." });
            }
        }

        // PATCH api/bugs/{id}
        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult EditBug(int id, EditBugBindingModel model)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest("Model canno be null.");
            }

            if (model.Title != null)
            {
                bug.Title = model.Title;
            }

            if (model.Description != null)
            {
                bug.Description = model.Description;
            }

            if (model.Status != null)
            {
                BugStatus newStatus;
                bool isSuccessful = Enum.TryParse(model.Status, out newStatus);
                if (!isSuccessful)
                {
                    return this.BadRequest("Invalid bug status.");
                }

                bug.Status = newStatus;
            }

            this.Data.SaveChanges();

            return this.Ok(new
            {
                message = string.Format("Bug #{0} patched.", bug.Id)
            });
        }

        //DELETE api/bugs/{id}
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBug(int id)
        {
            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            this.Data.Bugs.Remove(bug);
            this.Data.SaveChanges();

            return this.Ok(new
            {
                message = string.Format("Bug #{0} deleted.", bug.Id)
            });
        }

        // GET api/bugs/filter
        [HttpGet]
        [Route("filter")]
        public IHttpActionResult FilterBugs(FilterBugsBindingModel model)
        {
            var bugs = this.Data.Bugs.AsQueryable();

            if (model != null)
            {
                if (model.Keywords != null)
                {
                    bugs = bugs.Where(b => b.Title.Contains(model.Keywords));
                }

                if (model.Statuses != null)
                {
                    // Open|Closed|Fixed
                    var statuses = model.Statuses.Split('|');
                    var bugStatuses = new List<BugStatus>();
                    for (int i = 0; i < statuses.Length; i++)
                    {
                        BugStatus parsedStatus;
                        bool isSuccessful = Enum.TryParse(statuses[i], out parsedStatus);
                        if (isSuccessful)
                        {
                            bugStatuses.Add(parsedStatus);
                            bugs = bugs.Where(b => b.Status == parsedStatus);
                        }
                    }

                    bugs = bugs.Where(b => bugStatuses.Contains(b.Status));
                }

                if (model.Author != null)
                {
                    bugs = bugs.Where(b => b.Author.UserName == model.Author);
                }                
            }

            var data = bugs.Select(b => new BugViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Status = b.Status.ToString(),
                Author = b.Author == null ? null : b.Author.UserName,
            });

            return this.Ok(data);
        }
    }
}
