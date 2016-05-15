namespace BigMani.Exceptions
{
    using System;

    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException() : base()
        {
        }
    }

    internal sealed partial class BlowWind
    {
        public BlowWind(string manufacturer, string model, int volumeCoverage)
        {
            Manufacturer = manufacturer;
            Model = model;
            VolumeCovered = volumeCoverage;
            type = "car";
        }

        public string model;

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < GoodStuff.GoodStuff.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(GoodStuff.GoodStuff.INCORRECT_PROPERTY_LENGTH, "Model", 2));
                }

                this.model = value;
            }
        }
    }
}
