namespace MassEffect.GameObjects.Ships
{
    using Interfaces;
    using Locations;
    using Projectiles;

    /// <summary>
    ///     The dreadnought.
    /// </summary>
    public class Dreadnought : Starship
    {
        /// <summary>
        ///     The dreadnought start health.
        /// </summary>
        private const int DreadnoughtStartHealth = 200;

        /// <summary>
        ///     The dreadnought start shields.
        /// </summary>
        private const int DreadnoughtStartShields = 300;

        /// <summary>
        ///     The dreadnought start damage.
        /// </summary>
        private const int DreadnoughtStartDamage = 150;

        /// <summary>
        ///     The dreadnought start fuel.
        /// </summary>
        private const int DreadnoughtStartFuel = 700;

        /// <summary>
        ///     The response to attack shields increase.
        /// </summary>
        private const int ResponseToAttackShieldsIncrease = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dreadnought"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        public Dreadnought(string name, StarSystem location)
            : base(
                name, DreadnoughtStartHealth, DreadnoughtStartShields, DreadnoughtStartDamage, DreadnoughtStartFuel, 
                location)
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
            var damageCoefficient = (this.Shields/2) + this.Damage;

            return new Laser(damageCoefficient);
        }

        /// <summary>
        /// The respond to attack.
        /// </summary>
        /// <param name="projectile">
        /// The projectile.
        /// </param>
        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += ResponseToAttackShieldsIncrease;

            base.RespondToAttack(projectile);

            this.Shields -= ResponseToAttackShieldsIncrease;
        }
    }
}