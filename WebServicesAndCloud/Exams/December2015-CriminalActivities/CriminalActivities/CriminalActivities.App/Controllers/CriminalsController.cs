using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CriminalActivities.App.Controllers
{
    using CriminalActivities.Models;
    using Microsoft.AspNet.Identity;
    using Models;

    public class CriminalsController : BaseApiController
    {

        // Get: api/criminals?Name={Name}&Alias={Alias}
        [HttpGet]
        [Route("api/criminals")]
        public IHttpActionResult GetCriminalsByNameAndAlias([FromUri]GetCriminalsBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // TODO: 404 Not Found
            //var criminalAlias = this.Data.Criminals.Find(model.Alias);
            //if (criminalAlias == null)
            //{
            //    return this.NotFound();
            //}

            var criminal = this.Data.Criminals.All()
                .Where(c => c.FullName == model.Name)
                .Select(CriminalViewModel.Create)
                .FirstOrDefault();

            return this.Ok(criminal);
        }

        // POST: api/criminals
        [HttpPost]
        [Authorize]
        [Route("api/criminals")]
        public IHttpActionResult RegisterCriminal(AddCriminalBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No data was sent.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            //var criminalName = this.Data.Criminals.Find(model.Name);
            //if (criminalName.FullName.Contains())
            //{
            //    return this.Content(HttpStatusCode.Conflict, "A criminal with the same name already exists.");
            //}

            var loggedUserId = this.User.Identity.GetUserId();

            var newCriminal = new Criminal
            {
                FullName = model.Name,
                Alias = model.Alias,
                CreatorId = loggedUserId,
            };

            this.Data.Criminals.Add(newCriminal);
            this.Data.SaveChanges();

            var criminalData = this.Data.Criminals.All()
                .Where(c => c.Id == newCriminal.Id)
                .Select(RegisteredCriminalViewModel.Create)
                .FirstOrDefault();

            //return this.Ok(criminalData);

            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "criminals", id = newCriminal.Id },
                criminalData);
        }

        // POST: api/criminals/{id}/addLocation
        //[HttpPost]
        //[Route("api/criminals/{id}/addLocation")]
        //public IHttpActionResult Location(int id, AddLocationBindingModel model)
        //{
        //    var criminal = this.Data.Criminals.Find(id);
        //    if (criminal == null)
        //    {
        //        return this.NotFound();
        //    }

        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    var loggedUserId = this.User.Identity.GetUserId();
        //    var location = new Location
        //    {
        //        City = model.City,
        //        LastSeen = model.LastSeen,
        //    };

        //    this.Data.Locations.Add(location);
        //    this.Data.SaveChanges();

        //    return this.Ok(location);

        //}

        // POST: api/criminals/{id}/addActivity
        //[HttpPost]
        //[Authorize]
        //public IHttpActionResult AddActivityToCriminal(int id, AddActivityBindingModel model)
        //{
        //    var criminal = this.Data.Criminals.Find(id);
        //    if (criminal == null)
        //    {
        //        return this.NotFound();
        //    }

        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    var loggedUserId = this.User.Identity.GetUserId();
        //    var activity = new Activity
        //    {
        //        Description = model.Description,
        //        ActiveFrom = model.ActiveFrom,
        //        ActiveTo = model.ActiveTo,
        //        ActivityType = model.Type
        //    };

        //    this.Data.Activities.Add(activity);
        //    this.Data.SaveChanges();

        //    return this.Ok();
        //}
    }
}
