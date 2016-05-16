using System;

namespace InterestCalculator
{
    class CalculatorMain
    {
        public const int MonthsInYear = 12;

        public static void Main()
        {
            InterestCalculator compoundInterest = new InterestCalculator(500m, 0.056m, 10, GetCompoundInterest);
            Console.WriteLine("{0:F4}", compoundInterest.Balance);

            InterestCalculator simpleInterest = new InterestCalculator(2500m, 0.072m, 15, GetSimpleInterest);
            Console.WriteLine("{0:F4}", simpleInterest.Balance);
        }

        public static decimal GetSimpleInterest(decimal money, decimal interest, int years)
        {
            decimal interestFactor = 1 + (interest * years);
            decimal balance = money * interestFactor;

            return decimal.Round(balance, 4);
        }

        public static decimal GetCompoundInterest(decimal money, decimal interest, int years)
        {
            decimal interestFactorBase = 1 + (interest / MonthsInYear);
            int interestFactorPower = years * MonthsInYear;

            decimal interestFactor = 1;
            for (int i = 0; i < interestFactorPower; i++)
            {
                interestFactor *= interestFactorBase;
            }

            decimal balance = money * interestFactor;

            return decimal.Round(balance, 4);
        }
    }
}
