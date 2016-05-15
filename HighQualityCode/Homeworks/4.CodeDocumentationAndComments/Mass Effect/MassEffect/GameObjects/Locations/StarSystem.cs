namespace MassEffect.GameObjects.Locations
{
    using System.Collections.Generic;

    /// <summary>
    ///     The star system.
    /// </summary>
    public class StarSystem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StarSystem"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public StarSystem(string name)
        {
            this.Name = name;
            this.NeighbourStarSystems = new Dictionary<StarSystem, double>();
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the neighbour star systems.
        /// </summary>
        public IDictionary<StarSystem, double> NeighbourStarSystems { get; set; }
    }
}