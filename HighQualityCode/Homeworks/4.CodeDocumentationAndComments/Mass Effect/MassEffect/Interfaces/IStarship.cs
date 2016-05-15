namespace MassEffect.Interfaces
{
    using GameObjects.Locations;

    /// <summary>
    ///     The Starship interface.
    /// </summary>
    public interface IStarship : IEnhanceable
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the health.
        /// </summary>
        int Health { get; set; }

        /// <summary>
        ///     Gets or sets the shields.
        /// </summary>
        int Shields { get; set; }

        /// <summary>
        ///     Gets or sets the damage.
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        ///     Gets or sets the fuel.
        /// </summary>
        double Fuel { get; set; }

        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        StarSystem Location { get; set; }

        /// <summary>
        ///     The produce attack.
        /// </summary>
        /// <returns>
        ///     The <see cref="IProjectile" />.
        /// </returns>
        IProjectile ProduceAttack();

        /// <summary>
        /// The respond to attack.
        /// </summary>
        /// <param name="attack">
        /// The attack.
        /// </param>
        void RespondToAttack(IProjectile attack);
    }
}