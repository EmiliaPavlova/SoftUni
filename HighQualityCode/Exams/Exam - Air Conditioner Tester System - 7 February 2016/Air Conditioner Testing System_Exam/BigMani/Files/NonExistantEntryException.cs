namespace AirConditionerSystem.Files
{
    using System;

    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException() : base()
        {
        }
    }

    //internal sealed partial class BlowWind
    //{
    //    public BlowWind(string manufacturer, string model, int volumeCoverage)
    //    {
    //        this.Manufacturer = manufacturer;
    //        this.Model = model;
    //        this.VolumeCovered = volumeCoverage;
    //        this.type = "car";
    //    }

    //    public string model;

    //    public string Model
    //    {
    //        get
    //        {
    //            return this.model;
    //        }

    //        set
    //        {
    //            if (string.IsNullOrWhiteSpace(value) || value.Length < Validation.ModelMinLength)
    //            {
    //                throw new ArgumentException(string.Format(value, Validation.ModelMinLength, "Model"));
    //            }

    //            this.model = value;
    //        }
    //    }
    //}
}
