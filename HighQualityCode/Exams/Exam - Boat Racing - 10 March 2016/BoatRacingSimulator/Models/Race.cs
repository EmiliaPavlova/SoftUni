using BoatRacingSimulator.Exceptions;

namespace BoatRacingSimulator.Models
{
    using System.Collections.Generic;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;
    using Boats;

    public class Race : IRace
    {
        private int distance;

        public Race(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            this.Distance = distance;
            this.WindSpeed = windSpeed;
            this.OceanCurrentSpeed = oceanCurrentSpeed;
            this.AllowsMotorboats = allowsMotorboats;
            this.RegisteredBoats = new Dictionary<string, MotorBoat>();
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Distance");

                this.distance = value;
            }
        }

        public int WindSpeed { get; private set; }

        public int OceanCurrentSpeed { get; private set; }

        public bool AllowsMotorboats { get; private set; }

        protected Dictionary<string, MotorBoat> RegisteredBoats { get; set; }

        public void AddParticipant(MotorBoat boat)
        {
            if (this.RegisteredBoats.ContainsKey(boat.Model))
            {
                throw new DuplicateModelException(Constants.DuplicateModelMessage);
            }

            this.RegisteredBoats.Add(boat.Model, boat);
        }

        public IList<MotorBoat> GetParticipants()
        {
            return new List<MotorBoat>(this.RegisteredBoats.Values);
        }
    }
}
