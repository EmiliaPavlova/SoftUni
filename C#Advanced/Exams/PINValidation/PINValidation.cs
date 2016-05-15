namespace PINValidation
{
    using System;
    using System.Text.RegularExpressions;

    class PINValidation
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string gender = Console.ReadLine();
            string pin = Console.ReadLine();
            var numbers = new [] {2, 4, 8, 5, 10, 9, 7, 3, 6};
            
            if (pin.Length == 10)
            {
                Boolean isCorrect = true;
                var nameRegex = new Regex(@"[A-Z][a-z]+\s+[A-Z][a-z]+");
                var match = nameRegex.Match(name);
                if (!match.Success)
                {
                    isCorrect = false;
                }

                int month = int.Parse(pin.Substring(2, 2));
                var day = int.Parse(pin.Substring(4, 2));
                if (month > 40)
                {
                    month -= 40;
                }
                else if (month > 20)
                {
                    month -= 20;
                }
                if (month < 1 || month > 12)
                {
                    isCorrect = false;
                }

                var daysInMonth = 0;
                switch (month)
                {
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        daysInMonth = 30;
                        break;
                    case 2:
                        daysInMonth = 28;
                        break;
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        daysInMonth = 31;
                        break;
                }

                if (day < 1 || day > daysInMonth)
                {
                    isCorrect = false;
                }
                var isFemale = (pin[8] - '0') % 2 == 1; // pin[8] returns ASCii code, -'0' returns the value
                var checkInputGender = gender == "female";
                if (isFemale != checkInputGender)
                {
                    isCorrect = false;
                }

                var checksum = 0;
                for (int index = 0; index < numbers.Length; index++)
                {
                    int currentDigit = pin[index] - '0';
                    checksum += currentDigit * numbers[index];
                }
                int reminder = checksum % 11;
                if (reminder == 10)
                {
                    reminder = 0;
                }
                if (reminder != (pin[9] - '0'))
                {
                    isCorrect = false;
                }

                if (isCorrect)
                {
                    Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", name, gender, pin);
                }
                else
                {
                    Console.WriteLine("<h2>Incorrect data</h2>");
                }
            }
        }
    }
}
