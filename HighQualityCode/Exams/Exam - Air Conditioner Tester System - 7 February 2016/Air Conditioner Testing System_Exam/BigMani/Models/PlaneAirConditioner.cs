namespace AirConditionerSystem.Models
{
    using System;
    using Files;

    public class PlaneAirConditioner : AirConditioner
    {
        private int volumeCovered;
        private int electricityUsage;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCovered, int electricityUsage) 
            : base(manufacturer, model, Type.plane)
        {
            this.VolumeCovered = volumeCovered;
            this.ElectricityUsage = electricityUsage;
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

        public int ElectricityUsage
        {
            get
            {
                return this.electricityUsage;
            }

            set
            {
                ValidationRules.CheckValidLevel(value, Validation.ElectricityUsedMinLevel, "Electricity Used");
                this.electricityUsage = value;
            }
        }

        public override Mark Test()
        {
            double plainElectricity = this.ElectricityUsage / Math.Sqrt(this.VolumeCovered);
            if (plainElectricity > Validation.PlaneMinElectricity)
            {
                return Mark.Failed;
            }

            return Mark.Passed;
        }
    }
}