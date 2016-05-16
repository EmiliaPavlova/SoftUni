namespace VegetableNinja.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Ninja : INinja
    {
        private string name;
        private int power;
        private int stamina;
        private int positionX;
        private int positionY;
        private IEnumerable<IVegetable> vegetables;
        private char[] vegetableNames = {'A', 'B', 'C', 'M', 'R', '-'};

        protected Ninja(string name, int startPositionX, int startPositionY)
        {
            this.Name = name;
            this.Power = 1;
            this.Stamina = 1;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.vegetables = new List<IVegetable>();
        }

        
        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (ValidName(value))
                {
                    this.name = value;
                }
            }
        }

        public int Power
        {
            get { return this.power; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.power = value;
            }
        }

        public int Stamina
        {
            get { return this.stamina; }
            set {
                if (value < 0)
                {
                    value = 0;
                }
                this.stamina = value;
            }
        }

        public int PositionX
        {
            get { return this.positionX; }
            set { this.positionX = value; }
        }

        public int PositionY
        {
            get { return this.positionY; }
            set { this.positionY = value; }
        }

        public void ApplyVegetableEffect(IVegetable vegetable)
        {
            this.Power += vegetable.PowerEffect;
            this.Stamina += vegetable.StaminsEffect;
        }

        private bool ValidName(string name)
        {
            foreach (char c in name)
            {
                if (!this.vegetableNames.Contains(c))
                {
                    return true;
                }
            }

            throw new ArgumentException("Invalid ninja's name");
        }

        public void Update()
        {
            this.Stamina--;
        }

        public override string ToString()
        {
            return $"Winner: {this.Name}{Environment.CommandLine}Power: {this.Power}{Environment.CommandLine}Stamina: {this.Stamina}";
        }
    }
}