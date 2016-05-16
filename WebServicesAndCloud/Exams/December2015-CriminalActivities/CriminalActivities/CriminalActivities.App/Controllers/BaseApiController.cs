using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CriminalActivities.App.Controllers
{
    using Data;
    using Data.Unit_of_Work;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new CriminalData(new CriminalContext()))
        {
        }

        public BaseApiController(ICriminalContext data)
        {
            this.Data = data;
        }

        protected ICriminalContext Data { get; set; }
    }
}
