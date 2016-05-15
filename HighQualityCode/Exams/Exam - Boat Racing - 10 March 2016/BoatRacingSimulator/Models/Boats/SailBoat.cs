namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using Interfaces;
    using Utility;

    public class SailBoat : Boat
    {
        private int sailEfficiency;

        public SailBoat(string model, int weight, int sailEfficiency) 
            : base(model, weight)
        {
            this.SailEfficiency = sailEfficiency;
        }

        public int SailEfficiency
        {
            get
            {
                return this.sailEfficiency;
            }

            private set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException(Constants.IncorrectSailEfficiencyMessage);
                }

                this.sailEfficiency = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = (race.WindSpeed * (this.SailEfficiency / 100d)) - this.Weight + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}