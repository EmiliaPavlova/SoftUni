namespace BoatRacingSimulator.Models.Boats
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using BoatEngines;
    using Interfaces;

    public class PowerBoat : MotorBoat
    {
        public PowerBoat(string model, int weight, IBoatEngine boatEngine, IBoatEngine secondEngine)
            : base(model, weight, boatEngine)
        {
            this.SecondEngins = secondEngine;
        }

        public IBoatEngine SecondEngins { get; set; }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = (this.BoatEngine.Output() + this.SecondEngins.Output()) - this.Weight + (race.OceanCurrentSpeed / 5d);
            return speed;
        }
    }
}