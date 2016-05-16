using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    using DataStructures;

    public class Snow : EnvironmentObject
    {
        private const int SnowHight = 1;
        private const int SnowWidth = 1;

        public Snow(int x, int y) 
            : base(x, y, SnowWidth, SnowHight)
        {
            this.ImageProfile = new char[,] { {'.'} };
            this.CollisionGroup = CollisionGroup.Snow;
        }

        public Snow(Rectangle bounds) 
            : base(bounds)
        {
        }

        public override void Update()
        {
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
