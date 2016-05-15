namespace MassEffect.GameObjects.Enhancements
{
    /// <summary>
    ///     The enhancement.
    /// </summary>
    public class Enhancement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enhancement"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="shieldBonus">
        /// The shield bonus.
        /// </param>
        /// <param name="damageBonus">
        /// The damage bonus.
        /// </param>
        /// <param name="fuelBonus">
        /// The fuel bonus.
        /// </param>
        public Enhancement(string name, int shieldBonus, int damageBonus, int fuelBonus)
        {
            this.Name = name;
            this.ShieldBonus = shieldBonus;
            this.DamageBonus = damageBonus;
            this.FuelBonus = fuelBonus;
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets the shield bonus.
        /// </summary>
        public int ShieldBonus { get; private set; }

        /// <summary>
        ///     Gets the damage bonus.
        /// </summary>
        public int DamageBonus { get; private set; }

        /// <summary>
        ///     Gets the fuel bonus.
        /// </summary>
        public double FuelBonus { get; private set; }
    }
}