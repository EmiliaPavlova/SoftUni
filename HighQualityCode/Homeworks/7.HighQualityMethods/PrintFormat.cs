namespace Methods
{
    using System;

    public class PrintFormat
    {
        /// <summary>
        /// Prints digits as words
        /// </summary>
        /// <param name="digit"></param>
        /// <returns>the <see cref="string"/></returns>
        public static string PrintDigitAsWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            return "Invalid number!";
        }

        /// <summary>
        /// Format numbers
        /// </summary>
        /// <param name="number"></param>
        /// <param name="format"></param>
        public static void FormatNumber(object number, string format)
        {
            string formatLower = format.ToLower();
            switch (formatLower)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("format", "Wrong format string");
            }
        }
    }
}