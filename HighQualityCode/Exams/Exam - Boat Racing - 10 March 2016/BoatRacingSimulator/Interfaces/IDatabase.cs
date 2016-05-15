namespace BoatRacingSimulator.Interfaces
{
    using Models.BoatEngines;
    using Models.Boats;

    public interface IDatabase
    {
        IRepository<Boat> Boats { get; set; }

        IRepository<BoatEngine> Engines { get; set; }
    }
}