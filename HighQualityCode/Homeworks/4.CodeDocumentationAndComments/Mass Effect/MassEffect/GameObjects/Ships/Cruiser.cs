namespace MassEffect.GameObjects.Ships
{
    using Interfaces;
    using Locations;
    using Projectiles;

    /// <summary>
    ///     The cruiser.
    /// </summary>
    public class Cruiser : Starship
    {
        /// <summary>
        ///     The cruiser start health.
        /// </summary>
        private const int CruiserStartHealth = 100;

        /// <summary>
        ///     The cruiser start shields.
        /// </summary>
        private const int CruiserStartShields = 100;

        /// <summary>
        ///     The cruiser start damage.
        /// </summary>
        private const int CruiserStartDamage = 50;

        /// <summary>
        ///     The cruiser start fuel.
        /// </summary>
        private const int CruiserStartFuel = 300;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cruiser"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        public Cruiser(string name, StarSystem location)
            : base(name, CruiserStartHealth, CruiserStartShields, CruiserStartDamage, CruiserStartFuel, location)
        {
        }

        /// <summary>
        ///     The produce attack.
        /// </summary>
        /// <returns>
        ///     The <see cref="IProjectile" />.
        /// </returns>
        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}