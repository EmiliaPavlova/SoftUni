namespace BoatRacingSimulator.Interfaces
{
    using Database;
    using Enumerations;

    public interface IBoatSimulatorController
    {
        BoatSimulatorDatabase Database { get; }

        /// <summary>
        /// the interface holding the public properties for creating a boat engine
        /// </summary>
        /// <param name="model">the model of the boat engine</param>
        /// <param name="horsePower">the horse power of the boat engine</param>
        /// <param name="displacement">the displacement</param>
        /// <param name="engineType">which of the two types is</param>
        /// <returns>the created boat engine</returns>
        string CreateBoatEngine(string model, int horsePower, int displacement, EngineType engineType);

        string CreateRowBoat(string model, int weight, int oars);

        string CreateSailBoat(string model, int weight, int sailEfficiency);

        string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel);

        string CreateYacht(string model, int weight, string engineModel, int cargoWeight);

        IRace CurrentRace { get; }

        string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats);

        /// <summary>
        /// the method that enroll boat in the race
        /// </summary>
        /// <param name="model">the model of the boat to be enrolled</param>
        /// <returns>the model of the boat if it fits the engine requirements</returns>
        string SignUpBoat(string model);

        string StartRace();

        string GetStatistic();
    }
}
