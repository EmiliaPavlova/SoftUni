using System;

namespace BigMani.Files
{
    using System.Text;

    public class Reprot
    {
        public Reprot(string manufacturer, string model, int mark)
        {
            Manufacturer = manufacturer;
            Model = model;
            Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Mark { get; set; }

        public override string ToString()
        {
            string result = "";
            if (this.Mark == 0)
            {
                result = "Failed";
            }
            else if (this.Mark == 1)
            {
                result = "Passed";
            }

            result += "Report" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " + Manufacturer + "\r\n" +
                      "Model: " + Model + "\r\n" + "Mark: " + result + "\r\n" + "====================";

            return result;
        }
    }
}
