using System;
using System.Text;

namespace BigMani.Exceptions
{
    internal partial class BlowWind
    {

        public string manufacturer;

        public int energyRating;

        public int PowerUsage;

        public int volumeCovered;

        public int electricityUsed;

        public string type;

        public BlowWind(string manufacturer, string model, string ennergyEfficiencyRating, int powerUsage)
        {
            Manufacturer = manufacturer;
            Model = model;
            switch (ennergyEfficiencyRating)
            {
                case "A":
                    energyRating = 10;
                    break;
                case "B":
                    energyRating = 12;
                    break;
                case "C":
                    energyRating = 15;
                    break;
                case "D":
                    energyRating = 20;
                    break;
                case "E":
                    energyRating = 90;
                    break;
            }
            PowerUsage = powerUsage;
            type = "stationary";
        }

        public BlowWind(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            Manufacturer = manufacturer;
            Model = model;
            VolumeCovered = volumeCoverage;
            ElectricityUsed = Convert.ToInt32(electricityUsed);
            type = "plane";
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(GoodStuff.GoodStuff.INCORRECT_PROPERTY_LENGTH, "Manufacturer", 4));
                }

                this.manufacturer = value;
            }
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(GoodStuff.GoodStuff.NONPOSITIVE, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(GoodStuff.GoodStuff.NONPOSITIVE, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public int Test()
        {
            if (type == "stationary")
            {
                if (this.PowerUsage / 100 <= energyRating)
                {
                    return 1;
                }
            }
            else if (type == "car")
            {
                double sqrtVolume = Math.Sqrt(volumeCovered);
                if (sqrtVolume < 3)
                {
                    return 1;
                }

                return 2;
            }
            else if (type == "plane")
            {
                double sqrtVolume = Math.Sqrt(volumeCovered);
                if (this.ElectricityUsed / sqrtVolume < GoodStuff.GoodStuff.MinPlaneElectricity)
                {
                    return 1;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                           this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

            if (type == "stationary")
            {
                string energy = "A";
                switch (energyRating)
                {
                    case 12:
                        energy = "B";
                        break;
                    case 15:
                        energy = "C";
                        break;
                    case 20:
                        energy = "D";
                        break;
                    case 90:
                        energy = "E";
                        break;
                }

                print += "Required energy efficiency rating: " + energy + "\r\n" + "Power Usage(KW / h): " +
                         this.PowerUsage + "\r\n";
            }
            else if (type == "car")
            {
                print += "Volume Covered: " + VolumeCovered + "\r\n";
            }
            else
            {
                print += "Volume Covered: " + VolumeCovered + "\r\n" + "Electricity Used: " + ElectricityUsed + "\r\n";
            }

            print += "====================";

            return print.ToString();
        }
    }
}
