namespace BoatRacingSimulator.Models.BoatEngines
{
    using Enumerations;

    public class SterndriveEngine : BoatEngine
    {
        private EngineType engineType;

        public SterndriveEngine(string model, int horsePower, int displacement, EngineType engineType) 
            : base(model, horsePower, displacement)
        {
            this.engineType = EngineType.Sterndrive;
        }

        public override int Output()
        {
            var output = (this.horsePower * 7) + this.displacement;
            return output;
        }
    }
}