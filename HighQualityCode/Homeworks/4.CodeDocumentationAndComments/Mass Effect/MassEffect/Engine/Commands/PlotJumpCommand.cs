namespace MassEffect.Engine.Commands
{
    using System;
    using Exceptions;
    using GameObjects.Locations;
    using Interfaces;

    /// <summary>
    /// The plot jump command.
    /// </summary>
    public class PlotJumpCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlotJumpCommand"/> class.
        /// </summary>
        /// <param name="gameEngine">
        /// The game engine.
        /// </param>
        public PlotJumpCommand(IGameEngine gameEngine)
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
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];

            IStarship ship = this.GetStarshipByName(shipName);

            this.ValidateAlive(ship);

            var previousLocation = ship.Location;
            StarSystem destination = this.GameEngine.Galaxy.GetStarSystemByName(destinationName);

            if (previousLocation == destination)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }

            this.GameEngine.Galaxy.TravelTo(ship, destination);

            Console.WriteLine(Messages.ShipTraveled, shipName, previousLocation.Name, destinationName);
        }
    }
}