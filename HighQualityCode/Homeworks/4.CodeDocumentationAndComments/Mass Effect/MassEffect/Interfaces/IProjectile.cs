namespace MassEffect.Interfaces
{
    /// <summary>
    ///     The Projectile interface.
    /// </summary>
    public interface IProjectile
    {
        /// <summary>
        ///     Gets or sets the damage.
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// The hit.
        /// </summary>
        /// <param name="ship">
        /// The ship.
        /// </param>
        void Hit(IStarship ship);
    }
}