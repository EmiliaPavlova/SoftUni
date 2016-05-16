using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CriminalActivities.App.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models;
    using Models.Binding_Models;

    public class ActivityController : BaseApiController
    {

        [HttpPut]
        [Authorize]
        [Route("api/activities/{id}")]
        public IHttpActionResult EditActivity(int id, EditActivityBindingModel model)
        {
            var activity = this.Data.Activities.Find(id);
            if (activity == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();
            
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            activity.Description = model.Description;
            activity.ActiveFrom = model.ActiveFrom;
            activity.ActiveTo = model.ActiveTo;
            activity.ActivityType = model.Type;
            this.Data.SaveChanges();

            var data = this.Data.Activities.All()
                .Where(a => a.Id == activity.Id)
                .Select(ActivityViewModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        //DELETE: api/activities/{id}
        [HttpDelete]
        [Authorize]
        [Route("api/activities/{id}")]
        public IHttpActionResult DeleteActivity(int id)
        {
            var activity = this.Data.Activities.Find(id);
            if (activity == null)
            {
                return this.NotFound();
            }

            var loggerUserId = this.User.Identity.GetUserId();

            this.Data.Activities.Delete(activity);
            this.Data.SaveChanges();

            return this.Ok(new { Message = string.Format("Tag #{0} deleted.", activity.Id) });
        }

        [HttpGet]
        public IHttpActionResult FilterActivities([FromUri] GetActivitiesBindingModel model)
        {
            var activities = this.Data.Activities.All();
            var data = activities
                .Where(a => a.ActivityType.Equals(model.ActivityType) &&
                            a.Criminal.FullName == model.CriminalName)
                .Select(ActivityViewModel.Create);

            return this.Ok(data);
        }
    }
}
