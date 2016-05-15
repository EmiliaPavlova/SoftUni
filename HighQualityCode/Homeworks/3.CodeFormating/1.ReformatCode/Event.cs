namespace _1.ReformatCode
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        public DateTime date;
        public String title;
        public String location;

        public Event(DateTime date, String title, String location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int comparedByDate = this.date.CompareTo(other.date);
            int comparedByTitle = string.Compare(this.Title, other.title, StringComparison.Ordinal);
            int comparedByLocation = string.Compare(this.Location, other.location, StringComparison.Ordinal);

            if (comparedByDate == 0)
            {
                if (comparedByTitle == 0)
                {
                    return comparedByLocation;
                }
                else
                {
                    return comparedByTitle;
                }
            }
            else
            {
                return comparedByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + Title);

            if (location != null && Location != "")
            {
                toString.Append(" | " + Location);
            }

            return toString.ToString();
        }
    }
}
