namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    /// <summary>
    ///     The penetration shell.
    /// </summary>
    public class PenetrationShell : Projectile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PenetrationShell"/> class.
        /// </summary>
        /// <param name="damage">
        /// The damage.
        /// </param>
        public PenetrationShell(int damage)
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
        }
    }
}