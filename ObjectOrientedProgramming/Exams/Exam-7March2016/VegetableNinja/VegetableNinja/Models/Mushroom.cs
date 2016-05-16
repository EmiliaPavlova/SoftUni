namespace VegetableNinja.Models
{
    public class Mushroom : Vegetable
    {
        private const char DefaultName = 'M';
        private const int DefaultPowerEffect = -10;
        private const int DefaultStaminaEffect = -10;
        private const int TurnsToGrow = 5;

        public Mushroom() 
            : base(DefaultName, DefaultPowerEffect, DefaultStaminaEffect, TurnsToGrow)
        {
        }

        public override void Regrow()
        {
            //5 player moves
            throw new System.NotImplementedException();
        }
    }
}