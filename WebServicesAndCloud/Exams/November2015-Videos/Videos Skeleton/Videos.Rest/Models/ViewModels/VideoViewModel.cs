using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Videos.Models;

namespace Videos.Rest.Models.ViewModels
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public LocationViewModel Location { get; set; }

        public ApplicationUser Owner { get; set; }

        public static Expression<Func<Video, VideoViewModel>> Create
        {
            get
            {
                return v => new VideoViewModel()
                {
                    Id = v.Id,
                    Title = v.Title,
                    Location = new LocationViewModel
                    {
                        Country = v.Location.Country,
                        City = v.Location.City
                    },
                    Owner = v.Username
                };
            }
        }
    }

    public class LocationViewModel
        {
            public string Country { get; set; }

            public string City { get; set; }
        }
}