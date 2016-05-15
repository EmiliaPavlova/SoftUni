namespace AirConditionerSystem.Files
{
    using Interfaces;
    using Models;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, Mark mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public Mark Mark { get; set; }

        public override string ToString()
        {
            string result = "";
            if (this.Mark == Mark.Failed)
            {
                result = "Failed";
            }
            else if (this.Mark == Mark.Passed)
            {
                result = "Passed";
            }

            result += "Report" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " + this.Manufacturer + "\r\n" +
                      "Model: " + this.Model + "\r\n" + "Mark: " + result + "\r\n" + "====================";

            return result;
        }
    }
}
