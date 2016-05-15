namespace AirConditionerSystem.Models
{
    using Files;

    public class StationaryAirConditioner : AirConditioner
    {
        private int powerUsage;

        public StationaryAirConditioner(string manufacturer, string model, RequiredEnergyEfficiencyRating requiredEnergyEfficiencyRating, int powerUsage) 
            : base(manufacturer, model, Type.stationary)
        {
            this.PowerUsage = powerUsage;
            this.RequiredEnergyEfficiencyRating = requiredEnergyEfficiencyRating;
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                ValidationRules.CheckValidLevel(value, Validation.PowerUsageMinLevel, "Power Usage");
                this.powerUsage = value;
            }
        }

        public RequiredEnergyEfficiencyRating RequiredEnergyEfficiencyRating { get; private set; }

        public override Mark Test()
        {
            int energyEfficiencyRating = 0;
            switch (this.RequiredEnergyEfficiencyRating)
            {
                case RequiredEnergyEfficiencyRating.A:
                    energyEfficiencyRating = 1000;
                    break;
                case RequiredEnergyEfficiencyRating.B:
                    energyEfficiencyRating = 1250;
                    break;
                case RequiredEnergyEfficiencyRating.C:
                    energyEfficiencyRating = 1500;
                    break;
                case RequiredEnergyEfficiencyRating.D:
                    energyEfficiencyRating = 2000;
                    break;
                case RequiredEnergyEfficiencyRating.E:
                    energyEfficiencyRating = 2000;
                    break;
            }

            if (this.PowerUsage > energyEfficiencyRating)
            {
                return Mark.Failed;
            }

            return Mark.Passed;
        }
    }
}