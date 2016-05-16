using System;
using System.Collections.Generic;

namespace Videos.Models
{
    public class Location
    {
        private ICollection<Video> videos;

        public Location()
        {
            this.videos = new HashSet<Video>();
        }

        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public virtual ICollection<Video> Videos
        {
            get { return this.videos; }
            set { this.videos = value; }
        }
    }
}