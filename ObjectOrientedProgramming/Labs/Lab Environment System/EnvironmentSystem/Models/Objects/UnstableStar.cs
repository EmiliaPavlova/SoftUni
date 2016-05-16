using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    public class UnstableStar : FallingStar
    {
        private const int UnstableStarHight = 1;
        private const int UnstableStarWidth = 1;

        public UnstableStar(int x, int y, Point direction) 
            : base(x, y, UnstableStarWidth, UnstableStarHight, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '@' } };
        }

        int count = 0;
        public override void Update()
        {
            base.Update();
            this.count++;
            if (this.count % 8 == 0)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.Exists)
            {
                return base.ProduceObjects();
            }
            
            return new EnvironmentObject[]
            {
                new Explosion(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y)
            };
        }
    }
}
