using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videos.Data;

namespace Videos.Rest.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController() : this(new VideosDbContext())
        {
        }

        public BaseApiController(VideosDbContext data)
        {
            this.Data = data;
        }

        public VideosDbContext Data { get; set; }
    }
}
