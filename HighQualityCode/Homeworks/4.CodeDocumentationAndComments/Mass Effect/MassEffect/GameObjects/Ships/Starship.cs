namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enhancements;
    using Interfaces;
    using Locations;

    /// <summary>
    ///     The starship.
    /// </summary>
    public abstract class Starship : IStarship
    {
        /// <summary>
        ///     The enhancements.
        /// </summary>
        private readonly IList<Enhancement> enhancements;

        /// <summary>
        /// Initializes a new instance of the <see cref="Starship"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="health">
        /// The health.
        /// </param>
        /// <param name="shields">
        /// The shields.
        /// </param>
        /// <param name="damage">
        /// The damage.
        /// </param>
        /// <param name="fuel">
        /// The fuel.
        /// </param>
        /// <param name="location">
        /// The location.
        /// </param>
        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the health.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        ///     Gets or sets the shields.
        /// </summary>
        public int Shields { get; set; }

        /// <summary>
        ///     Gets or sets the damage.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        ///     Gets or sets the fuel.
        /// </summary>
        public double Fuel { get; set; }

        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        public StarSystem Location { get; set; }

        /// <summary>
        ///     Gets the enhancements.
        /// </summary>
        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }

        /// <summary>
        ///     The produce attack.
        /// </summary>
        /// <returns>
        ///     The <see cref="IProjectile" />.
        /// </returns>
        public abstract IProjectile ProduceAttack();

        /// <summary>
        /// The respond to attack.
        /// </summary>
        /// <param name="projectile">
        /// The projectile.
        /// </param>
        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }

        /// <summary>
        /// The add enhancement.
        /// </summary>
        /// <param name="enhancement">
        /// The enhancement.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null.");
            }

            this.enhancements.Add(enhancement);
            this.ApplyEnhancementEffects(enhancement);
        }

        /// <summary>
        /// The apply enhancement effects.
        /// </summary>
        /// <param name="enhancement">
        /// The enhancement.
        /// </param>
        private void ApplyEnhancementEffects(Enhancement enhancement)
        {
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
            this.Damage += enhancement.DamageBonus;
        }

        /// <summary>
        ///     The to string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));

                string enhancementsOutput = "N/A";

                if (this.enhancements.Any())
                {
                    enhancementsOutput = string.Join(", ", this.enhancements.Select(e => e.Name));
                }

                output.Append(string.Format("-Enhancements: {0}", enhancementsOutput));
            }

            return output.ToString();
        }
    }
}