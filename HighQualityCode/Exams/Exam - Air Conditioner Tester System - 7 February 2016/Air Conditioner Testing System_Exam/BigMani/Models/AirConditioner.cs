namespace AirConditionerSystem.Models
{
    using Files;
    using Interfaces;

    public abstract class AirConditioner : IAirConditioner
    {
        private string manufacturer;
        private string model;
        protected Type type;

        protected AirConditioner(string manufacturer, string model, Type type)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Type = type;
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                ValidationRules.CheckValidLenght(value, Validation.ManufacturerMinLength, "Manufacturer's name");
                this.manufacturer = value;
            }
        }

        public string Model
        {
            get { return this.model; }

            private set
            {
                ValidationRules.CheckValidLenght(value, Validation.ModelMinLength, "Model's name");
                this.model = value;
            }
        }

        public Type Type { get; }

        public abstract Mark Test();

        //public override string ToString()
        //{
        //    string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
        //                   this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

        //    if (type == "stationary")
        //    {
        //        string energy = "A";
        //        switch (energyRating)
        //        {
        //            case 12:
        //                energy = "B";
        //                break;
        //            case 15:
        //                energy = "C";
        //                break;
        //            case 20:
        //                energy = "D";
        //                break;
        //            case 90:
        //                energy = "E";
        //                break;
        //        }

        //        print += "Required energy efficiency rating: " + energy + "\r\n" + "Power Usage(KW / h): " +
        //                 this.PowerUsage + "\r\n";
        //    }
        //    else if (type == "car")
        //    {
        //        print += "Volume Covered: " + VolumeCovered + "\r\n";
        //    }
        //    else
        //    {
        //        print += "Volume Covered: " + VolumeCovered + "\r\n" + "Electricity Used: " + ElectricityUsed + "\r\n";
        //    }

        //    print += "====================";

        //    return print.ToString();
        //}
    }
}