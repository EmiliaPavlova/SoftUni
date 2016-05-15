using BoatRacingSimulator.Models;

namespace BoatRacingSimulator.Database
{
    using System;
    using BoatRacingSimulator.Interfaces;
    using Models.BoatEngines;
    using Models.Boats;

    public class BoatSimulatorDatabase : IDatabase
    {
        public BoatSimulatorDatabase()
        {
            this.Boats = new Repository<Boat>();
            this.Engines = new Repository<BoatEngine>();
        }

        public IRepository<Boat> Boats { get; set; }

        public IRepository<BoatEngine> Engines { get; set; }

        
    }
}
