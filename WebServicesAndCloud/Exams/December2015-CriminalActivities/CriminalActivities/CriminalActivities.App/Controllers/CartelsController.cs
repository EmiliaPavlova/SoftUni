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
    using Models.Binding_Models;

    public class CartelsController : BaseApiController
    {

        // GET: api/cartels
        [HttpGet]
        public IHttpActionResult GetAllCartels()
        {
            var cartels = this.Data.Cartels.All()
                .OrderByDescending(c => c.Members.Count)
                .ThenBy(c => c.Name)
                .Select(CartelViewModel.Create)
                .FirstOrDefault();

            return this.Ok(cartels);
        }

        // POST: api/cartels
        [HttpPost]
        [Authorize]
        public IHttpActionResult AddCartel(CartelBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Model cannot be null.");
            }

            var loggedUserId = this.User.Identity.GetUserId();

            var criminals = new List<Criminal>();
            foreach (var criminalId in model.CriminalIds)
            {
                var criminal = this.Data.Criminals.All()
                    .FirstOrDefault(c => c.Id == criminalId);
                if (criminal == null)
                {
                    return this.Content(HttpStatusCode.NotFound, new
                    {
                        Message = string.Format("Criminal with id #{0} does not exist.", criminalId)
                        });
                }

                //if (criminal.Equals(this.Data.Criminals))
                //{
                //    return this.Content(HttpStatusCode.Conflict, new
                //    {
                //        Message = string.Format("Criminal with id #{0} already has a cartel", criminal)
                //    });
                //}
                criminals.Add(criminal);
            }

            var newCartel = new Cartel()
            {
                Name = model.Name,
                Members = criminals
            };

            //if (!newCartel.Name.Any())
            //{
            //    return this.Content(HttpStatusCode.Conflict, new
            //    {
            //        Message =
            //        "A cartel with the same name already exists"
            //    });
            //}

            this.Data.Cartels.Add(newCartel);
            this.Data.SaveChanges();

            var data = this.Data.Cartels.All()
                .Where(c => c.Id == newCartel.Id)
                .Select(CartelViewModel.Create)
                .FirstOrDefault();

            return this.Ok(data);

        }
    }
}
