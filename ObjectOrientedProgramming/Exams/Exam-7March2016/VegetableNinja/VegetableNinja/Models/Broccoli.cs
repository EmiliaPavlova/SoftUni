namespace VegetableNinja.Models
{
    public class Broccoli : Vegetable
    {
        private const char DefaultName = 'B';
        private const int DefaultPowerEffect = 10;
        private const int DefaultStaminaEffect = 0;
        private const int TurnsToGrow = 3;

        public Broccoli() 
            : base(DefaultName, DefaultPowerEffect, DefaultStaminaEffect, TurnsToGrow)
        {
        }

        public override void Regrow()
        {
            //3 player moves 
            throw new System.NotImplementedException();
        }
    }
}