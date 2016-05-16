﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public class ShieldReaver : Projectile
    {
        public ShieldReaver(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Shields -= this.Damage * 2;
            targetShip.Health -= this.Damage;
        }
    }
}
