namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public abstract class Projectile : IProjectile
    {
        protected int damage;

        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public abstract void Hit(IStarship ship);
    }
}