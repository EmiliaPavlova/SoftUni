namespace BugTracker.RestServices.Models
{
    using System;
    using System.Collections.Generic;

    public class BugDetailsViewModel__
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}