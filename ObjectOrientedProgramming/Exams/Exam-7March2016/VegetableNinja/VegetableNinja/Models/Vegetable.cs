namespace VegetableNinja.Models
{
    using Interfaces;

    public abstract class Vegetable : IVegetable
    {
        protected char name;
        protected int powerEffect;
        protected int staminaEffect;
        protected int turnsToGrow;

        private int turnsCount = 0;

        protected Vegetable(char name, int powerEffect, int staminaEffect, int turnsToGrow)
        {
            this.Name = name;
            this.PowerEffect = powerEffect;
            this.StaminsEffect = staminaEffect;
            this.turnsToGrow = turnsToGrow;
            this.isTaken = false;
        }

        public char Name { get; }

        public int PowerEffect { get; }

        public int StaminsEffect { get; }

        public bool isTaken { get; protected set; }

        public bool isGrown { get; protected set; }

        public virtual void Regrow()
        {
            if (isTaken)
            {
                if (this.turnsToGrow == this.turnsCount)
                {
                    this.isGrown = true;
                    this.isTaken = false;
                }
            }
        }

        public void Update()
        {
            this.turnsCount++;
        }
    }
}