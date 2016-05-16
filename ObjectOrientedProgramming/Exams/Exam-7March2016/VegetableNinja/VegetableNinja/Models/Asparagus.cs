namespace VegetableNinja.Models
{
    using Interfaces;

    public class Asparagus : Vegetable
    {
        private const char DefaultName = 'A';
        private const int DefaultPowerEffect = 5;
        private const int DefaultStaminaEffect = -5;
        private const int TurnsToGrow = 2;

        public Asparagus() 
            : base(DefaultName, DefaultPowerEffect, DefaultStaminaEffect, TurnsToGrow)
        {
        }
        
    }
}