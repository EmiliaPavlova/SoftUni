namespace MassEffect.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Interfaces;
    using Locations;

    /// <summary>
    ///     The galaxy.
    /// </summary>
    public class Galaxy
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Galaxy" /> class.
        /// </summary>
        public Galaxy()
        {
            this.StarSystems = new HashSet<StarSystem>();
        }

        /// <summary>
        ///     Gets or sets the star systems.
        /// </summary>
        public HashSet<StarSystem> StarSystems { get; set; }

        /// <summary>
        /// The get star system by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="StarSystem"/>.
        /// </returns>
        public StarSystem GetStarSystemByName(string name)
        {
            return this.StarSystems
                .First(s => s.Name == name);
        }

        /// <summary>
        /// The travel to.
        /// </summary>
        /// <param name="ship">
        /// The ship.
        /// </param>
        /// <param name="destination">
        /// The destination.
        /// </param>
        /// <exception cref="LocationOutOfRangeException">
        /// </exception>
        /// <exception cref="InsufficientFuelException">
        /// </exception>
        public void TravelTo(IStarship ship, StarSystem destination)
        {
            var startLocation = ship.Location;
            if (!startLocation.NeighbourStarSystems.ContainsKey(destination))
            {
                throw new LocationOutOfRangeException(string.Format(
                    "Cannot travel directly from {0} to {1}", 
                    startLocation.Name, destination.Name));
            }

            double requiredFuel = startLocation.NeighbourStarSystems[destination];
            if (ship.Fuel < requiredFuel)
            {
                throw new InsufficientFuelException(string.Format(
                    "Not enough fuel to travel to {0} - {1}/{2}", 
                    destination.Name, ship.Fuel, requiredFuel));
            }

            ship.Fuel -= requiredFuel;
            ship.Location = destination;
        }
    }
}