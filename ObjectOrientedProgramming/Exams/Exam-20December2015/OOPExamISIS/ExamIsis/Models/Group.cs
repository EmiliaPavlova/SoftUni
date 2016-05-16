namespace ExamIsis.Models
{
    using System;
    using Interfaces;
    public class Group : IGroup
    {
        private int day = 0;

        private string name;
        private int health;
        private int damage;

        public Group(string name, int health, int damage, string warEffect, string attackType)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.warEffect = warEffect;
            this.attackType = attackType;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return this.name; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health cannot be negative");
                }
                this.health = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        public string warEffect { get; }

        public string attackType { get; }

        public bool IsAlive { get; set; }

        public virtual int Jihad(int damage)
        {
            int result = 2*this.Damage;
            result -= 5;
            return result;
        }

        public virtual int Kamikaze(int health)
        {
            int result = this.Health + 50;
            result -= 10;
            return result;
        }

        public virtual void Update()
        {
            this.day++;
        }

        public override string ToString()
        {
            var result = string.Format("Group {0}: {1} HP, {2} Damage",
                this.Name, this.Health, this.Damage);
            return result;
        }
    }
}
