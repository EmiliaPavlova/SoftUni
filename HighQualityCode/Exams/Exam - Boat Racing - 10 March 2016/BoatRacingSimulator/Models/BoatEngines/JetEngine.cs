namespace BoatRacingSimulator.Models.BoatEngines
{
    using Enumerations;

    public class JetEngine : BoatEngine
    {
        private EngineType engineType;

        public JetEngine(string model, int horsePower, int displacement, EngineType engineType) 
            : base(model, horsePower, displacement)
        {
            this.engineType = EngineType.Jet;
        }

        public override int Output()
        {
            var output = (this.horsePower * 5) + this.displacement;
            return output;
        }
    }
}