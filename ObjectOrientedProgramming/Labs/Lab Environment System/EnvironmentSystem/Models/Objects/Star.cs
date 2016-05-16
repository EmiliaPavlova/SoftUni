using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    using System.Threading;
    using DataStructures;

    public class Star : EnvironmentObject
    {
        private const int StarHight = 1;
        private const int StarWidth = 1;
        private static Random rnd = new Random();
        char[] StarImages = "O@0".ToCharArray();

        public Star(int x, int y) : base(x, y, StarWidth, StarHight)
        {
            this.ImageProfile = this.GenerateImageProfile();
            
        }

        public Star(Rectangle bounds) : base(bounds)
        {
        }

        protected virtual char[,] GenerateImageProfile()
        {
            this.ImageProfile = new char[,] { { this.StarImages[rnd.Next(0, 3)] } };
            return this.ImageProfile;
        }

        int count = 0;
        public override void Update()
        {
            this.count++;
            if (this.count % 10 == 0)
            {
                this.ImageProfile = new char[,] { { this.StarImages[rnd.Next(0, 3)] } };
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject.CollisionGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
