namespace BugTracker.RestServices.Models
{
    public class FilterBugsBindingModel
    {
        public string Keywords { get; set; }

        public string Statuses { get; set; }

        public string Author { get; set; }
    }
}