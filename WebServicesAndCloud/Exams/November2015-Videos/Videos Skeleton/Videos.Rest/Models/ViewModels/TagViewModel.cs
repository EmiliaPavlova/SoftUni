using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Videos.Models;

namespace Videos.Rest.Models.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsAdultContent { get; set; }

        public static Expression<Func<Tag, TagViewModel>> Create
        {
            get
            {
                return t => new TagViewModel()
                {
                    Id = t.Id,
                    Name = t.TagName,
                    IsAdultContent = t.IsAdultContent
                };
            }
        }
    }
}