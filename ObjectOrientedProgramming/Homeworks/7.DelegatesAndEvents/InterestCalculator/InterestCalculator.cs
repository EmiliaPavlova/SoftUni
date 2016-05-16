namespace InterestCalculator
{
    using System;

    public delegate decimal CalculateInterest(decimal money, decimal interest, int years);

    public class InterestCalculator
    {
        private readonly CalculateInterest calculationMethod;

        private decimal interest;
        private int years;

        public InterestCalculator(decimal money, decimal interest, int years, CalculateInterest calculationMethod)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.calculationMethod = calculationMethod;
        }

        public decimal Money { get; private set; }

        public decimal Interest
        {
            get { return this.interest; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("interest", "The interest rate cannot be negative.");
                }
                this.interest = value;
            }
        }

        public int Years
        {
            get { return this.years; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("years", "The number of years cannot be negative.");
                }
                this.years = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.calculationMethod(this.Money, this.Interest, this.Years);
            }
        }
    }
}
