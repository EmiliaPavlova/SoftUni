using System;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];

            var ship = this.GetStarshipByName(shipName);
            this.ValidateAlive(ship);

            var previousLocation = ship.Location;
            var destination = this.GameEngine.Galaxy.GetStarSystemByName(destinationName);

            if (previousLocation.Name == destinationName)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }

            this.GameEngine.Galaxy.TravelTo(ship, destination);
            Console.WriteLine(Messages.ShipTraveled, shipName, previousLocation.Name, destinationName);
        }
    }
}
