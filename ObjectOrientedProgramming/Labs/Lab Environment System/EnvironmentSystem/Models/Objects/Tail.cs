using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    public class Tail : MovingObject
    {
        private const int TailHight = 1;
        private const int TailWidth = 1;

        public Tail(int x, int y, Point direction) : base(x, y, TailWidth, TailHight, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '+' } };
        }

        int count = 0;
        public override void Update()
        {
            this.count++;
            if (this.count == 3)
            {
                this.ImageProfile = new char[,] { };
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
