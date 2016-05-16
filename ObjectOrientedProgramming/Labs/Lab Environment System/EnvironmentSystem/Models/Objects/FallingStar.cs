using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    public class FallingStar : MovingObject
    {
        public FallingStar(int x, int y, int width, int height, Point direction) 
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { 'O' } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            var direction = this.Direction.X;
            return new EnvironmentObject[3]
            {
                new Tail(this.Bounds.TopLeft.X - direction, this.Bounds.TopLeft.Y - 1, new Point(0, 0)),
                new Tail(this.Bounds.TopLeft.X - direction, this.Bounds.TopLeft.Y - 1, new Point(0, 0)),
                new Tail(this.Bounds.TopLeft.X - direction, this.Bounds.TopLeft.Y - 1, new Point(0, 0)),
            };
        }
    }
}
