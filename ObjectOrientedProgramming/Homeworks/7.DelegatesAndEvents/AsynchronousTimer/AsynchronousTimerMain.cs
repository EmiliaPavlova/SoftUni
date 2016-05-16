using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousTimer
{
    class AsynchronousTimerMain
    {
        private static readonly Encoding EncodingOEMUnitedStates = Encoding.GetEncoding(437);

        public static void PasswordGenerator(int x)
        {
            string character = EncodingOEMUnitedStates.GetString(new byte[] { (byte)x });
            Console.Write(character);
        }

        public static void AddNewLine(int x)
        {
            Console.WriteLine();
        }

        public static void Main()
        {
            AsynchronousTimer passGenerator = new AsynchronousTimer(PasswordGenerator, 16, 1000);
            passGenerator.ExecuteAction();

            AsynchronousTimer addNewLine = new AsynchronousTimer(AddNewLine, 1, 20000);
            addNewLine.ExecuteAction();
        }
    }
}
