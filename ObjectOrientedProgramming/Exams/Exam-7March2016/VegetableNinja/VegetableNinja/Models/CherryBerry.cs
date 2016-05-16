namespace VegetableNinja.Models
{
    public class CherryBerry : Vegetable
    {
        private const char DefaultName = 'C';
        private const int DefaultPowerEffect = 0;
        private const int DefaultStaminaEffect = 10;
        private const int TurnsToGrow = 5;

        public CherryBerry() 
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