namespace MassEffect.GameObjects.Ships
{
    using Locations;

    public class Dreadnought : Starship
    {
        private const int DefaultHealth = 200;
        private const int DefaultShields = 300;
        private const int DefaultDamage = 150;
        private const int DefaultFuel = 700;

        public Dreadnought(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
            this.Name = name;
            this.Location = location;
        }
    }
}