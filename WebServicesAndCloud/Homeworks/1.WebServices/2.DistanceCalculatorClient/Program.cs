namespace _2.DistanceCalculatorClient
{
    using System;
    using ServiceReferenceCalculator;

    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceDistanceCalcClient();
            var startPoint = new Point { x = 10, y = 10 };
            var endPoint = new Point { x = 15, y = 15 };
            var result = client.CalcDistance(startPoint, endPoint);
            Console.WriteLine(result);
        }
    }
}
