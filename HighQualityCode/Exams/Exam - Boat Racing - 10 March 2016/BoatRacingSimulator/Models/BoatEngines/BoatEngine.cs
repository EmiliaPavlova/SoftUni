namespace BoatRacingSimulator.Models.BoatEngines
{
    using Interfaces;
    using Utility;

    public abstract class BoatEngine : IBoatEngine
    {
        private string model;
        protected int horsePower;
        protected int displacement;

        protected BoatEngine(string model, int horsePower, int displacement)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.Displacement = displacement;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Horsepower");
                this.horsePower = value;
            }
        }

        public int Displacement
        {
            get
            {
                return this.displacement;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Displacement");
                this.displacement = value;
            }
        }

        public abstract int Output();
    }
}