namespace AirConditionerSystem.Models
{
    using System;
    using Files;

    public class CarAirConditioner : AirConditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCovered) 
            : base(manufacturer, model, Type.car)
        {
            this.VolumeCovered = volumeCovered;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                ValidationRules.CheckValidLevel(value, Validation.VolumeCoveredMinLevel, "Volume Covered");
                this.volumeCovered = value;
            }
        }

        public override Mark Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if (sqrtVolume < Validation.CarMinVolume)
            {
                return Mark.Failed;
            }

            return Mark.Passed;
        }
    }
}