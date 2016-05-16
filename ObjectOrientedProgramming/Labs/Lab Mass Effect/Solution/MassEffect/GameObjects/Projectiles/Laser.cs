using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            int remainder = this.Damage - targetShip.Shields;
            targetShip.Shields -= this.Damage;

            if (remainder > 0)
            {
                targetShip.Health -= remainder;
            }
        }
    }
}
