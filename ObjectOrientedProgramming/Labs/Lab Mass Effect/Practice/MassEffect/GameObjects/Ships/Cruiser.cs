namespace MassEffect.GameObjects.Ships
{
    using Locations;

    public class Cruiser : Starship
    {
        private const int DefaultHealth = 100;
        private const int DefaultShields = 100;
        private const int DefaultDamage = 50;
        private const int DefaultFuel = 300;

        public Cruiser(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
            this.Name = name;
            this.Location = location;
        }
    }
}