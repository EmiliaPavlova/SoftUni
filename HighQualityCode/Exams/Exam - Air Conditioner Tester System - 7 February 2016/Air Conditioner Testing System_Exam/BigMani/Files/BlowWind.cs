//namespace AirConditionerSystem.Files
//{
//    using System;

//    internal partial class BlowWind
//    {

//        public string manufacturer;

//        public int energyRating;

//        public int PowerUsage;

//        public int volumeCovered;

//        public int electricityUsed;

//        public string type;

//        public BlowWind(string manufacturer, string model, string ennergyEfficiencyRating, int powerUsage)
//        {
//            this.Manufacturer = manufacturer;
//            this.Model = model;
//            switch (ennergyEfficiencyRating)
//            {
//                case "A":
//                    this.energyRating = 10;
//                    break;
//                case "B":
//                    this.energyRating = 12;
//                    break;
//                case "C":
//                    this.energyRating = 15;
//                    break;
//                case "D":
//                    this.energyRating = 20;
//                    break;
//                case "E":
//                    this.energyRating = 90;
//                    break;
//            }
//            this.PowerUsage = powerUsage;
//            this.type = "stationary";
//        }

//        public BlowWind(string manufacturer, string model, int volumeCoverage, string electricityUsed)
//        {
//            this.Manufacturer = manufacturer;
//            this.Model = model;
//            this.VolumeCovered = volumeCoverage;
//            this.ElectricityUsed = Convert.ToInt32(electricityUsed);
//            this.type = "plane";
//        }

//        public string Manufacturer
//        {
//            get
//            {
//                return this.manufacturer;
//            }

//            set
//            {
//                if (string.IsNullOrWhiteSpace(value))
//                {
//                    throw new ArgumentException(string.Format(value, Validation.ManufacturerMinLength, "Manufacturer"));
//                }

//                this.manufacturer = value;
//            }
//        }

//        public int VolumeCovered
//        {
//            get
//            {
//                return this.volumeCovered;
//            }

//            set
//            {
//                if (value <= 0)
//                {
//                    throw new ArgumentException(string.Format(Validation.NONPOSITIVE, "Volume Covered"));
//                }

//                this.volumeCovered = value;
//            }
//        }

//        public int ElectricityUsed
//        {
//            get
//            {
//                return this.electricityUsed;
//            }

//            set
//            {
//                if (value < 0)
//                {
//                    throw new ArgumentException(string.Format(Validation.NONPOSITIVE, "Electricity Used"));
//                }

//                this.electricityUsed = value;
//            }
//        }

//        public int Test()
//        {
//            if (this.type == "stationary")
//            {
//                if (this.PowerUsage / 100 <= this.energyRating)
//                {
//                    return 1;
//                }
//            }
//            else if (this.type == "car")
//            {
//                double sqrtVolume = Math.Sqrt(this.volumeCovered);
//                if (sqrtVolume < 3)
//                {
//                    return 1;
//                }

//                return 2;
//            }
//            else if (this.type == "plane")
//            {
//                double sqrtVolume = Math.Sqrt(this.volumeCovered);
//                if (this.ElectricityUsed / sqrtVolume < Validation.PlaneMinElectricity)
//                {
//                    return 1;
//                }
//            }

//            return 0;
//        }

//        public override string ToString()
//        {
//            string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
//                           this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

//            if (this.type == "stationary")
//            {
//                string energy = "A";
//                switch (this.energyRating)
//                {
//                    case 12:
//                        energy = "B";
//                        break;
//                    case 15:
//                        energy = "C";
//                        break;
//                    case 20:
//                        energy = "D";
//                        break;
//                    case 90:
//                        energy = "E";
//                        break;
//                }

//                print += "Required energy efficiency rating: " + energy + "\r\n" + "Power Usage(KW / h): " +
//                         this.PowerUsage + "\r\n";
//            }
//            else if (this.type == "car")
//            {
//                print += "Volume Covered: " + this.VolumeCovered + "\r\n";
//            }
//            else
//            {
//                print += "Volume Covered: " + this.VolumeCovered + "\r\n" + "Electricity Used: " + this.ElectricityUsed + "\r\n";
//            }

//            print += "====================";

//            return print.ToString();
//        }
//    }
//}
