namespace Blobs.IO
{
    using System;
    using Interfaces;

    public class ConsoleInputReader : IInputReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
