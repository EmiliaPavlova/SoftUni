using System;

namespace Methods
{
    public class MethodsMain
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Triangle area = {0}", Calculations.CalcTriangleArea(3, 4, 5));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            
            Console.WriteLine("The digit 5 is \"{0}\"", PrintFormat.PrintDigitAsWord(5));

            try
            {
                Console.WriteLine("The biggest element in the array is {0}", Calculations.FindMax(5, -1, 3, 2, 14, 2, 3));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            PrintFormat.FormatNumber(1.3, "f");
            PrintFormat.FormatNumber(0.75, "%");
            PrintFormat.FormatNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(Calculations.CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov"
            };

            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student()
            {
                FirstName = "Stella",
                LastName = "Markova"
            };

            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            
            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
