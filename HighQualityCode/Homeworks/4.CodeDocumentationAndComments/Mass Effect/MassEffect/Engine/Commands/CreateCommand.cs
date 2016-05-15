namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Exceptions;
    using GameObjects.Enhancements;
    using GameObjects.Ships;
    using Interfaces;

    /// <summary>
    /// The create command.
    /// </summary>
    public class CreateCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCommand"/> class.
        /// </summary>
        /// <param name="gameEngine">
        /// The game engine.
        /// </param>
        public CreateCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="commandArgs">
        /// The command args.
        /// </param>
        /// <exception cref="ShipException">
        /// </exception>
        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType shipType = (StarshipType) Enum.Parse(typeof (StarshipType), type);

            var ship = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            this.GameEngine.Starships.Add(ship);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType) Enum.Parse(typeof (EnhancementType), commandArgs[i]);
                Enhancement enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);

                ship.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}