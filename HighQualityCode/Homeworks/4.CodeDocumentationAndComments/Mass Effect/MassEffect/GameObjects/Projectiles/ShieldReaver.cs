namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    /// <summary>
    ///     The shield reaver.
    /// </summary>
    public class ShieldReaver : Projectile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShieldReaver"/> class.
        /// </summary>
        /// <param name="damage">
        /// The damage.
        /// </param>
        public ShieldReaver(int damage)
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
            ship.Health -= this.Damage;
            ship.Shields -= 2*this.Damage;
        }
    }
}