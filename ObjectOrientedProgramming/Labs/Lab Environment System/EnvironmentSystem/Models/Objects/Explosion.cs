using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    class Explosion : EnvironmentObject
    {
        private const int ExplosionHight = 5;
        private const int ExplosionWidth = 5;

        public Explosion(int x, int y) : base(x, y, ExplosionWidth, ExplosionHight)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Explosion;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,]
            {
                { '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*'},
                { '*', '*', ' ', '*', '*'},
                { '*', '*', '*', '*', '*'},
                { '*', '*', '*', '*', '*'}
            };
        }

        int count = 0;
        public override void Update()
        {
            this.count++;
            if (this.count == 2)
            {
                this.ImageProfile = new char[,] { };
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
