namespace VegetableNinja.Models
{
    public class Royal : Vegetable
    {
        private const char DefaultName = 'R';
        private const int DefaultPowerEffect = 20;
        private const int DefaultStaminaEffect = 10;
        private const int TurnsToGrow = 10;

        public Royal() 
            : base(DefaultName, DefaultPowerEffect, DefaultStaminaEffect, TurnsToGrow)
        {
        }

        public override void Regrow()
        {
            //10 player moves
            throw new System.NotImplementedException();
        }
    }
}