namespace MassEffect.GameObjects.Ships
{
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Frigate : Starship
    {
        private const int DefaultHealth = 60;
        private const int DefaultShields = 50;
        private const int DefaultDamage = 30;
        private const int DefaultFuel = 220;
        private int projectilesFired;

        public Frigate(string name, StarSystem location) 
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
            this.projectilesFired = 0;
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new ShieldReaver(this.Damage);
        }
    }
}