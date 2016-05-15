namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    /// <summary>
    ///     The laser.
    /// </summary>
    internal class Laser : Projectile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Laser"/> class.
        /// </summary>
        /// <param name="damage">
        /// The damage.
        /// </param>
        public Laser(int damage)
            : base(damage)
        {
        }

        /// <summary>
        /// The hit.
        /// </summary>
        /// <param name="ship">
        /// The ship.
        /// </param>
        public override void Hit(IStarship ship)
        {
            int remainder = this.Damage - ship.Shields;
            ship.Shields -= this.Damage;

            if (remainder > 0)
            {
                ship.Health -= remainder;
            }
        }
    }
}