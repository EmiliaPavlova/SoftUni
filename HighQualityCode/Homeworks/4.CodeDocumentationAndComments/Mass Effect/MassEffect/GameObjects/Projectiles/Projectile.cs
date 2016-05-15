namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    /// <summary>
    ///     The projectile.
    /// </summary>
    public abstract class Projectile : IProjectile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Projectile"/> class.
        /// </summary>
        /// <param name="damage">
        /// The damage.
        /// </param>
        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        /// <summary>
        ///     Gets or sets the damage.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// The hit.
        /// </summary>
        /// <param name="ship">
        /// The ship.
        /// </param>
        public abstract void Hit(IStarship ship);
    }
}