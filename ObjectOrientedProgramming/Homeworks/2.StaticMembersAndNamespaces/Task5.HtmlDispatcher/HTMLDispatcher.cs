using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.HtmlDispatcher
{
    public static class HTMLDispatcher
    {
        public static ElementBuilder CreateImage(string imageSource, string alt, string title)
        {
            ElementBuilder image = new ElementBuilder("img");
            image.AddAttribute("src", imageSource);
            image.AddAttribute("alt", alt);
            image.AddAttribute("title", title);
            return image;
        }

        public static ElementBuilder CreateUrl(string url, string title, string text)
        {
            ElementBuilder link = new ElementBuilder("a");
            link.AddAttribute("href", url);
            link.AddAttribute("title", title);
            link.AddContent(text);
            return link;
        }

        public static ElementBuilder CreateInput(string type = "button", string name = "name", string value = "")
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAttribute("type", type);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);
            return input;
        }
    }
}
