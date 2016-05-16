namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage) : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            ship.Shields -= this.Damage;
            int reminder = this.Damage - ship.Shields;
            if (reminder > 0)
            {
                ship.Health -= reminder;
            }
        }
    }
}