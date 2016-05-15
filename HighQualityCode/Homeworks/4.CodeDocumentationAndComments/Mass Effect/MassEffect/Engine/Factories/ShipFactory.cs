namespace MassEffect.Engine.Factories
{
    using System;
    using GameObjects.Locations;
    using GameObjects.Ships;
    using Interfaces;

    /// <summary>
    /// The ship factory.
    /// </summary>
    public class ShipFactory
    {
        /// <summary>
        /// The create ship.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The <see cref="IStarship"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// </exception>
        public IStarship CreateShip(StarshipType type, string name, StarSystem location)
        {
            switch (type)
            {
                case StarshipType.Frigate:
                    return new Frigate(name, location);
                case StarshipType.Cruiser:
                    return new Cruiser(name, location);
                case StarshipType.Dreadnought:
                    return new Dreadnought(name, location);
                default:
                    throw new NotSupportedException("Starship type not supported.");
            }
        }
    }
}