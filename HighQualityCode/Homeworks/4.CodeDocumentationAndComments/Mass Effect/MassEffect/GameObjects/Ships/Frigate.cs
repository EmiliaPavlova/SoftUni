namespace MassEffect.GameObjects.Ships
{
    using System;
    using Interfaces;
    using Locations;
    using Projectiles;

    /// <summary>
    ///     The frigate.
    /// </summary>
    public class Frigate : Starship
    {
        /// <summary>
        ///     The frigate start health.
        /// </summary>
        private const int FrigateStartHealth = 60;

        /// <summary>
        ///     The frigate start shields.
        /// </summary>
        private const int FrigateStartShields = 50;

        /// <summary>
        ///     The frigate start damage.
        /// </summary>
        private const int FrigateStartDamage = 30;

        /// <summary>
        ///     The frigates start fuel.
        /// </summary>
        private const int FrigatesStartFuel = 220;

        /// <summary>
        ///     The projectiles fired.
        /// </summary>
        private int projectilesFired;

        /// <summary>
        /// Initializes a new instance of the <see cref="Frigate"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        public Frigate(string name, StarSystem location)
            : base(name, FrigateStartHealth, FrigateStartShields, FrigateStartDamage, FrigatesStartFuel, location)
        {
            this.projectilesFired = 0;
        }

        /// <summary>
        ///     The produce attack.
        /// </summary>
        /// <returns>
        ///     The <see cref="IProjectile" />.
        /// </returns>
        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;

            return new ShieldReaver(this.Damage);
        }

        /// <summary>
        ///     The to string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            string output = base.ToString();

            if (this.Health > 0)
            {
                output += string.Format("{0}-Projectiles fired: {1}", Environment.NewLine, this.projectilesFired);
            }

            return output;
        }
    }
}