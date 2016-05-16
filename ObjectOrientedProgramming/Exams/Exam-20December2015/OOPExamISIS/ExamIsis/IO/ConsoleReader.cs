using System;

namespace ExamIsis.IO
{
    using Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
