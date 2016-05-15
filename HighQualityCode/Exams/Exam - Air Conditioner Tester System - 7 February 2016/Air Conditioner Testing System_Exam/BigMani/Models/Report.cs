namespace AirConditionerSystem.Models
{
    public class Report
    {
        private string manufacturer;
        private string model;
        private Mark mark;

        public Report(string manufacturer, string model, Mark mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public Mark Mark { get; set; }
    }
}